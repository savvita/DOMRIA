using System;

namespace DOMRIA
{
    internal class AdditionalInfo : IPrintable
    {
        public string Name { get; private set; }
        public string Value { get; private set; }

        public AdditionalInfo(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public virtual void Show() => Show(Console.WriteLine);

        public virtual void Show(Action<string> action) => action($"Additional info:\t{Name}: {Value}");

        public static AdditionalInfo GetAdditionalInfoFromString(string str)
        {
            int index = str.IndexOf(':');

            return new AdditionalInfo(str.Substring(0, index - 1), str.Substring(index + 2));
        }
    }
}
