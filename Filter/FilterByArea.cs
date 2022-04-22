using System.Collections.Generic;
using System.Linq;


namespace DOMRIA
{
    internal class FilterByArea
    {
         private static IEnumerable<Ad> Filter(IEnumerable<Ad> ads, FilterByAreaInfo filterInfo)
        {
            return ads.Where((ad) => ad.Article is RealProperty).Where((ad) => (ad.Article as RealProperty).Unit.TotalArea() >= filterInfo.MinArea && 
                (ad.Article as RealProperty).Unit.TotalArea() <= filterInfo.MaxArea);
        }

        public static IEnumerable<Ad> Filter(IEnumerable<Ad> ads, FilterInfo filterInfo)
        {
            FilterByAreaInfo filterByAreaInfo = filterInfo as FilterByAreaInfo;

            if (filterByAreaInfo == null)
                throw new System.ArgumentException("FilterInfo does not match to the filter");

            return Filter(ads, filterByAreaInfo);
        }
    }
}
