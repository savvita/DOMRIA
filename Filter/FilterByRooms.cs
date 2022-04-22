using System.Collections.Generic;
using System.Linq;


namespace DOMRIA
{
    internal class FilterByRooms
    {
         private static IEnumerable<Ad> Filter(IEnumerable<Ad> ads, FilterByRoomsInfo filterInfo)
        {
            return ads.Where((ad) => ad.Article is RealProperty).Where((ad) => (ad.Article as RealProperty).Unit.CountRooms >= filterInfo.MinRooms && 
                (ad.Article as RealProperty).Unit.CountRooms <= filterInfo.MaxRooms);
        }

        public static IEnumerable<Ad> Filter(IEnumerable<Ad> ads, FilterInfo filterInfo)
        {
            FilterByRoomsInfo filterByRoomsInfo = filterInfo as FilterByRoomsInfo;

            if (filterByRoomsInfo == null)
                throw new System.ArgumentException("FilterInfo does not match to the filter");

            return Filter(ads, filterByRoomsInfo);
        }
    }
}
