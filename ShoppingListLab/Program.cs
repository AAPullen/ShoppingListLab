using ShoppingListLab;

Dictionary<string, decimal> apothecaryShop = new Dictionary<string, decimal>();
apothecaryShop.Add("Potion", 1.50m);
apothecaryShop.Add("High Potion", 5.25m);
apothecaryShop.Add("X-Potion", 17.95m);
apothecaryShop.Add("Ether", 4.75m);
apothecaryShop.Add("Elixer", 0.55m);
apothecaryShop.Add("Antidote", 2.30m);
apothecaryShop.Add("Echo Herbs", 2.00m);
apothecaryShop.Add("Gold Needle", 3.68m);
apothecaryShop.Add("Remedy", 22.47m);
apothecaryShop.Add("Phoenix Down", 20.15m);

List<string> shoppingList = new List<string>();

string userItem;
bool isOnMenu = false;

Console.WriteLine("Welcome to Magick City of Gariland Apothecary!\n" +
    "Here is a complete list of our inventory:\n");

ShoppingList.MenuItems(apothecaryShop);
bool orderLoop = true;


do
{
    Console.Write("\nWhat item would you like to add to your order?\n" +
        "You may either enter the item name or item number: ");

    userItem = Console.ReadLine().ToLower();


    userItem = ShoppingList.OrderByNumber(userItem, apothecaryShop);
    isOnMenu = ShoppingList.IsOnMenu(userItem, apothecaryShop);

    if (isOnMenu == true)
    {
        shoppingList.Add(ShoppingList.AddToShoppingList(userItem));

        orderLoop = ShoppingList.OrderRepeat();
        
    }
    else
    {
        Console.Write("\nI'm sorry, we don't carry that item.\n");

        orderLoop = ShoppingList.OrderRepeat();
    }

    if (orderLoop == true)
    {
        bool seeMenu = ShoppingList.SeeMenu();
        if (seeMenu == true)
        {
            Console.WriteLine("\nOkay, here is a list of our inventory:\n");
            ShoppingList.MenuItems(apothecaryShop);
        }
        else
        {
            Console.WriteLine("\nOkay.");
        }
    }

} while (orderLoop == true);

Console.WriteLine("\nAlright, so here are the items you would like to purchase:\n");
foreach (string item in shoppingList)
{
    Console.WriteLine(item + " $" + apothecaryShop[item]);
}

decimal total = 0.00m;
foreach(string item in shoppingList)
{
    total += apothecaryShop[item];
}

string thinking = "\n...";
for (int i = 0; i < thinking.Length; i++)
{
    Console.Write(thinking[i]);
    System.Threading.Thread.Sleep(400);
}

Console.WriteLine($"and your total is: ${total}.\n" +
    $"Thanks for shopping with us today! Goodbye!");