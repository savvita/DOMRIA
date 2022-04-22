using System;
using System.Collections.Generic;

namespace DOMRIA
{
    internal class Client : User
    {
        private readonly Dictionary<Func<IEnumerable<Ad>, FilterInfo, IEnumerable<Ad>>, FilterInfo> filters;

        public Client(string name, string phoneNumber) : base(name, phoneNumber)
        {
            filters = new Dictionary<Func<IEnumerable<Ad>, FilterInfo, IEnumerable<Ad>>, FilterInfo>();
        }


        public IEnumerable<Ad> GetAds(Platform platform) => platform.PlatformBoard.GetAds(this);

        public void AddFilter(Func<IEnumerable<Ad>, FilterInfo, IEnumerable<Ad>> filter, FilterInfo filterInfo) => filters.Add(filter, filterInfo);

        public void RemoveFilter(Func<IEnumerable<Ad>, FilterInfo, IEnumerable<Ad>> filter) => filters.Remove(filter);

        public IEnumerable<Ad> SetFilters(IEnumerable<Ad> ads)
        {
            IEnumerable<Ad> res = ads;

            foreach (var filter in filters)
            {
                res = filter.Key.Invoke(res, filter.Value);
            }
            return res;
        }

        public void ClearFilters() => filters.Clear();
    }
}
