using System;
using System.Collections.Generic;
using System.Linq;

namespace DOMRIA
{
    internal class ManagerMenuItem : ManagerItem, IMenu
    {
        public ManagerMenuItem(Platform platform, Manager manager) : base("Continue as a manager", platform, manager)
        {
            Items = new List<Item>();
            ItemAction = null;
        }

        private void Login()
        {
            Console.Write("Enter a name: ");
            string name = Console.ReadLine();

            ManagerToAct = PlatformItem.Users.Where(_user => _user is Manager).ToList().Find(_user => _user.Name == name) as Manager;

            if (ManagerToAct != null)
            {
                Items.Add(new ShowAllManagerAdsItem(PlatformItem, ManagerToAct));
                Items.Add(new AddAdItem(PlatformItem, ManagerToAct));
                Items.Add(new ToArchiveItem(PlatformItem, ManagerToAct));
                Items.Add(new FromArchiveItem(PlatformItem, ManagerToAct));
            }
        }
 
        public void ShowMenu()
        {
            if (ManagerToAct == null)
                Login();

            if (ManagerToAct != null)
                new Menu(this).Show();
            else
                Console.WriteLine("Not registred at this PlatformItem");
        }
    }
}
