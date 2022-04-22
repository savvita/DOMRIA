namespace DOMRIA
{
    internal class FilterByRoomsInfo : FilterInfo
    {
        public int MinRooms { get; private set; }
        public int MaxRooms { get; private set; }

        public FilterByRoomsInfo(int minRooms, int maxRooms)
        {
            MinRooms = minRooms;
            MaxRooms = maxRooms;
        }
    }
}
