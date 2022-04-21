namespace DOMRIA
{
    internal class Contact
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }

        public Contact(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
