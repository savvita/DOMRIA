using System;
using System.Collections.Generic;

namespace DOMRIA
{
    internal class Apartment
    {
        public List<Room> Rooms { get; private set; }

        public int CountRooms
        {
            get
            {
                return Rooms.Count;
            }
        }

        public Apartment()
        {
            Rooms = new List<Room>();
        }

        public bool AddRoom(Room room)
        {
            if (Rooms.Contains(room))
                return false;

            Rooms.Add(room);

            return true;
        }

        public bool RemoveRoom(Room room) => Rooms.Remove(room);

        public double TotalArea()
        {
            double area = 0;

            foreach (Room room in Rooms)
                area += room.Area;

            return area;
        }

        public virtual void Show() => Show(Console.WriteLine);

        public virtual void Show(Action<string> action)
        {
            action($"Rooms: {CountRooms}");
            action($"Total area: {TotalArea()}");

            foreach (Room room in Rooms)
            {
                action($"Room:\t{room.Name}: {room.Area}");
            }
        }

    }
}
