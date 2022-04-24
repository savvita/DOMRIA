using System;

namespace DOMRIA
{
    internal class AddAdItem : ManagerItem
    {
        public AddAdItem(Platform platform, Manager manager) : base("Add an ad", platform, manager)
        {
            ItemAction = Add;
        }

        public void Add()
        {
            Console.Write("Enter a title: ");
            string title = Console.ReadLine();

            Console.Write("Enter a desciption: ");
            string desciption = Console.ReadLine();

            try
            {

                Apartment ap = new Apartment();

                do
                {
                    Console.Write("Add a room? (y/n) ");
                    string ch = Console.ReadLine();

                    if (ch.ToLower() == "y")
                    {
                        AddRoom(ap);
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                Console.WriteLine("Address:");

                Address address = GetAddress();

                Console.Write("Enter a price ($ per meter): ");

                decimal price = Decimal.Parse(Console.ReadLine());

                if (ManagerToAct.Add(title, desciption, new RealProperty(ap, address), new RealPropertyPrice(price, ap.TotalArea())))
                    Console.WriteLine("Added...");
                else
                    Console.WriteLine("Error");
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
        }

        private static void AddRoom(Apartment ap)
        {
            Console.WriteLine("1 - Kitchen");
            Console.WriteLine("2 - Bedroom");
            Console.WriteLine("3 - Bathroom");
            Console.WriteLine("4 - Other");

            int i = Convert.ToInt32(Console.ReadLine());

            if (i < 1 || i > 4)
                return;

            string name = String.Empty;

            if (i == 4)
            {
                Console.Write("Name: ");
                name = Console.ReadLine();
            }
            Console.Write("Area: ");
            double area = Convert.ToDouble(Console.ReadLine());

            switch(i)
            {
                case 1:
                    ap.AddRoom(new Kitchen(area));
                    break;

                case 2:
                    ap.AddRoom(new Bedroom(area));
                    break;

                case 3:
                    ap.AddRoom(new Bathroom(area));
                    break;

                case 4:
                    ap.AddRoom(new Room(name, area));
                    break;
            }
        }

        private static Address GetAddress()
        {
            Console.Write("City: ");
            string city = Console.ReadLine();

            Console.Write("Street: ");
            string street = Console.ReadLine();

            Console.Write("House: ");
            string house = Console.ReadLine();

            Console.Write("Apartment: ");
            string ap = Console.ReadLine();

            return new Address(city, street, house, ap);
        }

    }
}
