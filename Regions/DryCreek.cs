namespace F3Core.Regions
{
    public class DryCreek : Region
    {
        public override string QueryStringValue => "drycreek";
        public override string DisplayName => "DryCreek";        

        public override string SpreadsheetId => "1wgRKUm2xsTFnfon_1sMXF78tb5cr93RPovFgUOiaqwY";

        public override int MasterDataSheetId => 0;
        public override string MasterDataSheetName => "Master Data";
        public override int MissingDataRowOffset => 1;

        public override MasterDataColumnIndicies MasterDataColumnIndicies => new MasterDataColumnIndicies
        {
            Date = 1,
            Location = 7,
            PaxName = 8,
            Fng = 9,
            Post = 10,
            Q = 11,
            QSourcePost = 12,
            QSourceQ = 13
        };

        public override int RosterSheetId => 794841232;
        public override string RosterSheetName => "Roster";
        public override string RosterNameColumn => "A";
        public override List<RosterSheetColumn> RosterSheetColumns => new List<RosterSheetColumn>
        {
            RosterSheetColumn.PaxName, RosterSheetColumn.JoinDate, RosterSheetColumn.NamingRegionName
        };

        public override string AosSheetName => "Sites";

        public override AoColumnIndicies AoColumnIndicies => new AoColumnIndicies
        {
            Name = 1,
            City = 3,
            DayOfWeek = 2,
            Retired = 7
        };

        public override string AosRetiredIndicator => "";

        public override bool HasHistoricalData => false;
        public override bool HasQSourcePosts => true;
    }
}