namespace Common.SortingAndFiltering
{
    public class SortAndFilterOptions
    {
        public List<FilterOption> FilterOptions { get; set; }
        public List<SortOption> SortOptions { get; set; }
    }

    public class FilterOption
    {
        public string PropertyName { get; set; }
        public string FilterValue { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class SortOption
    {
        public string PropertyName { get; set; }
        public SortDirection SortDirection { get; set; }
    }

    public enum SortDirection
    {
        Ascending,
        Descending
    }
}
