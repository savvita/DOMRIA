namespace DOMRIA
{
    internal class User
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }

        public User(string name = "", string phoneNumber = "")
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public override string ToString() => $"{Name} - {PhoneNumber}";

        public override bool Equals(object obj)
        {
            if (obj is not User user)
                return false;

            return Name == user.Name && PhoneNumber == user.PhoneNumber;
        }

        public override int GetHashCode() => Name.GetHashCode() ^ PhoneNumber.GetHashCode();
    }
}
