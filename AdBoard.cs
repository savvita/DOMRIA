using System.Collections.Generic;
using System.IO;

namespace DOMRIA
{
    internal class AdBoard
    {
        public List<Ad> Ads { get; private set; }

        public AdBoard()
        {
            Ads = new List<Ad>();
        }

        public void Add(Ad ad)
        {
            Ads.Add(ad);
        }

        public void Remove(Ad ad)
        {
            Ads.RemoveAll((_ad) => _ad.ID == ad.ID);
        }

        public void Remove(int id)
        {
            Ads.RemoveAll((_ad) => _ad.ID == id);
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
