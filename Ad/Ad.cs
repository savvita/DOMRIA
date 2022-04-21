namespace DOMRIA
{
    internal class Ad
    {
        public string Title { get; private set; }

        public string Description { get; private set; }

        public Address ApAddress { get; private set; }

        public Contact Seller { get; private set; }

        public Apartment SaleApartment { get; private set; }

        public Ad(string title, string description, Address apAddress, Contact seller, Apartment saleApartment)
        {
            Title = title;
            Description = description;
            ApAddress = apAddress;
            Seller = seller;
            SaleApartment = saleApartment;
        }
    }
}
