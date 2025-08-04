namespace F3Core.Regions
{
    public static class RegionList
    {
        public static List<Region> All = new List<Region>
        {
            new SouthFork(),
            new Asgard(),
            new Delta(),
            new Rubicon(),
            new GoldRush(),
            new SacTown(),
            new Motherlode(),
            new Terracotta(),
            new Junction(),
            new Bedrock(),
            new DryCreek(),

            // FiA Regions
            new FiaSouthFork(),
            new FiaSacTown()
        };

        // Get the region by the query string value
        public static Region GetRegion(string region)
        {
            if (string.IsNullOrEmpty(region))
            {
                return null;
            }
            
            return All.FirstOrDefault(r => r.QueryStringValue == region);
        }

        public static Dictionary<int, string> AllRegionValues = new Dictionary<int, string>
        {
            { 1, "Asgard" },
            { 2, "Delta" },
            { 3, "Gold Rush" },
            { 4, "Rubicon" },
            { 5, "South Fork" },
            { 6, "Terracotta" },
            { 7, "SacTown" },
            { 8, "Mother Lode" },
            { 9, "Junction" },
            { 10, "Bedrock" },
            { 11, "DryCreek" },
            { 12, "Other" }
        };
    }
}