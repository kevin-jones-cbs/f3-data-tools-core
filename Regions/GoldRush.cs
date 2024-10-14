namespace F3Core.Regions
{
    public class GoldRush : Region
    {
        public override string QueryStringValue => "goldrush";
        public override string DisplayName => "Gold Rush";        

        public override string SpreadsheetId => "1wBReydkjLGnxdRkmL8cknbvDWL7gH2K25LVmAq-J0iE";

        public override int MasterDataSheetId => 729344821;
        public override string MasterDataSheetName => "Master Data";
        public override int MissingDataRowOffset => 0;

        public override MasterDataColumnIndicies MasterDataColumnIndicies => new MasterDataColumnIndicies
        {
            Date = 7,
            Location = 1,
            PaxName = 0,
            Fng = 2,
            Post = 3,
            Q = 4,
            QSourcePost = 5,
            QSourceQ = 6
        };

        public override int RosterSheetId => 437240319;
        public override string RosterSheetName => "Roster";
        public override string RosterNameColumn => "B";
        public override List<RosterSheetColumn> RosterSheetColumns => new List<RosterSheetColumn>
        {
            RosterSheetColumn.Formula, RosterSheetColumn.PaxName, RosterSheetColumn.JoinDate, RosterSheetColumn.Empty, RosterSheetColumn.NamingRegionName
        };


        public override string AosSheetName => "Sites";

        public override AoColumnIndicies AoColumnIndicies => new AoColumnIndicies
        {
            Name = 1,
            City = 3,
            DayOfWeek = 2,
            Retired = 11
        };

        public override string AosRetiredIndicator => string.Empty;

        public override bool HasHistoricalData => true;
        public override bool HasQSourcePosts => true;
    }
}