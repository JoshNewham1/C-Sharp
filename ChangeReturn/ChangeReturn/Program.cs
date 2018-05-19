using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChangeReturn
{
    class Program
    {
        private static List<double> currencyDenominations = new List<double>();
        private static List<int> denominationsList = new List<int>();
        private static double doubleChange;
        static void Main(string[] args)
        {
            string stringCost;
            double doubleCost;
            string stringMoneyGiven;
            double doubleMoneyGiven;
            string seeSummary;
            string menuOption;
            string headlessMode;
            double minRndNumber;
            double maxRndNumber;
            double doubleTotal = 0;

            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Josh's Change Return Program");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

            while (true)
            {
                Console.WriteLine("-=-=");
                Console.WriteLine("Menu");
                Console.WriteLine("-=-=");
                Console.WriteLine("Calculate the change return in (UK) currency");
                Console.WriteLine("Calculate the change return in (US) currency");
                Console.WriteLine("Perform a (s)elf-check");
                Console.WriteLine("E(x)it the program");
                menuOption = Console.ReadLine().ToUpper(); // Reads in the option the user has chosen and converts it to uppercase

                while (menuOption == "UK") // If the user chose to calculate change return in GBP
                {
                    Console.WriteLine("What is the cost of the item? Type 'M' to return to the menu"); // Asks the user the cost of the item
                    stringCost = Console.ReadLine(); // Stores response as string
                    if (stringCost.ToUpper() == "M") // If the input is 'M'
                    {
                        menuOption = "M"; // Return to menu
                    }
                    else
                    {
                        stringCost = Regex.Replace(stringCost, "[^0-9.]", ""); // Strips everything out except numbers and full stops
                        while (stringCost == "") // While the user has entered nothing
                        {
                            Console.WriteLine("Please specify a cost."); // Ask the user to specify a cost
                            stringCost = Console.ReadLine(); // Reads this into a variable
                            stringCost = Regex.Replace(stringCost, "[^0-9.]", ""); // Strips everything out except numbers and full stops
                        }
                        doubleCost = Convert.ToDouble(stringCost); // Converts the string to a double
                        Console.WriteLine("How much money have you given?"); // Asks the user how much money they have given
                        stringMoneyGiven = Console.ReadLine(); // Reads this into a string
                        stringMoneyGiven = Regex.Replace(stringMoneyGiven, "[^0-9.]", ""); // Strips everything out except numbers and full stops
                        while (stringMoneyGiven == "") // While the user has entered nothing
                        {
                            Console.WriteLine("Please specify how much money you have given."); // Ask the user to specify money given
                            stringMoneyGiven = Console.ReadLine(); // Reads this into a variable
                            stringMoneyGiven = Regex.Replace(stringMoneyGiven, "[^0-9.]", ""); // Strips everything out except numbers and full stops
                        }
                        doubleMoneyGiven = Convert.ToDouble(stringMoneyGiven); // Converts the string to a double
                        doubleChange = Math.Round(doubleMoneyGiven - doubleCost, 2); // Calculate the change by taking away the money given from the cost and rounding it to 2 decimal places
                        Console.WriteLine("Change: " + doubleChange); // Prints the user's change
                        Console.WriteLine("Would you like to see all of the coins/notes that are required?"); // Asks the user if they want to see the coins/notes required
                        seeSummary = Console.ReadLine().ToUpper(); // Stores the user response and converts it to uppercase
                        if (seeSummary == "Y") // If the user wants to see the summary
                        {
                            Console.Clear(); // Clear the console
                            FillListUK(); // Call the FillListUK method
                            CountChange(); // Call the CountChange method
                            PrintChangeUK(); // Call the PrintChangeUK method
                            Console.ReadLine(); // Waits for user input
                            Console.Clear(); // Clears the console
                        }
                        else // If the user doesn't want to see the summary
                        {
                            Console.Clear(); // Clears the console
                        }
                    }

                }
                while (menuOption == "US") // If the user chose to calculate change return in USD
                {
                    Console.WriteLine("What is the cost of the item? Type 'M' to return to the menu"); // Asks the user the cost of the item
                    stringCost = Console.ReadLine(); // Stores response as string
                    if (stringCost.ToUpper() == "M") // If the input is 'M'
                    {
                        menuOption = "M"; // Return to menu
                    }
                    else
                    {
                        stringCost = Regex.Replace(stringCost, "[^0-9.]", ""); // Removes any special characters leaving just numbers
                        while (stringCost == "") // Strips everything out except numbers and full stops
                        {
                            Console.WriteLine("Please specify a cost."); // Ask the user to specify a cost
                            stringCost = Console.ReadLine(); // Reads this into a variable
                            stringCost = Regex.Replace(stringCost, "[^0-9.]", ""); // Strips everything out except numbers and full stops
                        }
                        doubleCost = Convert.ToDouble(stringCost); // Converts the string to a double
                        Console.WriteLine("How much money have you given?"); // Asks the user how much money they have given
                        stringMoneyGiven = Console.ReadLine();
                        stringMoneyGiven = Regex.Replace(stringMoneyGiven, "[^0-9.]", ""); // Removes any special characters leaving just numbers
                        while (stringMoneyGiven == "") // While the user has entered nothing
                        {
                            Console.WriteLine("Please specify how much money you have given."); // Ask the user to specify money given
                            stringMoneyGiven = Console.ReadLine(); // Reads this into a variable
                            stringMoneyGiven = Regex.Replace(stringMoneyGiven, "[^0-9.]", ""); // Strips everything out except numbers and full stops
                        }
                        doubleMoneyGiven = Convert.ToDouble(stringMoneyGiven); // Converts the string to a double
                        doubleChange = Math.Round(doubleMoneyGiven - doubleCost, 2); // Calculate the change by taking away the money given from the cost and rounding it to 2 decimal places
                        Console.WriteLine("Change: " + doubleChange); // Prints the user's change
                        Console.WriteLine("Would you like to see all of the coins/notes that are required?"); // Asks the user if they want to see the coins/notes required
                        seeSummary = Console.ReadLine().ToUpper(); // Stores the user response and converts it to uppercase
                        if (seeSummary == "Y") // If the user wants to see the summary
                        {
                            Console.Clear(); // Clear the console
                            FillListUS(); // Call the FillListUS method
                            CountChange(); // Call the CountChange method
                            PrintChangeUS(); // Call the PrintChangeUS method
                            Console.ReadLine(); // Wait for user input
                            Console.Clear(); // Clear the console
                        }
                        else // If the user does not want to see the summary
                        {
                            Console.Clear(); // Clear the console
                        }
                    }
                }
                while (menuOption == "S") // If the user wants to perform a self-test
                {
                    Console.WriteLine("Headless mode? (Y) or (N)"); // Asks the user if they would like it headless (verbose)
                    headlessMode = Console.ReadLine().ToUpper(); // Stores the response and converts it to uppercase
                    Console.WriteLine("To exit the self-test, press Ctrl-C. NOTE: This only works when the program is not run using debugging"); // Tells the user how to quit and that quitting will not work if it is ran under debugging (in Visual Studio)
                    Console.ReadLine(); // Wait for user input
                    Console.CancelKeyPress += delegate // If Ctrl-C or Ctrl-Break are pressed quit
                    {
                    };
                    while (true) // Loops forever unless interrupted by Ctrl-C
                    {
                        minRndNumber = 1; // Sets minRndNumber to 1 (these values can be changed)
                        maxRndNumber = 100000; // Sets maxRndNumber to 100000 (these values can be changed)
                        doubleChange = 0; // Resets the value of change
                        doubleTotal = 0; // Resets the total
                        Random rnd = new Random(); // Initiates an instance of the Random class
                        doubleCost = Math.Round(rnd.NextDouble(), 2) * maxRndNumber; // Takes a random double from 0.0 to 1.0 and multiplies it by the maxRndNumber
                        minRndNumber = minRndNumber + doubleCost; // Add the cost on to the minRndNumber so it doesn't pick a value too low
                        doubleMoneyGiven = Math.Round(rnd.NextDouble(), 2) * maxRndNumber; // Takes a random double from 0.0 to 1.0 and multiplies it by the maxRndNumber
                        doubleChange = Math.Round(doubleMoneyGiven - doubleCost, 2); // Works out the change to 2 decimal places
                        if (doubleChange < 0) // If the change is a negative number
                        {
                            Console.Clear(); // Clear the console
                            Console.WriteLine("Error: The change is a negative number (" + doubleChange + ")"); // Tell the user the error and the number it failed on
                            Console.WriteLine("Press enter to continue..."); // Tells the user to press enter to continue
                            Console.ReadLine(); // Waits for user input
                        }
                        FillListUK(); // Calls the FillListUK method
                        CountChange(); // Calls the CountChange method
                        for (int i = 0; i < denominationsList.Count; i++) // For every item in the denominationsList
                        {
                            doubleTotal = Math.Round(doubleTotal + (denominationsList[i] * currencyDenominations[i]), 2); // Multiply it by the correct denomination and add it to a total
                        }
                        doubleChange = Math.Round(doubleMoneyGiven - doubleCost, 2); // doubleChange is set to 0 in the CountChange method so needs recalculating
                        if (doubleTotal != doubleChange) // If the total of all the coins/notes is not equal to the change calculated from the numbers
                        {
                            Console.Clear(); // Clear the console
                            Console.WriteLine("Error: The total of the change does not equal the change calculated (" + doubleTotal + " != " + doubleChange + ")"); // Tells the user the error and the two different numbers
                            Console.WriteLine("Press enter to continue..."); // Tells the user to press enter to continue
                            Console.ReadLine(); // Waits for user input
                        }
                        if (headlessMode == "N") // If the user wants to run verbosely
                        {
                            PrintChangeUK(); // Print the change
                            Console.ReadLine(); // Wait for user input
                        }
                    }

                }
                if (menuOption == "X") // If the user has chosen to quit
                {
                    Environment.Exit(9); // Quit with error code 9
                }
            }

        }

        public static void CountChange() // CountChange Method
        {
            denominationsList.Clear(); // Clear the denominations list from last use
            for (int i = 0; i < currencyDenominations.Count; i++) // For every currency denomination (e.g £50, £20 etc.)
            {
                if (doubleChange > 0) // If change is larger than 0 (not negative)
                {
                    doubleChange = Math.Round(doubleChange, 2); // Round the change to two decimal places before any calculations
                    double currencyDivisions = doubleChange / currencyDenominations[i]; // Divide the change by the denominations
                    currencyDivisions = Math.Floor(currencyDivisions); // Round down
                    int currencyDivisionsRounded = Convert.ToInt32(currencyDivisions); // Convert this to an integer
                    if (currencyDivisions >= 1) // If the division was larger or equal to 1 denomination
                    {
                        denominationsList.Add(currencyDivisionsRounded); // Add it to the final list
                        doubleChange = doubleChange - Math.Round(currencyDivisionsRounded * currencyDenominations[i], 2); // Take it away from the remaining change
                    }
                    else // If it is smaller than 1
                    {
                        denominationsList.Add(0); // Add 0 to its place
                    }

                }
                else // If it is negative
                {
                    denominationsList.Add(0); // Add 0 to its place
                }

            }
        }

        public static void PrintChangeUK() // PrintChangeUK method
        {
            Console.WriteLine("-=-=-=-");
            Console.WriteLine("Change:");
            Console.WriteLine("-=-=-=-");
            Console.WriteLine("£50 notes: " + denominationsList[0]); // Prints the UK denomination to the screen
            Console.WriteLine("£20 notes: " + denominationsList[1]); // Prints the UK denomination to the screen
            Console.WriteLine("£10 notes: " + denominationsList[2]); // Prints the UK denomination to the screen
            Console.WriteLine("£5 notes: " + denominationsList[3]); // Prints the UK denomination to the screen
            Console.WriteLine("£2 coins: " + denominationsList[4]); // Prints the UK denomination to the screen
            Console.WriteLine("£1 coins: " + denominationsList[5]); // Prints the UK denomination to the screen
            Console.WriteLine("50p coins: " + denominationsList[6]); // Prints the UK denomination to the screen
            Console.WriteLine("20p coins: " + denominationsList[7]); // Prints the UK denomination to the screen
            Console.WriteLine("10p coins: " + denominationsList[8]); // Prints the UK denomination to the screen
            Console.WriteLine("5p coins: " + denominationsList[9]); // Prints the UK denomination to the screen
            Console.WriteLine("2p coins: " + denominationsList[10]); // Prints the UK denomination to the screen
            Console.WriteLine("1p coins: " + denominationsList[11]); // Prints the UK denomination to the screen
        }
        public static void PrintChangeUS() // PrintChangeUS method
        {
            Console.WriteLine("-=-=-=-");
            Console.WriteLine("Change:");
            Console.WriteLine("-=-=-=-");
            Console.WriteLine("$100 notes: " + denominationsList[0]); // Prints the US denomination to the screen
            Console.WriteLine("$50 notes: " + denominationsList[1]); // Prints the US denomination to the screen
            Console.WriteLine("$20 notes: " + denominationsList[2]); // Prints the US denomination to the screen
            Console.WriteLine("$10 notes: " + denominationsList[3]); // Prints the US denomination to the screen
            Console.WriteLine("$5 notes: " + denominationsList[4]); // Prints the US denomination to the screen
            Console.WriteLine("$2 notes: " + denominationsList[5]); // Prints the US denomination to the screen
            Console.WriteLine("$1 notes: " + denominationsList[6]); // Prints the US denomination to the screen
            Console.WriteLine("50¢ coins: " + denominationsList[7]); // Prints the US denomination to the screen
            Console.WriteLine("25¢ coins: " + denominationsList[8]); // Prints the US denomination to the screen
            Console.WriteLine("10¢ coins: " + denominationsList[9]); // Prints the US denomination to the screen
            Console.WriteLine("5¢ coins: " + denominationsList[10]); // Prints the US denomination to the screen
            Console.WriteLine("1¢ coins: " + denominationsList[11]); // Prints the US denomination to the screen
        }

        public static void FillListUK() // FillListUK method - adds all of the UK currency denominations to the currencyDenominations list
        {
            currencyDenominations.Clear(); // Clear the currencyDenominations list
            double[] UKDenominations = { 50.00, 20.00, 10.00, 5.00, 2.00, 1.00, 0.50, 0.20, 0.10, 0.05, 0.02, 0.01 }; // Define the correct UK denominations in an array
            currencyDenominations.AddRange(UKDenominations); // Add the array to the list
        }
        public static void FillListUS() // FillListUS method - adds all of the US currency denominations to the currencyDenominations list
        {
            currencyDenominations.Clear(); // Clear the currencyDenominations list
            double[] USDenominations = { 100.00, 50.00, 20.00, 10.00, 5.00, 2.00, 1.00, 0.50, 0.25, 0.10, 0.05, 0.01 }; // Define the correct US denominations in an array
            currencyDenominations.AddRange(USDenominations); // Add the array to the list
        }


    }
}

