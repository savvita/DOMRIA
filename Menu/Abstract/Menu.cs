using System;

namespace DOMRIA
{
    internal class Menu
    {
        private readonly Item item;
        public Menu Previous { get; private set; }

        private Menu(Item item, Menu prev)
        {
            this.item = item;
            Previous = prev;
        }

        public Menu(Item item) : this(item, null)
        {
        }

        public void Show() => Show(null);

        private void Show(Menu prev)
        {
            Console.Clear();

            if (item == null)
            {
                if (prev != null)
                {
                    prev.Show(prev.Previous);
                }
                else
                {
                    return;
                }

            }

            else
            {
                item.Show();
                Console.WriteLine("\t0. Exit");
                Console.Write("Your choise: ");

                if (Int32.TryParse(Console.ReadLine(), out int i))
                {

                    if (i != 0)
                    {
                        if (item[i - 1] == null)
                            Show(this);

                        else if (item[i - 1].ItemAction != null)
                        {
                            Console.Clear();
                            item[i - 1].ItemAction.Invoke();
                            Console.ReadLine();

                            if (prev != null)
                                prev.Show(prev.Previous);
                            else
                                Show(this);
                        }

                        else
                            (new Menu(item[i - 1], this)).Show(this);

                    }
                    else
                    {
                        if (prev != null)
                        {
                            prev.Show(prev.Previous);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    Show(prev);
                }
            }

        }
    }
}
