using System;

namespace DOMRIA
{
    internal class RealProperty : IPrintable
    {
        public Apartment Unit { get; private set; }
        public Address PropertyAddress { get; private set; }

        public RealProperty(Apartment apartment, Address address)
        {
            Unit = apartment;
            PropertyAddress = address;
        }

        public virtual void Show() => Show(Console.WriteLine);

        public virtual void Show(Action<string> action)
        {
            Unit.Show(action);
            action($"Address: {PropertyAddress}");
        }

    }
}
