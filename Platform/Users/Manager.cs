using System.Collections.Generic;
using System.Linq;

namespace DOMRIA
{
    internal class Manager : User
    {
        private readonly Platform RegisteredPlatform;
        private readonly IEnumerable<Ad> Ads;

        public Manager(string name, string phoneNumber, Platform platform  = null) : base(name, phoneNumber)
        {
            RegisteredPlatform = platform;

            if(RegisteredPlatform != null)
                Ads = RegisteredPlatform.PlatformBoard.GetAds(this).Where((ad) => ad.Seller.Name == Name && ad.Seller.PhoneNumber == PhoneNumber);
        }

        public static Manager GetManagerFromString(string str)
        {
            int index = str.IndexOf('-');

            return new Manager(str.Substring(0, index - 1), str.Substring(index + 2));
        }

        public List<Ad> GetAds()
        {
            return Ads.ToList();
        }

        public bool Add(string title, string description, IPrintable article, Price price)
        {
            if (RegisteredPlatform == null)
                return false;

            try
            {
                RegisteredPlatform.PlatformBoard.GetAds(this).Add(new Ad(title, description, article, price, this));
            }
            catch(System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        public bool ToArchive(Ad ad)
        {
#nullable enable 
            Ad? toArchive = Find(ad.ID);

            if (toArchive == null)
                return false;

            toArchive.IsActual = false;

            return true;
        }
#nullable disable

        public bool FromArchive(Ad ad)
        {
#nullable enable
            Ad? toArchive = Find(ad.ID);

            if (toArchive == null)
                return false;

            toArchive.IsActual = true;

            return true;
#nullable disable
        }

        public Ad Find(int id) =>  Ads.FirstOrDefault((_ad) => _ad.ID == id);
    }
}
