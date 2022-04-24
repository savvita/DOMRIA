using System;

namespace DOMRIA
{
    internal class Room
    {
        public string Name { get; private set; }
        public double Area { get; private set; }

        public Room(string name, double area)
        {
            Name = name;
            Area = area >= 0 ? area : throw new Exception("Area cannot be less than or equal zero");
        }

        public static Room GetRoomFromString(string str)
        {
            int index = str.IndexOf(':');
            string property = str[..index];

            double area = Convert.ToDouble(str[(index + 2)..]);

            Room room = property switch
            {
                "Kitchen" => new Kitchen(area),
                "Bedroom" => new Bedroom(area),
                "Bathroom" => new Bathroom(area),
                _ => new Room(property, area),
            };

            return room;
        }

        public override bool Equals(object obj)
        {
            if (obj is Room room)
            {
                return room.Name == Name && room.Area == Area;
            }

            return false;
        }

        public override int GetHashCode() => Name.GetHashCode() ^ Area.GetHashCode();
    }
}
