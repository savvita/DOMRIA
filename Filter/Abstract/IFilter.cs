namespace DOMRIA
{
    internal interface IFilter
    {
        public string Name { get; }

        bool Match(Ad ad);
    }
}
