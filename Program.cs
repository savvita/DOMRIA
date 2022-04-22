using System;
using System.Linq;

namespace DOMRIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DOM dom = new DOM();
            dom.PlatformBoard.Save();

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
