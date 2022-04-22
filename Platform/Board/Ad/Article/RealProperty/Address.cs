namespace DOMRIA
{
    internal class Address
    {
        public string City { get; private set; }
        public string Street { get; private set; }
        public string House { get; private set; }
        public string App { get; private set; }

        public Address(string city, string street, string house, string app = "")
        {
            City = city;
            Street = street;
            House = house;
            App = app;
        }

        public static Address GetAddressFromString(string str)
        {
            string[] items = str.Split(", ");

            return new Address(items[0], items[1], items[2], items[3]);
        }

        public override string ToString() => string.Format("{0}, {1}, {2}, {3}", City, Street, House, App);
    }
}
