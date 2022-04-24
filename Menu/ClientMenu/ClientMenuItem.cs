using System.Collections.Generic;

namespace DOMRIA
{
    internal class ClientMenuItem : ClientItem, IMenu
    {
        public ClientMenuItem(Platform platform, Client client) : base("Continue as a user", platform, client)
        {
            Items = new List<Item>
            {
                new ShowAllItem(platform, client),
                new FilterByRoomsItem(platform, client),
                new FilterByAreaItem(platform, client),
                new UnsetFilterByRoomsItem(platform, client),
                new UnsetFilterByAreaItem(platform, client),
                new ResetFiltersItem(platform, client)
            };

            ItemAction = null;
        }

        public void ShowMenu() => new Menu(this).Show();
    }
}
