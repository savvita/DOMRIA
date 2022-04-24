using System;

namespace DOMRIA
{
    internal class FilterByAreaItem : ClientItem
    {
        public FilterByAreaItem(Platform platform, Client client) : base ("Filter by total area", platform, client)
        {
            ItemAction = SetFilterByArea;
        }

        public void SetFilterByArea()
        {
            Console.Write("Enter a minimum area: ");

            if (Double.TryParse(Console.ReadLine(), out double min))
            {
                Console.Write("Enter a maximum area: ");

                if (Double.TryParse(Console.ReadLine(), out double max))
                {

                    ClientToAct.AddFilter(new MinAreaFilter() { Value = min});
                    ClientToAct.AddFilter(new MaxAreaFilter() { Value = max});

                    Console.Clear();

                    ClientToAct.ShowFilters();

                    Platform.ShowResults(ClientToAct.SetFilters(PlatformItem.PlatformBoard.GetAds()));
                }
            }
        }
    }
}
