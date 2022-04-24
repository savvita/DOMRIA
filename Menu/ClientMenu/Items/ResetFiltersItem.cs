namespace DOMRIA
{
    internal class ResetFiltersItem : ClientItem
    {
        public ResetFiltersItem(Platform platform, Client client) : base ("Reset all Filters", platform, client)
        {
            ItemAction = ResetFilters;
        }

        public void ResetFilters()
        {
            ClientToAct.ClearFilters();

            Platform.ShowResults(ClientToAct.SetFilters(PlatformItem.PlatformBoard.GetAds()));
        }
    }
}
