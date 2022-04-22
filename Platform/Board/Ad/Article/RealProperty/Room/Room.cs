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
            Room room = null;

            int index = str.IndexOf(':');
            string property = str.Substring(0, index);

            double area = Convert.ToDouble(str.Substring(index + 2));

            switch(property)
            {
                case "Kitchen":
                    room = new Kitchen(area);
                    break;

                case "Bedroom":
                    room = new Bedroom(area);
                    break;

                case "Bathroom":
                    room = new Bathroom(area);
                    break;

                default:
                    room = new Room(property, area);
                    break;
            }

            return room;
        }

        public override bool Equals(object obj)
        {
            var tmp = obj as Room;

            if(tmp != null)
            {
                return tmp.Name == Name && tmp.Area == Area;
            }

            return false;
        }

        public override int GetHashCode() => Name.GetHashCode() ^ Area.GetHashCode();
    }
}
