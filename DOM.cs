namespace DOMRIA
{
    internal class DOM : Platform
    {
        public DOM() :base()
        {
            AddManager(new User("John Smith", "+380565555555"));
            AddManager(new User("Jane Doe", "+380564444444"));

            Apartment ap = new Apartment();
            ap.AddRoom(new Kitchen(6.0));
            ap.AddRoom(new Bedroom(16.0));
            ap.AddRoom(new Bathroom(5.2));

            Address address = new Address("Dnepr", "KM", "12", "8a");

            RealProperty prop = new RealProperty(ap, address);

            (Users[0] as Manager)?.Add("Sell", "Fine apartment", prop, new RealPropertyPrice(100, ap.TotalArea()));
            (Users[1] as Manager)?.Add("Sell", "Very fine apartment", prop, new RealPropertyPrice(150, ap.TotalArea()));

            Apartment ap2 = new Apartment();
            ap2.AddRoom(new Kitchen(16.0));
            ap2.AddRoom(new Bedroom(58.0));
            ap2.AddRoom(new Bathroom(12.2));
            ap2.AddRoom(new Bathroom(25.2));

            Address address2 = new Address("Dnepr", "Street", "18", "1");

            RealProperty prop2 = new RealProperty(ap2, address2);

            (Users[0] as Manager)?.Add("Sell", "Something cool", prop2, new RealPropertyPrice(500, ap2.TotalArea()));

            Apartment ap3 = new Apartment();
            ap3.AddRoom(new Kitchen(2.0));

            Address address3 = new Address("Dnepr", "Street", "18", "1");

            RealProperty prop3 = new RealProperty(ap3, address3);

            (Users[1] as Manager)?.Add("Sell", "Something strange", prop3, new RealPropertyPrice(10, ap3.TotalArea()));
        }
    }
}
