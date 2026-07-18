namespace F3Core
{
    public sealed class LambdaActionDefinition
    {
        public LambdaActionDefinition(
            string name,
            bool requiresRegion = true,
            bool isWrite = false,
            bool includeInSmokeTests = false)
        {
            Name = name;
            RequiresRegion = requiresRegion;
            IsWrite = isWrite;
            IncludeInSmokeTests = includeInSmokeTests;
        }

        public string Name { get; }
        public bool RequiresRegion { get; }
        public bool IsWrite { get; }
        public bool IncludeInSmokeTests { get; }
    }

    public static class LambdaActions
    {
        public const string Awake = "Awake";
        public const string VerifySpreadsheetAccess = "VerifySpreadsheetAccess";
        public const string GetSheetTabs = "GetSheetTabs";
        public const string GetSheetPreview = "GetSheetPreview";
        public const string GetRegions = "GetRegions";
        public const string GetMissingAos = "GetMissingAos";
        public const string GetPax = "GetPax";
        public const string AddPax = "AddPax";
        public const string GetAllPosts = "GetAllPosts";
        public const string GetPaxFromComment = "GetPaxFromComment";
        public const string CheckClose100s = "CheckClose100s";
        public const string ClearCache = "ClearCache";
        public const string GetLocations = "GetLocations";
        public const string GetJson = "GetJson";
        public const string SaveJson = "SaveJson";
        public const string SaveToCache = "SaveToCache";
        public const string GetFromCache = "GetFromCache";
        public const string GetSectorDataSummaryAsync = "GetSectorDataSummaryAsync";
        public const string GetSectorData = "GetSectorData";
        public const string GetTerracottaChallenge = "GetTerracottaChallenge";
        public const string GetForgeChallenge = "GetForgeChallenge";
        public const string GetTowerChallenge = "GetTowerChallenge";
        public const string GetInitialView = "GetInitialView";
        public const string GetRegionSummary = "GetRegionSummary";
        public const string UpdatePaxEh = "UpdatePaxEh";

        private static readonly LambdaActionDefinition[] AllDefinitions =
        {
            new(Awake, requiresRegion: false),
            new(VerifySpreadsheetAccess, requiresRegion: false),
            new(GetSheetTabs, requiresRegion: false),
            new(GetSheetPreview, requiresRegion: false),
            new(GetRegions, requiresRegion: false, includeInSmokeTests: true),
            new(GetMissingAos, includeInSmokeTests: true),
            new(GetPax, includeInSmokeTests: true),
            new(AddPax, isWrite: true),
            new(GetAllPosts),
            new(GetPaxFromComment),
            new(CheckClose100s),
            new(ClearCache, isWrite: true),
            new(GetLocations, includeInSmokeTests: true),
            new(GetJson),
            new(SaveJson, isWrite: true),
            new(SaveToCache, isWrite: true),
            new(GetFromCache),
            new(GetSectorDataSummaryAsync, requiresRegion: false, includeInSmokeTests: true),
            new(GetSectorData, requiresRegion: false),
            new(GetTerracottaChallenge, requiresRegion: false, includeInSmokeTests: true),
            new(GetForgeChallenge, requiresRegion: false, includeInSmokeTests: true),
            new(GetTowerChallenge, requiresRegion: false, includeInSmokeTests: true),
            new(GetInitialView, includeInSmokeTests: true),
            new(GetRegionSummary, includeInSmokeTests: true),
            new(UpdatePaxEh, isWrite: true)
        };

        private static readonly IReadOnlyDictionary<string, LambdaActionDefinition> DefinitionsByName =
            AllDefinitions.ToDictionary(action => action.Name, StringComparer.Ordinal);

        public static IReadOnlyList<LambdaActionDefinition> All => AllDefinitions;

        public static IReadOnlyList<LambdaActionDefinition> SmokeTestActions =>
            AllDefinitions.Where(action => action.IncludeInSmokeTests).ToList();

        public static bool TryGetDefinition(string action, out LambdaActionDefinition definition)
        {
            return DefinitionsByName.TryGetValue(action, out definition!);
        }
    }
}
