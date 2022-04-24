using System;

namespace DOMRIA
{
    internal abstract class ManagerItem : Item
    {
        protected Manager ManagerToAct;

        protected ManagerItem(string name, Platform platform, Manager manager, Action itemAction = null): base(name, platform, itemAction)
        {
            ManagerToAct = manager;
        }
    }
}
