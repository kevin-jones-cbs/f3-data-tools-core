namespace F3Core
{
    public class FunctionInput
    {
        public string Action { get; set; }
        public List<Pax> Pax { get; set; }
        public string AoName { get; set; }
        public DateTime QDate { get; set; }
        public string Region { get; set; }
        public string Comment { get; set; }
        public bool IsQSource { get; set; }

        public short JsonRow { get; set; }
        public string Json { get; set; }

        public CacheKeyType CacheKey { get; set; }
        public string CacheValue { get; set; }
    }
}
