using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ShoppingList
{
    class Program
    {
        public class shoppingListFormat
        {
            public int priority { get; set; }
            public string item { get; set; }
            public string supermarket { get; set; }
            public bool boughtItem { get; set; }
            public double willingPrice { get; set; }
            public int quantity { get; set; }
        }

        static void Main(string[] args)
        {
            var shoppingList = new List<shoppingListFormat>();
            string menuOption;
            string specifiedItem;
            string specifiedSupermarket;
            int count = 0;
            string stringitemBought;
            bool boolitemBought;
            string stringWillingPrice;
            string stringPriority;
            string stringQuantity;
            double total = 0;
            double priceofItem = 0;

            Console.WriteLine("-=-=-=-=-=-=-");
            Console.WriteLine("Shopping List");
            Console.WriteLine("-=-=-=-=-=-=-");

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("(A)dd items to your shopping list");
                Console.WriteLine("(P)rint items from your shopping list");
                Console.WriteLine("(C)alculate the total of the shopping list");

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
                        Console.WriteLine("Have you bought the item yet?");
                        stringitemBought = Console.ReadLine().ToUpper();
                        while (stringitemBought != "Y" && stringitemBought != "N")
                        {
                            Console.WriteLine("Please answer with either a 'Y' or 'N'");
                            stringitemBought = Console.ReadLine().ToUpper();
                        }
                        if (stringitemBought == "Y")
                        {
                            boolitemBought = true;
                        }
                        else
                        {
                            boolitemBought = false;
                        }
                        Console.WriteLine("What is the price you are willing to pay for 1?");
                        stringWillingPrice = Console.ReadLine();
                        stringWillingPrice = Regex.Replace(stringWillingPrice, "[^0-9.]", "");
                        while (stringWillingPrice == "")
                        {
                            Console.WriteLine("Please specify a maximum price.");
                            stringWillingPrice = Console.ReadLine();
                            stringWillingPrice = Regex.Replace(stringWillingPrice, "[^0-9.]", "");
                        }
                        Console.WriteLine("What is the priority of the item?");
                        stringPriority = Console.ReadLine();
                        stringPriority = Regex.Replace(stringPriority, "[^0-9]", "");
                        Console.WriteLine("What is the quantity of the item?");
                        stringQuantity = Console.ReadLine();
                        stringQuantity = Regex.Replace(stringQuantity, "[^0-9]", "");
                        shoppingList.Add(new shoppingListFormat
                        {
                            priority = Int32.Parse(stringPriority),
                            item = specifiedItem,
                            supermarket = specifiedSupermarket,
                            boughtItem = boolitemBought,
                            willingPrice = Convert.ToDouble(stringWillingPrice),
                            quantity = Int32.Parse(stringQuantity)
                        });
                    }
                }
                if (menuOption == "P")
                {
                    Console.Clear();
                    List<shoppingListFormat> sortedshoppingList = shoppingList.OrderBy(s=>s.priority).ToList();
                    count = 0;
                    foreach (var property in sortedshoppingList)
                    {
                        count++;
                        Console.WriteLine("Item " + count + ": " + property.item);
                        Console.WriteLine("Priority: " + property.priority);
                        Console.WriteLine("Buying from: " + property.supermarket);
                        if (property.boughtItem == true)
                        {
                            Console.WriteLine("Item bought: Yes");
                        }
                        else
                        {
                            Console.WriteLine("Item bought: No");
                        }
                        Console.WriteLine("Maximum price: £" + property.willingPrice);
                        Console.WriteLine("Quantity: " + property.quantity);
                        Console.ReadLine();
                    }
                    Console.Clear();
                }
                if (menuOption == "C")
                {
                    total = 0;
                    List<shoppingListFormat> sortedshoppingList = shoppingList.OrderBy(s => s.priority).ToList();
                    foreach (var property in sortedshoppingList)
                    {
                        if (property.boughtItem == true)
                        {
                            // Do nothing
                        }
                        else
                        {
                            priceofItem = property.quantity * property.willingPrice;
                            total += priceofItem;
                        }
                    }
                    Console.WriteLine("Total:");
                    Console.WriteLine("-=-=-=");
                    Console.WriteLine("£" + total);
                    Console.ReadLine();
                    Console.Clear();
                    
                }
            }
        }
    }
}

