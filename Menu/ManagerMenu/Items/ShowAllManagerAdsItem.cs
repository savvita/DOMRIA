namespace DOMRIA
{
    internal class ShowAllManagerAdsItem : ManagerItem
    {
        public ShowAllManagerAdsItem(Platform platform, Manager manager) : base ("Show all ads this manager", platform, manager)
        {
            ItemAction = ShowAll;
        }

        public void ShowAll() => Platform.ShowResults(PlatformItem.PlatformBoard.GetAds(ManagerToAct));
    }
}
