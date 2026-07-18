namespace F3Core.Regions
{
    public class RegionConfigCatalog
    {
        public string ConfigVersion { get; set; } = string.Empty;
        public List<RegionConfig> Regions { get; set; } = new();
        public List<RegionNamingOption> DownrangeNamingRegions { get; set; } = new();

        public static RegionConfigCatalog FromHardCodedRegions()
        {
            return new RegionConfigCatalog
            {
                ConfigVersion = DateTime.UtcNow.ToString("O"),
                Regions = RegionList.All.Select(RegionConfig.FromRegion).ToList(),
                DownrangeNamingRegions = RegionList.AllRegionValues
                    .Select(x => new RegionNamingOption { Index = x.Key, DisplayName = x.Value })
                    .ToList()
            };
        }
    }

    public class RegionConfig
    {
        public string QueryStringValue { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string SpreadsheetId { get; set; } = string.Empty;
        public List<int> MasterDataSheetIds { get; set; } = new();
        public List<string> MasterDataSheetNames { get; set; } = new();
        public int MissingDataRowOffset { get; set; }
        public MasterDataColumnIndicies MasterDataColumnIndicies { get; set; } = new();
        public int RosterSheetId { get; set; }
        public string RosterSheetName { get; set; } = string.Empty;
        public string RosterNameColumn { get; set; } = string.Empty;
        public List<RosterSheetColumn> RosterSheetColumns { get; set; } = new();
        public string AosSheetName { get; set; } = string.Empty;
        public AoColumnIndicies AoColumnIndicies { get; set; } = new();
        public string AosRetiredIndicator { get; set; } = string.Empty;
        public bool SupportsDownrange { get; set; }
        public bool HasHistoricalData { get; set; }
        public bool HasQSourcePosts { get; set; }
        public bool HasExtraActivity { get; set; }
        public bool IncludeInSector { get; set; } = true;
        public bool IsActive { get; set; } = true;

        public static RegionConfig FromRegion(Region region)
        {
            return new RegionConfig
            {
                QueryStringValue = region.QueryStringValue,
                DisplayName = region.DisplayName,
                SpreadsheetId = region.SpreadsheetId,
                MasterDataSheetIds = region.MasterDataSheetIds,
                MasterDataSheetNames = region.MasterDataSheetNames,
                MissingDataRowOffset = region.MissingDataRowOffset,
                MasterDataColumnIndicies = region.MasterDataColumnIndicies,
                RosterSheetId = region.RosterSheetId,
                RosterSheetName = region.RosterSheetName,
                RosterNameColumn = region.RosterNameColumn,
                RosterSheetColumns = region.RosterSheetColumns,
                AosSheetName = region.AosSheetName,
                AoColumnIndicies = region.AoColumnIndicies,
                AosRetiredIndicator = region.AosRetiredIndicator,
                SupportsDownrange = region.SupportsDownrange,
                HasHistoricalData = region.HasHistoricalData,
                HasQSourcePosts = region.HasQSourcePosts,
                HasExtraActivity = region.HasExtraActivity,
                IncludeInSector = ShouldIncludeInSector(region),
                IsActive = region.IsActive
            };
        }

        private static bool ShouldIncludeInSector(Region region)
        {
            return !region.DisplayName.Contains("fia", StringComparison.OrdinalIgnoreCase) &&
                !region.DisplayName.Contains("emberwatch", StringComparison.OrdinalIgnoreCase);
        }
    }

    public class RegionNamingOption
    {
        public int Index { get; set; }
        public string DisplayName { get; set; } = string.Empty;
    }
}
