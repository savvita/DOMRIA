using System;
using System.Collections.Generic;

namespace DOMRIA
{
    internal class PlatformMenu
    {
        readonly List<IMenu> Items;

        public PlatformMenu(Platform platform)
        {
            Items = new List<IMenu>
            {
                new ClientMenuItem(platform, new Client()),
                new ManagerMenuItem(platform, null)
            };
        }

        public void Show()
        {
            int i = 1;
            foreach (var item in Items)
            {
                Console.WriteLine($"\t{i++}. {item.Name}");
            }
            Console.WriteLine("\t0. Exit");
            Console.Write("Your choice: ");

            if (Int32.TryParse(Console.ReadLine(), out int idx))
            {
                if (idx != 0)
                {
                    if (idx > 0 && idx <= Items.Count)
                        Items[idx - 1].ShowMenu();
                }
            }
        }
    }
}
