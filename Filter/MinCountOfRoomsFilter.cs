namespace DOMRIA
{
    internal class MinCountOfRoomsFilter : IFilter
    {
        public string Name => "Minimum count of rooms";

        public int Value { get; set; }

        bool IFilter.Match(Ad ad)
        {
            if (ad.Article is not RealProperty prop)
                return false;

            return prop.Unit.CountRooms >= Value;
        }

        public override string ToString() => $"{Name}: {Value}";
    }
}
