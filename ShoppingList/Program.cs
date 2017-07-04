using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList
{
    class Program
    {
        public class shoppingListFormat
        {
            public string item { get; set; }
            public string supermarket { get; set; }
        }

        static void Main(string[] args)
        {
            var shoppingList = new List<shoppingListFormat>();
            string menuOption;
            string specifiedItem;
            string specifiedSupermarket;
            int count = 0;

            Console.WriteLine("-=-=-=-=-=-=-");
            Console.WriteLine("Shopping List");
            Console.WriteLine("-=-=-=-=-=-=-");

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("(A)dd items to your shopping list");
                Console.WriteLine("(P)rint items from your shopping list");

                menuOption = Console.ReadLine().ToUpper();

                while (menuOption == "A")
                {
                    Console.Clear();
                    Console.WriteLine("Please specify the item that you would like to add (or type 'M' to return to the menu)");
                    specifiedItem = Console.ReadLine();
                    if (specifiedItem.ToUpper() == "M")
                    {
                        menuOption = "M";
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Please specify where you would like to buy it from");
                        specifiedSupermarket = Console.ReadLine();

                        shoppingList.Add(new shoppingListFormat
                        {
                            item = specifiedItem,
                            supermarket = specifiedSupermarket
                        });
                    }
                }
                if (menuOption == "P")
                {
                    Console.Clear();
                    count = 0;
                    foreach (var property in shoppingList)
                    {
                        count++;
                        Console.WriteLine("Item " + count + ": " + property.item);
                        Console.WriteLine("Buying from: " + property.supermarket);
                        Console.ReadLine();
                    }
                    Console.Clear();
                }
            }
        }
    }
}
