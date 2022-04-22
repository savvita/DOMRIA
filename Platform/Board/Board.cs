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

        public List<Ad> GetAds(User caller = null)
        {
            if (caller is Manager)
                return Ads;

            return Ads.Where((ad) => ad.IsActual == true).ToList();
        }

        public void Save(string path = "ads.txt")
        {
            if (File.Exists(path))
                File.Delete(path);

            foreach (Ad ad in Ads)
                ad.Show((str) => File.AppendAllText(path, $"{str}\n"));
        }
    }
}
