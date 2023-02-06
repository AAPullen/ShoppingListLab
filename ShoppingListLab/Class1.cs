using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListLab
{
    public static class ShoppingList
    {
        public static void MenuItems(Dictionary<string, decimal> menu)
        { 
            int i = 1;
            foreach (var item in menu)
            {
                Console.Write($"{i}. {item.Key}: $"); 
                foreach (var price in item.Value.ToString())
                {
                    Console.Write($"{price}");
                }
                Console.WriteLine();
                i++;
            }
        }

        public static bool IsOnMenu(string item, Dictionary<string, decimal> menu)
        {
            List<string> menuItems = GetItemsOnMenu(menu);

            if (menuItems.Contains(item))
            {
                return true;
            }
            return false;
        }

        public static string OrderByNumber(string userItem, Dictionary<string, decimal> menu)
        {
            try
            {
                List<string> menuItems = GetItemsOnMenu(menu);
                int index = int.Parse(userItem) - 1;
                userItem = menuItems[index];
                return userItem;
            }
            catch (Exception)
            {
                return userItem;
            }
        }    

        public static List<string> GetItemsOnMenu(Dictionary<string, decimal> menu)
        {
            List<string> menuItems = new List<string>(menu.Keys);
            for (int i = 0; i < menuItems.Count; i++)
            {
                menuItems[i] =  menuItems[i].ToLower();
            }
            return menuItems;

        }

        public static string AddToShoppingList(string userItem)
        {
            string[] splitItem = userItem.Split(' ');
            for (int i = 0; i < splitItem.Length; i++)
            {
                char[] letters = splitItem[i].ToCharArray();
                letters[0] = char.ToUpper(letters[0]);
                string capitalItem = null;
                for (int j = 0; j < letters.Length; j++)
                {
                    capitalItem = capitalItem + letters[j];
                }
                splitItem[i] = capitalItem;
            }
            
            string userKey = string.Join(' ', splitItem);

            if (userKey == "X-potion")
            {
                userKey = "X-Potion";
            }

            return userKey;
        }

        public static bool OrderRepeat()
        {
            while (true)
            {
                Console.Write("\nWould you like to continue shopping (y/n)? ");
                string answer = Console.ReadLine().ToLower();

                if (answer == "y")
                {
                    return true;
                }
                else if (answer == "n") 
                {
                    return false;
                }
                else if (answer != "y" && answer != "n") 
                {
                    Console.WriteLine("\nI'm sorry, that is not a valid response.");
                }
            }
        }
        public static bool SeeMenu()
        {
            while (true)
            {
                Console.Write("\nWould you like to see a list of our inventory again (y/n)? ");
                string answer = Console.ReadLine().ToLower();

                if (answer == "y")
                {
                    return true;
                }
                else if (answer == "n")
                {
                    return false;
                }
                else if (answer != "y" && answer != "n")
                {
                    Console.WriteLine("\nI'm sorry, that is not a valid response.");
                }
            }
        }
    }
}
