namespace F3Core.Regions
{
    public class FiaSacTown : Region
    {
        public override string QueryStringValue => "fiasactown";
        public override string DisplayName => "FiA SacTown";

        public override string SpreadsheetId => "1PuKNvGWbvgq1PE7RyECcGTsYcV-pv5Umz-a4g7SM_yQ";

        public override int MasterDataSheetId => 0;
        public override string MasterDataSheetName => "Master Data";
        public override int MissingDataRowOffset => 2;

        public override MasterDataColumnIndicies MasterDataColumnIndicies => new MasterDataColumnIndicies
        {
            Date = 0,
            Location = 6,
            PaxName = 7,
            Fng = 8,
            Post = 9,
            Q = 10
        };

        public override int RosterSheetId => 1800255987;
        public override string RosterSheetName => "Roster";
        public override string RosterNameColumn => "A";
        public override List<RosterSheetColumn> RosterSheetColumns => new List<RosterSheetColumn>
        {
            RosterSheetColumn.PaxName, RosterSheetColumn.JoinDate, RosterSheetColumn.NamingRegionName
        };

        public override string AosSheetName => "Sites";

        public override AoColumnIndicies AoColumnIndicies => new AoColumnIndicies
        {
            Name = 0,
            City = 2,
            DayOfWeek = 1,
            Retired = 6
        };

        public override string AosRetiredIndicator => "";

        public override bool HasHistoricalData => false;
        public override bool HasQSourcePosts => false;
    }
}