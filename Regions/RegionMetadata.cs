namespace F3Core.Regions
{
    public class RegionMetadata
    {
        public string QueryStringValue { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public bool SupportsDownrange { get; set; }
        public bool HasQSourcePosts { get; set; }
        public bool HasExtraActivity { get; set; }
        public bool IncludeInSector { get; set; }

        public static RegionMetadata FromRegion(Region region)
        {
            return new RegionMetadata
            {
                QueryStringValue = region.QueryStringValue,
                DisplayName = region.DisplayName,
                SupportsDownrange = region.SupportsDownrange,
                HasQSourcePosts = region.HasQSourcePosts,
                HasExtraActivity = region.HasExtraActivity,
                IncludeInSector = region.IncludeInSector
            };
        }
    }
}
