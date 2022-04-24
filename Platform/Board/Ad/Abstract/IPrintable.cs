using System;

namespace DOMRIA
{
    internal interface IPrintable
    {
        void Show(Action<string> action);
    }
}
