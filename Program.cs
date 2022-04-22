using System;
using System.Linq;

namespace DOMRIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DOM dom = new DOM();
            //dom.PlatformBoard.Save();
            dom.PlatformBoard.Load();

            var ads = dom.PlatformBoard.GetAds(new Manager("", ""));

            foreach(var ad in ads)
            {
                ad.Show();
                Console.WriteLine(new String('=', 20));
            }

            //Manager m = (Manager) dom.Users[0];
            //m.GetAds()[0].AddAdditionalData(new AdditionalInfo("Water", "Absent"));

            //Client client = new Client("Crazy client", "");

            //try
            //{
            //    client.AddFilter(FilterByRooms.Filter, new FilterByRoomsInfo(2, 5));
            //    client.AddFilter(FilterByArea.Filter, new FilterByAreaInfo(20, 50));
            //    //client.RemoveFilter(FilterByArea.Filter);
            //    //client.RemoveFilter(FilterByArea.Filter);
            //    client.ClearFilters();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //foreach(var ad in client.SetFilters(dom.PlatformBoard.GetAds()))
            //{
            //    ad.Show();
            //    Console.WriteLine(new String('=', 20));
            //}
        }
    }
}
