namespace F3Core.Regions
{
    public class SacTown : Region
    {
        public override string QueryStringValue => "sactown";

        public override string DisplayName => "SacTown";        

        public override string SpreadsheetId => "1_R4F0syR4m7eBen4j92PJCFeGrxEvNrbrL7LxFG46So";

        public override List<int> MasterDataSheetIds => new List<int> { 0 };
        public override List<string> MasterDataSheetNames => new List<string> { "Master Data" };
        public override int MissingDataRowOffset => 2;

        public override MasterDataColumnIndicies MasterDataColumnIndicies => new MasterDataColumnIndicies
        {
            Date = 0,
            Location = 1,
            PaxName = 2,
            Fng = 3,
            Post = 4,
            Q = 5,
            QSourcePost = 6,
            QSourceQ = 7,
        };

        public override int RosterSheetId => 52995101;
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
            HasQSource = 3,
            Retired = 4
        };
        public override string AosRetiredIndicator => string.Empty;
        public override bool HasQSourcePosts => true;
    }
}