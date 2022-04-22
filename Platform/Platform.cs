using System.Collections.Generic;

namespace DOMRIA
{
    internal class Platform
    {
        public Board PlatformBoard { get; private set; }

        public List<User> Users { get; private set; }

        public Platform()
        {
            PlatformBoard = new Board();
            Users = new List<User>();
        }

        public Platform(Board board)
        {
            PlatformBoard = board;
        }

        public bool AddManager(User user)
        {
            if (Users.FindIndex((_user) => _user.Name == user.Name && _user.PhoneNumber == user.PhoneNumber) != -1)
            {
                return false;
            }

            Users.Add(new Manager(user.Name,user.PhoneNumber, this));

            return true;
        }


        public bool AddClient(User user)
        {
            if (Users.FindIndex((_user) => _user.Name == user.Name && _user.PhoneNumber == user.PhoneNumber) == -1)
            {
                return false;
            }

            Users.Add(new Client(user.Name, user.PhoneNumber));

            return true;
        }
    }
}
