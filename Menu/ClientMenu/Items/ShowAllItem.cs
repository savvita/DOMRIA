namespace DOMRIA
{
    internal class ShowAllItem : ClientItem
    {
        public ShowAllItem(Platform platform, Client client) : base ("Show all ads", platform, client)
        {
            ItemAction = ShowAll;
        }

        public void ShowAll() => Platform.ShowResults(PlatformItem.PlatformBoard.GetAds(ClientToAct));
    }
}
