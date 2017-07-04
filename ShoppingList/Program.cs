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
        public class shoppingListFormat // Creates a new, custom class to use in a list
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
            var shoppingList = new List<shoppingListFormat>(); // Initialises an empty list with the shoppingListFormat format
            string menuOption; // Define a new string for the users menu option
            string specifiedItem; // Define a new string for the users specified item
            string specifiedSupermarket; // Define a new users specified supermarked
            int count = 0; // Initialises a new integer and sets it to 0
            string stringitemBought; // Define a new users specified item
            bool boolitemBought; // Create a boolean for if the item had been bought
            string stringWillingPrice; // Define a new users specified price
            string stringPriority; // Define a new users specified priority
            string stringQuantity; // Define a new users specified quantity
            double total = 0; // Initialises a new double and sets it to 0
            double priceofItem = 0; // Initialises a new double and sets it to 0

            Console.WriteLine("-=-=-=-=-=-=-"); // Title
            Console.WriteLine("Shopping List"); // Screen
            Console.WriteLine("-=-=-=-=-=-=-");

            while (true) // Infinite loop
            {
                Console.WriteLine("Menu:"); // Displays the menu
                Console.WriteLine("(A)dd items to your shopping list");
                Console.WriteLine("(P)rint items from your shopping list");
                Console.WriteLine("(C)alculate the total of the shopping list");
                Console.WriteLine("E(x)it the program");

                menuOption = Console.ReadLine().ToUpper(); // Stores the users option and capitalises it

                while (menuOption == "A") // While the user is adding items
                {
                    Console.Clear(); // Clear the console
                    Console.WriteLine("Please specify the item that you would like to add (or type 'M' to return to the menu)"); // Ask the user for an item
                    specifiedItem = Console.ReadLine(); // Stores this in a variable
                    if (specifiedItem.ToUpper() == "M") // If the user has entered 'm' or 'M'
                    {
                        menuOption = "M"; // Change the menuOption
                        Console.Clear(); // Clears the console
                    }
                    else // If the user has entered anything else
                    {
                        Console.WriteLine("Please specify where you would like to buy it from"); // Asks the user where they bought it from
                        specifiedSupermarket = Console.ReadLine(); // Stores this in a variable
                        Console.WriteLine("Have you bought the item yet?"); // Asks the user if they bought the item
                        stringitemBought = Console.ReadLine().ToUpper(); // Stores the response in a variable and capitalises it
                        while (stringitemBought != "Y" && stringitemBought != "N") // If the user has not entered 'Y' or 'N'
                        {
                            Console.WriteLine("Please answer with either a 'Y' or 'N'"); // Ask the user to answer correctly
                            stringitemBought = Console.ReadLine().ToUpper(); // Store this in a variable and capitalise it
                        }
                        if (stringitemBought == "Y") // If the item has been bought
                        {
                            boolitemBought = true; // Set the boolean to true
                        }
                        else // If they have entered 'N'
                        {
                            boolitemBought = false; // Set the boolean to false
                        }
                        Console.WriteLine("What is the price you are willing to pay for 1?"); // Ask the user for their desired price
                        stringWillingPrice = Console.ReadLine(); // Store this in a variable
                        stringWillingPrice = Regex.Replace(stringWillingPrice, "[^0-9.]", ""); // Strip everything except numbers and full stops
                        while (stringWillingPrice == "") // While the price is empty
                        {
                            Console.WriteLine("Please specify a maximum price."); // Ask the user to specify a price
                            stringWillingPrice = Console.ReadLine(); // Store this as a variable
                            stringWillingPrice = Regex.Replace(stringWillingPrice, "[^0-9.]", ""); // Strip this of everything except numbers and full stops
                        }
                        Console.WriteLine("What is the priority of the item?"); // Ask the user what the priority is
                        stringPriority = Console.ReadLine(); // Store this as a variable
                        stringPriority = Regex.Replace(stringPriority, "[^0-9]", ""); // Strip this of everything except numbers
                        Console.WriteLine("What is the quantity of the item?"); // Ask for the quantity of the item
                        stringQuantity = Console.ReadLine(); // Store this as a variable
                        stringQuantity = Regex.Replace(stringQuantity, "[^0-9]", ""); // Strip this of everything except numbers
                        shoppingList.Add(new shoppingListFormat // Add all of these values to a list
                        {
                            priority = Int32.Parse(stringPriority), // Priority property of the list is equal to an int parse of stringPriority
                            item = specifiedItem, // Item is equal to specifiedItem
                            supermarket = specifiedSupermarket, // Supermarket is equal to specifiedSupermarket
                            boughtItem = boolitemBought, // boughtItem is equal to boolitemBought
                            willingPrice = Convert.ToDouble(stringWillingPrice), // willingPrice is equal to stringWillingPrice converted to a double
                            quantity = Int32.Parse(stringQuantity) // Quantity is equal to an int parse of stringQuantity
                        });
                    }
                }
                if (menuOption == "P") // If the user wants to print the list
                {
                    Console.Clear(); // Clear the console
                    List<shoppingListFormat> sortedshoppingList = shoppingList.OrderBy(s=>s.priority).ToList(); // Sort the list using the priority property
                    count = 0; // Reset count to 0
                    foreach (var property in sortedshoppingList) // For every property in the sorted list
                    {
                        count++; // Increment the count
                        Console.WriteLine("Item " + count + ": " + property.item); // Print out the item number and the item
                        Console.WriteLine("Priority: " + property.priority); // Print out the priority of the item
                        Console.WriteLine("Buying from: " + property.supermarket); // Print out the supermarket
                        if (property.boughtItem == true) // If the itemBought boolean was true
                        {
                            Console.WriteLine("Item bought: Yes"); // Print that the item was bought
                        }
                        else // If the itemBought boolean was true
                        {
                            Console.WriteLine("Item bought: No"); // Print that the item wasn't bought
                        }
                        Console.WriteLine("Maximum price: £" + property.willingPrice); // Print out the max/desired price
                        Console.WriteLine("Quantity: " + property.quantity); // Prints out the quantity
                        Console.ReadLine(); // Wait for user input
                    }
                    Console.Clear(); // Clear the console
                }
                if (menuOption == "C") // If the user wants to calculate a total
                {
                    total = 0; // Reset the total variable
                    List<shoppingListFormat> sortedshoppingList = shoppingList.OrderBy(s => s.priority).ToList(); // Resort the list in case there have been any changes/if the print option has not been run
                    foreach (var property in sortedshoppingList) // For every property in the sorted list
                    {
                        if (property.boughtItem == true) // If the user has already bought the item
                        {
                            // Do nothing
                        }
                        else // If the user hasn't bought the item
                        {
                            priceofItem = property.quantity * property.willingPrice; // Multiply the quantity by the price and store it in a variable
                            total += priceofItem; // Add this variable onto the total
                        }
                    }
                    Console.WriteLine("Total:"); // Print the total
                    Console.WriteLine("-=-=-=");
                    Console.WriteLine("£" + total);
                    Console.ReadLine(); // Wait for user input
                    Console.Clear(); // Clear the console
                    
                }
                if (menuOption == "X") // If the user has chosen to exit
                {
                    Environment.Exit(9); // Exit with code 9
                }
            }
        }
    }
}

