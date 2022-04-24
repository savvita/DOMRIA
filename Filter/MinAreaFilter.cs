namespace DOMRIA
{
    internal class MinAreaFilter : IFilter
    {
        public string Name => "Minimum area";

        public double Value { get; set; }

        bool IFilter.Match(Ad ad)
        {
            RealProperty prop = (ad.Article as RealProperty);

            if (prop == null)
                return false;

            return prop.Unit.TotalArea() >= Value;
        }

        public override string ToString() => $"{Name}: {Value}";
    }
}
