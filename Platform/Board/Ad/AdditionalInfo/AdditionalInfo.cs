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
    }
}
