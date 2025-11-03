namespace F3Core
{
    public class RegionSummaryData
    {
        /// <summary>
        /// Dictionary of PAX name to their aggregated post data for this region
        /// </summary>
        public Dictionary<string, PaxRegionData> PaxData { get; set; } = new();

        /// <summary>
        /// Total number of AOs (workout locations) in this region
        /// </summary>
        public int AoCount { get; set; }

        /// <summary>
        /// Number of unique PAX who posted in the last 30 days
        /// </summary>
        public int RecentUniquePaxCount { get; set; }
    }
}
