using System;
using System.Linq;

namespace DOMRIA
{
    internal class ToArchiveItem : ManagerItem
    {
        public ToArchiveItem(Platform platform, Manager manager) : base ("To archive", platform, manager)
        {
            ItemAction = ToArchive;
        }

        public void ToArchive()
        {
            foreach(Ad ad in PlatformItem.PlatformBoard.GetAds(ManagerToAct))
            {
                ad.Show();
                Console.WriteLine(new string('=', 15));
            }

            Console.Write("Enter an ID: ");

            if(Int32.TryParse(Console.ReadLine(), out int id))
            {
                Ad ad = PlatformItem.PlatformBoard.GetAds(ManagerToAct).FirstOrDefault(ad => ad.ID == id);
                if(ManagerToAct.ToArchive(ad))
                    Console.WriteLine("The ad is at the archive");
                else
                    Console.WriteLine("Invalid value");
            }
            else
            {
                Console.WriteLine("Invalid value");
            }
        }
    }
}
