using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DOMRIA
{
    internal class Board
    {
        private readonly List<Ad> Ads;

        public Board()
        {
            Ads = new List<Ad>();
        }

        public IEnumerable<Ad> GetAds(User caller = null)
        {
            if (caller is Manager)
                return Ads.Where((ad) => ad.Seller.Equals(caller));;

            return Ads.Where((ad) => ad.IsActual == true);
        }

        public void Add(Ad ad) => Ads.Add(ad);

        public void Save(string path = "ads.txt")
        {
            if (File.Exists(path))
                File.Delete(path);

            foreach (Ad ad in Ads)
            {
                ad.Show((str) => File.AppendAllText(path, $"{str}\n"));
                File.AppendAllText(path, $"{new string('=', 15)}\n");
            }
        }

        public bool Load(string path = "ads.txt")
        {
            if (!File.Exists(path))
                return false;

            try
            {
                Ads.Clear();

                string str = File.ReadAllText(path);

                var ads = str.Split(new string('=', 15) + '\n', System.StringSplitOptions.RemoveEmptyEntries);

                foreach (string ad in ads)
                {
                    Ads.Add(Ad.GetAdFromString(ad));
                }
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}
