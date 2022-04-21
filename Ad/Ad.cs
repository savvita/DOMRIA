using System;

namespace DOMRIA
{
    internal class Ad
    {
        private static int _id = 0;

        public int ID { get; private set; }
        public string Title { get; private set; }

        public string Description { get; private set; }

        public Address ApAddress { get; private set; }

        public Contact Seller { get; private set; }

        public Apartment SaleApartment { get; private set; }
        public Price TotalPrice { get; private set; }

        public Ad(string title, string description, Address apAddress, Contact seller, Apartment saleApartment, Price price)
        {
            ID = ++_id;
            Title = title;
            Description = description;
            ApAddress = apAddress;
            Seller = seller;
            SaleApartment = saleApartment;
            TotalPrice = price;
        }

        public void Show()
        {
            Show(Console.WriteLine);
        }
        
        public void Show(Action<string> action)
        {
            action($"ID: {ID}");
            action($"Title: {Title}");
            action($"Description: {Description}");
            action("Apartment:");

            SaleApartment.Show(action);

            action($"Address: {ApAddress}");
            action($"Total price : {TotalPrice.USD} $");
            action($"Seller : {Seller}");
        }
    }
}
