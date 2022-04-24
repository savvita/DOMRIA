using System;
using System.Linq;
using System.Collections.Generic;

namespace DOMRIA
{
    internal class Client : User
    {
        public AndMultipleFilters Filters { get; private set; }

        public Client(string name = "", string phoneNumber = "") : base(name, phoneNumber)
        {
            Filters = new AndMultipleFilters();
        }


        public IEnumerable<Ad> GetAds(Platform platform) => platform.PlatformBoard.GetAds(this);

        public void AddFilter(IFilter filter) => Filters.Filters.Add(filter);

        public void RemoveFilter(IFilter filter) => Filters = Filters.Filter(_filter => _filter.Name != filter.Name);

        public IEnumerable<Ad> SetFilters(IEnumerable<Ad> ads) => ads.Where(ad => Filters.Match(ad));

        public void ClearFilters() => Filters = new AndMultipleFilters();

        public void ShowFilters()
        {
            if (Filters.Filters.Count > 0)
            {
                Console.WriteLine(new string('=', 15));
                Console.WriteLine(new string('=', 15));

                Console.WriteLine("Set filters:");

                foreach (var filter in Filters.Filters)
                {
                    Console.WriteLine(filter);
                }

                Console.WriteLine(new string('=', 15));
                Console.WriteLine(new string('=', 15));
            }
        }
    }
}
