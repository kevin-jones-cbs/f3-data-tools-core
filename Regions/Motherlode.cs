﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F3Core.Regions
{
    public class Motherlode : Region
    {
        public override string QueryStringValue => "motherlode";
        public override string DisplayName => "Mother Lode";

        public override string SpreadsheetId => "11gcmSoqcKgDrSr5_gS-37SIOEQfLbGanvLpCC-n-A7w";

        public override int MasterDataSheetId => 0;
        public override string MasterDataSheetName => "Master Data";
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
            ExtraActivity = 17
        };

        public override int RosterSheetId => 1860109286;
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
            Retired = 14
        };

        public override string AosRetiredIndicator => string.Empty;

        public override bool HasQSourcePosts => true;
        public override bool HasExtraActivity => true;
    }
}