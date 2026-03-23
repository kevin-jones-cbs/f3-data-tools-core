namespace F3Core
{
    public class TowerChallenge
    {
        public string PaxName { get; set; }
        public int FirstFEvents { get; set; }
    }

    public class TowerChallengeResponse
    {
        public List<TowerChallenge> ChallengeData { get; set; } = new();
        public List<string> ChallengeSites { get; set; } = new();
    }
}
