using System;
using System.Collections.Generic;

namespace DOMRIA
{
    internal class Ad
    {
        private static int _id = 0;

        public int ID { get; private set; }

        public bool IsActual { get; set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public IPrintable Article { get; private set; }

        public Price ArticlePrice { get; private set; }

        public Manager Seller { get; private set; }

        public List<AdditionalInfo> AdditionalData { get; private set; }

        public Ad(string title, string description, IPrintable article, Price price, Manager seller)
        {
            ID = ++_id;
            IsActual = true;
            Title = title;
            Description = description;
            Article = article;
            ArticlePrice = price;
            Seller = seller;

            AdditionalData = new List<AdditionalInfo>();
        }

        public Ad(string title, string description, IPrintable article, Price price, Manager seller, int id) : this(title, description, article, price, seller)
        {
            ID = id;
            _id++;
        }

        public void AddAdditionalData(AdditionalInfo info) => AdditionalData.Add(info);

        public void Show() => Show(Console.WriteLine);
        
        public void Show(Action<string> action)
        {
            action($"ID: {ID}");
            action(String.Format("Status: {0}", IsActual ? "Actual" : "Archive"));
            action($"Title: {Title}");
            action($"Description: {Description}");

            Article.Show(action);

            foreach (var info in AdditionalData)
                info.Show(action);

            action("Price: ");

            ArticlePrice.Show(action);

            action($"Seller: {Seller}");
        }

        public static Ad GetAdFromString(string str)
        {
            int id = 0;
            bool status = true;
            string title = String.Empty;
            string description = String.Empty;
            Apartment ap = new Apartment();
            Address address = null;
            decimal price = 0m;
            Manager seller = null;
            List<AdditionalInfo> infos = new List<AdditionalInfo>();

            Func<string, int, string> GetValue = (string str, int index) => str.Substring(index + 2);

            var lines = str.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                int index = line.IndexOf(':');
                string property = line.Substring(0, index);

                if (property == "ID")
                {
                    id = Convert.ToInt32(GetValue(line, index));
                }
                else if (property == "Status")
                {
                    if (GetValue(line, index) == "Actual")
                        status = true;
                    else
                        status = false;
                }
                else if (property == "Title")
                {
                    title = GetValue(line, index);
                }
                else if (property == "Description")
                {
                    description = GetValue(line, index);
                }
                else if (property == "Room")
                {
                    ap.AddRoom(Room.GetRoomFromString(GetValue(line, index)));
                }
                else if (property == "Address")
                {
                    address = Address.GetAddressFromString(GetValue(line, index));
                }
                else if (property == "USD per meter")
                {
                    index = line.LastIndexOf(':');
                    price = Convert.ToDecimal(GetValue(line, index));
                }
                else if (property == "Additional info")
                {
                    infos.Add(AdditionalInfo.GetAdditionalInfoFromString(GetValue(line, index)));
                }
                else if (property == "Seller")
                {
                    seller = Manager.GetManagerFromString(GetValue(line, index));
                }
            }

            Ad ad = new Ad(title, description, new RealProperty(ap, address), new RealPropertyPrice(price, ap.TotalArea()), seller, id);
            ad.IsActual = status;


            foreach (AdditionalInfo info in infos)
                ad.AddAdditionalData(info);

            return ad;
        }
    }
}
