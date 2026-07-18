namespace F3Core.Regions
{
    public class ConfiguredRegion : Region
    {
        private readonly RegionConfig _config;

        public ConfiguredRegion(RegionConfig config)
        {
            _config = config;
        }

        public RegionConfig Config => _config;
        public override string QueryStringValue => _config.QueryStringValue;
        public override string DisplayName => _config.DisplayName;
        public override string SpreadsheetId => _config.SpreadsheetId;
        public override List<int> MasterDataSheetIds => _config.MasterDataSheetIds;
        public override List<string> MasterDataSheetNames => _config.MasterDataSheetNames;
        public override int MissingDataRowOffset => _config.MissingDataRowOffset;
        public override MasterDataColumnIndicies MasterDataColumnIndicies => _config.MasterDataColumnIndicies;
        public override int RosterSheetId => _config.RosterSheetId;
        public override string RosterSheetName => _config.RosterSheetName;
        public override string RosterNameColumn => _config.RosterNameColumn;
        public override List<RosterSheetColumn> RosterSheetColumns => _config.RosterSheetColumns;
        public override string AosSheetName => _config.AosSheetName;
        public override AoColumnIndicies AoColumnIndicies => _config.AoColumnIndicies;
        public override string AosRetiredIndicator => _config.AosRetiredIndicator;
        public override bool SupportsDownrange => _config.SupportsDownrange;
        public override bool HasHistoricalData => _config.HasHistoricalData;
        public override bool HasQSourcePosts => _config.HasQSourcePosts;
        public override bool HasExtraActivity => _config.HasExtraActivity;
        public override bool IncludeInSector => _config.IncludeInSector;
        public override bool IsActive => _config.IsActive;
    }
}
