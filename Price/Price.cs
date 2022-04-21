namespace DOMRIA
{
    internal class Price
    {
        public decimal Rate { get; private set; } 
        public decimal USDperM { get; private set; }

        public decimal USD { get; private set; }
        public decimal UAH { get; private set; }

        public Price(decimal USDperM, double area)
        {
            Rate = 29.5m;

            this.USDperM = USDperM;
            USD = USDperM * (decimal)area;
            UAH = USD * Rate;
        }
    }
}
