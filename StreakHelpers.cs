using F3Core.Regions;

namespace F3Core
{
    public static class StreakHelpers
    {
        public static (int, DateTime) CalculateStreak(List<Post> posts, Region region, List<WorkoutDay> allPossibleWorkoutDays)
        {
            if (allPossibleWorkoutDays == null || allPossibleWorkoutDays.Count == 0)
            {
                return CalculateCalendarDayStreak(posts, region);
            }

            return CalculateStreak(posts, region, BuildWorkoutDayIndexes(allPossibleWorkoutDays));
        }

        public static (int, DateTime) CalculateStreak(List<Post> posts, Region region, IReadOnlyDictionary<DateTime, int> workoutDayIndexes)
        {
            if (workoutDayIndexes == null || workoutDayIndexes.Count == 0)
            {
                return CalculateCalendarDayStreak(posts, region);
            }

            int currentStreak = 0;
            int longestStreak = 0;
            int? lastWorkoutDayIndex = null;
            DateTime currentStreakStart = DateTime.MinValue;
            DateTime longestStreakStart = DateTime.MinValue;

            var postDates = posts
                .Select(x => x.Date.Date)
                .Distinct()
                .OrderBy(x => x);

            foreach (var postDate in postDates)
            {
                if (!workoutDayIndexes.TryGetValue(postDate, out var workoutDayIndex))
                {
                    continue;
                }

                if (lastWorkoutDayIndex == null)
                {
                    currentStreak = 1;
                    currentStreakStart = postDate;
                }
                else if (workoutDayIndex == lastWorkoutDayIndex.Value + 1)
                {
                    currentStreak++;
                }
                else
                {
                    currentStreak = 1;
                    currentStreakStart = postDate;
                }

                longestStreak = Math.Max(longestStreak, currentStreak);
                if (longestStreak == currentStreak)
                {
                    longestStreakStart = currentStreakStart;
                }

                lastWorkoutDayIndex = workoutDayIndex;
            }

            return (longestStreak, longestStreakStart);
        }

        public static IReadOnlyDictionary<DateTime, int> BuildWorkoutDayIndexes(List<WorkoutDay> allPossibleWorkoutDays)
        {
            if (allPossibleWorkoutDays == null)
            {
                return new Dictionary<DateTime, int>();
            }

            return allPossibleWorkoutDays
                .Select(x => x.Date.Date)
                .Distinct()
                .OrderBy(x => x)
                .Select((date, index) => new { date, index })
                .ToDictionary(x => x.date, x => x.index);
        }

        public static (int, DateTime) CalculateStreak(List<Post> posts, Region region)
        {
            return CalculateCalendarDayStreak(posts, region);
        }

        private static (int, DateTime) CalculateCalendarDayStreak(List<Post> posts, Region region)
        {
            int currentStreak = 0;
            int longestStreak = 0;
            DateTime? lastWorkoutDate = null;
            DateTime currentStreakStart = DateTime.MinValue;
            DateTime longestStreakStart = DateTime.MinValue;
            DateTime firstSundayOpp = new DateTime(2023, 4, 16);

            foreach (var workoutDay in posts)
            {
                if (lastWorkoutDate == null)
                {
                    currentStreak = 1;
                    currentStreakStart = workoutDay.Date;
                }
                else if (workoutDay.Date == lastWorkoutDate.Value.AddDays(0))
                {
                    // Do nothing. Duplicate day.
                }
                else if (workoutDay.Date == lastWorkoutDate.Value.AddDays(1) ||
                    (workoutDay.Date.DayOfWeek == DayOfWeek.Monday && (workoutDay.Date < firstSundayOpp || region.DisplayName != "South Fork") && workoutDay.Date == lastWorkoutDate.Value.AddDays(2))) // Handle before we had Sundays
                {
                    currentStreak++;
                }
                else
                {
                    // If the dates are not consecutive, reset the streak
                    currentStreak = 1;
                    currentStreakStart = workoutDay.Date;
                }

                longestStreak = Math.Max(longestStreak, currentStreak);
                if (longestStreak == currentStreak)
                {
                    longestStreakStart = currentStreakStart;
                }

                lastWorkoutDate = workoutDay.Date;
            }

            return (longestStreak, longestStreakStart);
        }
    }
}
