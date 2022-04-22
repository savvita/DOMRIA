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
    }
}
