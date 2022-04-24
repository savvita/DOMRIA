using System;
using System.Linq;

namespace DOMRIA
{
    internal class FromArchiveItem : ManagerItem
    {
        public FromArchiveItem(Platform platform, Manager manager) : base ("From archive", platform, manager)
        {
            ItemAction = FromArchive;
        }

        public void FromArchive()
        {
            Platform.ShowResults(PlatformItem.PlatformBoard.GetAds(ManagerToAct));

            Console.Write("Enter an ID: ");

            if(Int32.TryParse(Console.ReadLine(), out int id))
            {
                Ad ad = PlatformItem.PlatformBoard.GetAds(ManagerToAct).FirstOrDefault(ad => ad.ID == id);
                if (ManagerToAct.FromArchive(ad))
                    Console.WriteLine("The ad is actual now");
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
