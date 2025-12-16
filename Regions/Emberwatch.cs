namespace F3Core.Regions
{
    public class Emberwatch : Region
    {
        public override string QueryStringValue => "emberwatch";
        public override string DisplayName => "Emberwatch";

        public override string SpreadsheetId => "1PN2ZPOmE2KekGR-heYi7iVvXeH1DDSFfZeO3Ct213R8";

        public override List<int> MasterDataSheetIds => new List<int> { 135712858 };
        public override List<string> MasterDataSheetNames => new List<string> { "Master Data" };

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

        public override int RosterSheetId => 0;
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