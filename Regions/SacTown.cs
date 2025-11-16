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
            Date = 1,
            Location = 10,
            PaxName = 11,
            Fng = 12,
            Post = 13,
            Q = 14,
            QSourcePost = 15,
            QSourceQ = 16,
        };

        public override int RosterSheetId => 52995101;
        public override string RosterSheetName => "Roster";
        public override string RosterNameColumn => "B";
        public override List<RosterSheetColumn> RosterSheetColumns => new List<RosterSheetColumn>
        {
            RosterSheetColumn.Formula, RosterSheetColumn.PaxName, RosterSheetColumn.Empty, RosterSheetColumn.JoinDate, RosterSheetColumn.Formula, RosterSheetColumn.Empty, RosterSheetColumn.NamingRegionName
        };


        public override string AosSheetName => "Sites";

        public override AoColumnIndicies AoColumnIndicies => new AoColumnIndicies
        {
            Name = 1,
            City = 3,
            DayOfWeek = 2,
            Retired = 7,
            HasQSource = 8
        };
        public override string AosRetiredIndicator => string.Empty;
        public override bool HasQSourcePosts => true;
    }
}