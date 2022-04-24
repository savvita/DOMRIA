using System;

namespace DOMRIA
{
    internal class FilterByRoomsItem : ClientItem
    {
        public FilterByRoomsItem(Platform platform, Client client) : base ("Filter by count of rooms", platform, client)
        {
            ItemAction = SetFilterByRooms;
        }

        public void SetFilterByRooms()
        {
            Console.Write("Enter a minimum rooms: ");

            if (Int32.TryParse(Console.ReadLine(), out int min))
            {
                Console.Write("Enter a maximum rooms: ");

                if (Int32.TryParse(Console.ReadLine(), out int max))
                {
                    ClientToAct.AddFilter(new MinCountOfRoomsFilter() { Value = min});
                    ClientToAct.AddFilter(new MaxCountOfRoomsFilter() { Value = max});

                    Console.Clear();

                    ClientToAct.ShowFilters();

                    Platform.ShowResults(ClientToAct.SetFilters(PlatformItem.PlatformBoard.GetAds()));
                }
            }
        }
    }
}
