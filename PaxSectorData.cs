namespace F3Core
{
    public class SectorData
    {
        public List<PaxSectorData> PaxSectorData { get; set; }
        public int TotalPosts { get; set; }
        public int TotalPax { get; set; }
        public int TotalPax30Days { get; set; }
        public int ActiveLocations { get; set; }
    }

    public class PaxSectorData
    {
        public string PaxName { get; set; }
        public Dictionary<string, PaxRegionData> PaxRegionData { get; set; } = new();

        public int TotalPostCount { get; set; }
        public int TotalQCount { get; set; }
        public DateTime FirstPost { get; set; }
    }

    public class PaxRegionData
    {
        public string PaxName { get; set; }
        public int PostCount { get; set; }
        public int QCount { get; set; }
        public DateTime FirstPost { get; set; }

        public PaxRegionData(string name, int postCount, int qCount, DateTime firstPost)
        {
            PaxName = name;
            PostCount = postCount;
            QCount = qCount;
            FirstPost = firstPost;
        }

        public PaxRegionData() { }
    }
}
