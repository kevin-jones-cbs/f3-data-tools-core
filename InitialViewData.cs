namespace F3Core
{
    public class InitialViewData
    {
        public List<DisplayRow> CurrentRows { get; set; }
        public List<int> ValidYears { get; set; }
        public List<string> ValidMonths { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public DateTime? FirstNonHistoricalDate { get; set; }
    }
}
