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
