using F3Core.Regions;

namespace F3Core
{
    public static class DataHelper
    {
        public static List<DisplayRow> SetCurrentRows(
            List<Post> posts,
            DateTime? firstDay,
            DateTime lastDay,
            bool combineWithHistorical,
            List<WorkoutDay> allPossibleWorkoutDays,
            Region regionInfo,
            AllData allData,
            OverallView currentView,
            Func<List<Post>, int?> getCalDaysTo100Func)
        {
            var currentUniqueWorkoutDayCount = -1;
            if (firstDay != null)
            {
                currentUniqueWorkoutDayCount = allPossibleWorkoutDays.Where(x => x.Date >= firstDay && x.Date <= lastDay).Count();
            }

            // Group the posts by pax name
            var paxPosts = posts.GroupBy(p => p.Pax).ToDictionary(g => g.Key, g => g.OrderBy(x => x.Date).ToList());
            var rows = new List<DisplayRow>();

            // Add the pax to the display
            foreach (var pax in paxPosts)
            {
                var historicalPosts = 0;
                var historicalQs = 0;
                var historicalFirstDate = (DateTime?)null;

                if (regionInfo.HasHistoricalData && combineWithHistorical)
                {
                    var matchingHistoricalPost = allData.HistoricalData.FirstOrDefault(x => x.PaxName == pax.Key);
                    if (matchingHistoricalPost != null)
                    {
                        historicalPosts = matchingHistoricalPost.PostCount;
                        historicalQs = matchingHistoricalPost.QCount;
                        historicalFirstDate = matchingHistoricalPost.FirstPost;
                    }
                }

                var paxPostsWithData = pax.Value.Count;

                var row = new DisplayRow
                {
                    PaxName = pax.Key,
                    PostCount = paxPostsWithData + historicalPosts,
                };

                var paxFirstDate = pax.Value.Min(p => p.Date);

                if (firstDay == null)
                {
                    currentUniqueWorkoutDayCount = allPossibleWorkoutDays.Where(x => x.Date >= paxFirstDate).Count();
                }

                if (paxFirstDate != DateTime.MinValue)
                {
                    row.FirstPost = historicalFirstDate ?? paxFirstDate;
                    row.PostPercent = (double)paxPostsWithData / (double)currentUniqueWorkoutDayCount * 100;
                }

                // Get the Q count
                row.QCount = pax.Value.Where(p => p.IsQ).Count() + historicalQs;

                (var streak, var streakStart) = StreakHelpers.CalculateStreak(pax.Value, regionInfo);
                row.Streak = streak;

                row.QRatio = row.QCount == 0 ? 0 : (double)row.QCount / row.PostCount * 100;

                if (regionInfo.HasExtraActivity)
                {
                    row.ExtraActivityCount = pax.Value.Count(p => p.ExtraActivity);
                }

                // Kotter
                if (currentView == OverallView.Kotter)
                {
                    row.LastPost = pax.Value.Max(p => p.Date);
                    row.KotterDays = (DateTime.Now - row.LastPost.Value).Days;
                }

                // Q Kotter
                if (currentView == OverallView.QKotter)
                {
                    row.LastPost = pax.Value.Max(p => p.Date);
                    row.LastQ = pax.Value.Where(x => x.IsQ).Max(p => p.Date);
                    row.KotterDays = (DateTime.Now - row.LastQ.Value).Days;
                }

                // Ao Challenge. Find the number of unique aos for this pax, for this month
                if (currentView == OverallView.AoChallenge || currentView == OverallView.AoList)
                {
                    row.AoPosts = pax.Value.GroupBy(p => p.Site).Select(g => g.Key).Count();
                    row.AoPercent = (double)row.AoPosts / allData.Aos.Count * 100;
                }

                if (currentView == OverallView.AllTime)
                {
                    row.CalendarDaysTo100 = getCalDaysTo100Func(pax.Value);
                }

                rows.Add(row);
            }

            if (currentView == OverallView.Kotter || currentView == OverallView.QKotter)
            {
                rows = rows.OrderBy(r => r.KotterDays).ToList();
            }
            else if (currentView == OverallView.AoChallenge || currentView == OverallView.AoList)
            {
                rows = rows.OrderByDescending(r => r.AoPosts).ToList();
            }
            else
            {
                rows = rows.OrderByDescending(r => r.PostCount).ToList();
            }

            return rows;
        }

        public static List<WorkoutDay> GetCurrentPossibleWorkoutDays(List<Post> posts)
        {
            var currentUniqueWorkoutDays = new List<WorkoutDay>();
            foreach (var post in posts)
            {
                DateTime postDateWithoutTime = post.Date.Date;
                //bool isEvening = post.Site.Contains("moon", StringComparison.OrdinalIgnoreCase);
                var key = $"{postDateWithoutTime.ToShortDateString()}";

                // Check if the day and isEvening is already in the list
                if (currentUniqueWorkoutDays.Any(x => x.Date == postDateWithoutTime))
                {
                    continue;
                }

                currentUniqueWorkoutDays.Add(new WorkoutDay() { Date = postDateWithoutTime });
            }

            return currentUniqueWorkoutDays;
        }
    }
}
