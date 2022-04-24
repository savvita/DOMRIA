namespace DOMRIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DOM dom = new DOM();

            PlatformMenu menu = new PlatformMenu(dom);
            menu.Show();
        }
    }
}
