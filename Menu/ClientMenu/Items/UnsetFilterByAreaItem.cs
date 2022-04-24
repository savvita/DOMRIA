using System;

namespace DOMRIA
{
    internal class UnsetFilterByAreaItem : ClientItem
    {
        public UnsetFilterByAreaItem(Platform platform, Client client) : base ("Unset filter by total area", platform, client)
        {
            ItemAction = UnsetFilter;
        }
        public void UnsetFilter()
        {
            ClientToAct.RemoveFilter(new MaxAreaFilter());
            ClientToAct.RemoveFilter(new MinAreaFilter());

            ClientToAct.ShowFilters();

            Platform.ShowResults(ClientToAct.SetFilters(PlatformItem.PlatformBoard.GetAds()));
        }
    }
}
