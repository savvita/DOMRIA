namespace DOMRIA
{
    internal class User
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }

        public User(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public override string ToString() => $"{Name} - {PhoneNumber}";

        public override bool Equals(object obj)
        {
            User tmp = obj as User;

            if (tmp == null)
                return false;

            return Name == tmp.Name && PhoneNumber == tmp.PhoneNumber;
        }

        public override int GetHashCode() => Name.GetHashCode() ^ PhoneNumber.GetHashCode();
    }
}
