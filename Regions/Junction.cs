namespace F3Core.Regions
{
    public class Junction : Region
    {
        public override string QueryStringValue => "junction";
        public override string DisplayName => "Junction";        

        public override string SpreadsheetId => "1eANvPBlBW4II5dItXa7gtjZQf0FszOdPwHILmg1HyC8";

        public override List<int> MasterDataSheetIds => new List<int> { 729344821 };
        public override List<string> MasterDataSheetNames => new List<string> { "Master Data" };
        public override int MissingDataRowOffset => 2;

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
            Retired = 12
        };

        public override string AosRetiredIndicator => "Active";

        public override bool HasHistoricalData => false;
        public override bool HasQSourcePosts => true;
    }
}