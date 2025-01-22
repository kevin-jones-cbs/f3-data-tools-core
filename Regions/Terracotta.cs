namespace F3Core.Regions
{
    public class Terracotta : Region
    {
        public override string QueryStringValue => "terracotta";
        public override string DisplayName => "Terracotta";        

        public override string SpreadsheetId => "1Deezoc78u8nzCbyggyhw3EI4fBVTnkdM8ZOgwtOU_kU";

        public override int MasterDataSheetId => 127246721;
        public override string MasterDataSheetName => "Master Data";
        public override int MissingDataRowOffset => 15000;

        public override MasterDataColumnIndicies MasterDataColumnIndicies => new MasterDataColumnIndicies
        {
            Date = 1,
            Location = 5,
            PaxName = 6,
            Fng = 7,
            Post = 8,
            Q = 9,
            QSourcePost = 10,
            QSourceQ = 11
        };

        public override int RosterSheetId => 1868968928;
        public override string RosterSheetName => "PAX Data";
        public override string RosterNameColumn => "A";
        public override List<RosterSheetColumn> RosterSheetColumns => new List<RosterSheetColumn>
        {
            RosterSheetColumn.PaxName, RosterSheetColumn.JoinDate
        };

        public override string AosSheetName => "Sites";

        public override AoColumnIndicies AoColumnIndicies => new AoColumnIndicies
        {
            Name = 1,
            City = 3,
            DayOfWeek = 2,
            Retired = 11
        };

        public override string AosRetiredIndicator => "Closed";

        public override bool HasQSourcePosts => true;

    }
}