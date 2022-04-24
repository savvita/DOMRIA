using System;

namespace DOMRIA
{
    internal abstract class ClientItem : Item
    {
        protected Client ClientToAct { get; private set; }

        protected ClientItem(string name, Platform platform, Client client, Action itemAction = null): base(name, platform, itemAction)
        {
            ClientToAct = client;
        }
    }
}
