using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDatabazeProjekt
{
    public class Menu
    {
        private string caption { get; init; }
        private List<MenuVnitrek> menuVnitrek = new List<MenuVnitrek>();

        public Menu(string caption)
        {
            this.caption = caption;
        }
        public void Show()
        {
            Console.WriteLine(caption);
            for (int i = 0; i < menuVnitrek.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menuVnitrek[i]}");
            }
        }

        public MenuItem Selection(int userInput)
        {
            int index = userInput - 1;
            if (index < 0 || index >= menuVnitrek.Count)
            {
                Console.Error.WriteLine($"Index {userInput} is not valid input");
                return null;
            }

            return menuVnitrek[index];
        }

        public MenuVnitrek Selection(string userInput)
        {
            int idx;
            if (!int.TryParse(userInput, out idx))
            {
                Console.Error.WriteLine($"Invalid input '{userInput}'");
                return null;
            }

            return Selection(idx);
        }

        public MenuVnitrek Selection()
        {
            string input = Console.ReadLine();
            Console.WriteLine();
            return Selection(input);
        }

        public MenuVnitrek Execute()
        {
            MenuVnitrek item = null;
            do
            {
                Show();
                item = Selection();
            } while (item == null);

            return item;
        }

        public void Add(MenuVnitrek menuVnitrek)
        {
            this.menuVnitrek.Add(menuVnitrek);
        }
    }
}
