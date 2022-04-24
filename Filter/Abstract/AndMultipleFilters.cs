using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace DOMRIA
{
    internal class AndMultipleFilters : IFilter
    {
        public List<IFilter> Filters { get; private set; }

        public string Name
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                foreach(IFilter filter in Filters)
                {
                    sb.Append(filter.Name);
                    sb.Append('\n');
                }    
                return sb.ToString();
            }
        }

        public AndMultipleFilters(List<IFilter> filters = null)
        {
            if (filters == null)
                Filters = new List<IFilter>();
            else
                Filters = filters;
        }

        public bool Match(Ad ad) => Filters.All(filter => filter.Match(ad));

        public AndMultipleFilters Filter (Func<IFilter, bool> filterFilter) => new AndMultipleFilters(Filters.Where(filterFilter).ToList());
    }
}
