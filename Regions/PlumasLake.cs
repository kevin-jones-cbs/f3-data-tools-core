namespace F3Core.Regions
{
    public class PlumasLake : Region
    {
        public override string QueryStringValue => "plumaslake";
        public override string DisplayName => "Plumas Lake";

        public override string SpreadsheetId => "1SV67kPW8jk_Ws4W_DPvGJ2_yiPvCncbAayhoCXwGYMs";

        public override List<int> MasterDataSheetIds => new List<int> { 919559676 };
        public override List<string> MasterDataSheetNames => new List<string> { "Master Data" };
        public override int MissingDataRowOffset => 2;

        public override MasterDataColumnIndicies MasterDataColumnIndicies => new MasterDataColumnIndicies
        {
            Date = 1,
            Location = 10,
            PaxName = 11,
            Fng = 12,
            Post = 13,
            Q = 14
        };

        public override int RosterSheetId => 1637644768;
        public override string RosterSheetName => "Roster";
        public override string RosterNameColumn => "B";
        public override List<RosterSheetColumn> RosterSheetColumns => new List<RosterSheetColumn>
        {
            RosterSheetColumn.Formula,
            RosterSheetColumn.PaxName,
            RosterSheetColumn.JoinDate,
            RosterSheetColumn.Empty,
            RosterSheetColumn.NamingRegionName
        };

        public override string AosSheetName => "Sites";

        public override AoColumnIndicies AoColumnIndicies => new AoColumnIndicies
        {
            Name = 1,
            City = 3,
            DayOfWeek = 2,
            Retired = 12
        };

        public override string AosRetiredIndicator => string.Empty;

        public override bool HasHistoricalData => false;
    }
}
