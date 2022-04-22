using System;

namespace DOMRIA
{
    internal class RealPropertyPrice : Price
    {
        public decimal USDperM { get; private set; }

        public RealPropertyPrice(decimal USDperM, double area) : base(USDperM * (decimal)area)
        {
            this.USDperM = USDperM;
        }

        public override void Show(Action<string> action)
        {
            base.Show(action);
            action($"USD per meter: {USDperM}");
        }
    }
}
