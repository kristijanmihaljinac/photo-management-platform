using Common.DDD;
using Common.SortingAndFiltering;

namespace Common.Specifications
{
    public class OverviewSpecificationBuilder<T> where T : Entity
    {
        private List<FilterOption> _filterOptions;
        private List<SortOption> _sortOptions;

        public OverviewSpecificationBuilder()
        {
            _filterOptions = new List<FilterOption>();
            _sortOptions = new List<SortOption>();
        }

        public OverviewSpecificationBuilder<T> WithFilterOption(FilterOption filterOption)
        {
            _filterOptions.Add(filterOption);
            return this;
        }

        public OverviewSpecificationBuilder<T> WithSortOption(SortOption sortOption)
        {
            _sortOptions.Add(sortOption);
            return this;
        }

        public OverviewSpecificationBuilder<T> WithFilter(string propertyName, string filterValue)
        {
            _filterOptions.Add(new FilterOption { PropertyName = propertyName, FilterValue = filterValue });
            return this;
        }

        public OverviewSpecificationBuilder<T> WithDateRangeFilter(string propertyName, DateTime startDate, DateTime endDate)
        {
            _filterOptions.Add(new FilterOption { PropertyName = propertyName, StartDate = startDate, EndDate = endDate });
            return this;
        }

        public OverviewSpecificationBuilder<T> WithSort(string propertyName, SortDirection sortDirection)
        {
            _sortOptions.Add(new SortOption { PropertyName = propertyName, SortDirection = sortDirection });
            return this;
        }

        public OverviewSpecification<T> Build()
        {
            return new OverviewSpecification<T>(_filterOptions, _sortOptions);
        }
    }

}
