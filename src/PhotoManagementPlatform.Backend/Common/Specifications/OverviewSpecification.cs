using Common.DDD;
using Common.SortingAndFiltering;

namespace Common.Specifications
{
    public class OverviewSpecification<T> : Specification<T>
        where T : Entity
    {
        public OverviewSpecification(
       List<FilterOption> filterOptions,
       List<SortOption> sortOptions)
       : base(p =>
           filterOptions.All(f =>
              (!f.PropertyName.Contains("Date") && 
                 p.GetType()
                .GetProperty(f.PropertyName)
                .GetValue(p, null)
                .ToString()
                .Contains(f.FilterValue) )
           && (f.PropertyName.Contains("Date")
               ? (DateTime)p.GetType()
                            .GetProperty(f.PropertyName)
                            .GetValue(p, null)
                            >= f.StartDate
                            && (DateTime)p.GetType()
                                          .GetProperty(f.PropertyName)
                                          .GetValue(p, null)
                                          <= f.EndDate
               : true)))
        {
            // Apply the sorting options
            if (sortOptions != null)
            {
                foreach (var sortOption in sortOptions)
                {
                    if (sortOption.SortDirection == SortDirection.Ascending)
                    {
                        AddOrderBy(p => p.GetType()
                                         .GetProperty(sortOption.PropertyName)
                                         .GetValue(p, null));
                    }
                    else
                    {
                        AddOrderByDescending(p => p.GetType()
                                                   .GetProperty(sortOption.PropertyName)
                                                   .GetValue(p, null));
                    }
                }
            }
        }
    }
}
