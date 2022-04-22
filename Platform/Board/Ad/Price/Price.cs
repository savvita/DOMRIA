using System;

namespace DOMRIA
{
    internal class Price : IPrintable
    {
        public decimal Rate { get; private set; }

        public decimal TotalUSD { get; private set; }
        public decimal TotalUAH { get; private set; }

        public Price(decimal totalUSD)
        {
            Rate = 29.5m;
            TotalUSD = totalUSD;
            TotalUAH = TotalUSD * Rate;
        }

        public virtual void Show() => Show(Console.WriteLine);

        public virtual void Show(Action<string> action) => action($"USD: {TotalUSD}\tUAH: {TotalUAH}");
    }
}
