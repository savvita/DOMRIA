namespace DOMRIA
{
    internal class FilterByAreaInfo : FilterInfo
    {
        public double MinArea { get; private set; }
        public double MaxArea { get; private set; }

        public FilterByAreaInfo(double minArea, double maxArea)
        {
            MinArea = minArea;
            MaxArea = maxArea;
        }
    }
}
