namespace DOMRIA
{
    internal class Address
    {
        public string City { get; private set; }
        public string Street { get; private set; }
        public string House { get; private set; }
        public string App { get; private set; }

        public Address(string city, string street, string house, string app)
        {
            City = city;
            Street = street;
            House = house;
            App = app;
        }
    }
}
