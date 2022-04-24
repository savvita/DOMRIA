namespace DOMRIA
{
    internal class MaxAreaFilter : IFilter
    {
        public string Name => "Maximum area";

        public double Value { get; set; }

        bool IFilter.Match(Ad ad)
        {
            RealProperty prop = (ad.Article as RealProperty);

            if (prop == null)
                return false;

            return prop.Unit.TotalArea() <= Value;
        }

        public override string ToString() => $"{Name}: {Value}";
    }
}
