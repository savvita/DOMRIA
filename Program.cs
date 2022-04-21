using System;

namespace DOMRIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdBoard board = new AdBoard();

            Apartment ap = new Apartment();
            ap.AddRoom(new Room("Kitchen", 6.0));
            ap.AddRoom(new Room("Bathroom", 3.0));
            ap.AddRoom(new Room("Bedroom", 15.0));

            board.Add(new Ad("Sell something", "Some description", new Address("Dnepr", "KM", "12", ""), new Contact("John", ""), ap, new Price(100, ap.TotalArea())));
            board.Add(new Ad("Sell something again", "No description", new Address("Dnepr", "KM", "12", ""), new Contact("Smith", "0000"), ap, new Price(200, ap.TotalArea())));

            foreach (Ad ad in board.Ads)
            {
                ad.Show();
                Console.WriteLine(new string('=', 20));
            }

            board.Save();
        }
    }
}
