using System;
using System.Collections.Generic;

namespace DOMRIA
{
    internal abstract class Item
    {
        public string Name { get; private set; }
        protected Platform PlatformItem { get; private set; }

        public List<Item> Items { get; protected set; }

        public Action ItemAction { get; protected set; }

        protected Item(string name, Platform platform, Action itemAction = null)
        {
            Name = name;
            PlatformItem = platform;
            ItemAction = itemAction;
            Items = new List<Item>();
        }
        public Item this[int index]
        {
            get
            {
                if (index >= 0 && index < Items.Count)
                    return Items[index];

                return null;
            }
        }

        public virtual void Show()
        {
            int i = 1;
            foreach (var item in Items)
            {
                Console.WriteLine($"\t{i++}. {item.Name}");
            }
        }
    }
}
