using System;

namespace DOMRIA
{
    internal class UnsetFilterByRoomsItem : ClientItem
    {
        public UnsetFilterByRoomsItem(Platform platform, Client client) : base ("Unset filter by count of rooms", platform, client)
        {
            ItemAction = UnsetFilter;
        }

        public void UnsetFilter()
        {
            ClientToAct.RemoveFilter(new MinCountOfRoomsFilter());
            ClientToAct.RemoveFilter(new MaxCountOfRoomsFilter());

            ClientToAct.ShowFilters();

            Platform.ShowResults(ClientToAct.SetFilters(PlatformItem.PlatformBoard.GetAds()));
        }
    }
}
