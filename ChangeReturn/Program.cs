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
        private static double[] currencyDenominations = { 50.00, 20.00, 10.00, 5.00, 2.00, 1.00, 0.50, 0.20, 0.10, 0.05, 0.02, 0.01 };
        private static List<int> denominationsList = new List<int>();
        private static double doubleChange;
        static void Main(string[] args)
        {
            string stringCost;
            double doubleCost;
            string stringMoneyGiven;
            double doubleMoneyGiven;
            string seeSummary;
            
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Josh's Change Return Program");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

            while (true)
            {
                Console.WriteLine("What is the cost of the item?");
                stringCost = Console.ReadLine();
                stringCost = Regex.Replace(stringCost, "[^0-9.]", ""); // Removes any special characters leaving just numbers
                while (stringCost == "")
                {
                    Console.WriteLine("Please specify a cost.");
                    stringCost = Console.ReadLine();
                    stringCost = Regex.Replace(stringCost, "[^0-9.]", "");
                }
                doubleCost = Convert.ToDouble(stringCost);
                Console.WriteLine("How much money have you given?");
                stringMoneyGiven = Console.ReadLine();
                stringMoneyGiven = Regex.Replace(stringMoneyGiven, "[^0-9.]", ""); // Removes any special characters leaving just numbers
                while (stringMoneyGiven == "")
                {
                    Console.WriteLine("Please specify how much money you have given.");
                    stringMoneyGiven = Console.ReadLine();
                    stringMoneyGiven = Regex.Replace(stringMoneyGiven, "[^0-9.]", "");
                }
                doubleMoneyGiven = Convert.ToDouble(stringMoneyGiven);
                doubleChange = Math.Round(doubleMoneyGiven - doubleCost, 2);
                Console.WriteLine("Change: " + doubleChange);
                Console.WriteLine("Would you like to see all of the coins/notes that are required?");
                seeSummary = Console.ReadLine().ToUpper();
                if (seeSummary == "Y")
                {
                    Console.Clear();
                    CountChange();
                    PrintChange();
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                }
                


                
            }
        }

        public static void CountChange()
        {
            for (int i = 0; i < currencyDenominations.Length; i++)
            {
                if (doubleChange > 0)
                {
                    doubleChange = Math.Round(doubleChange, 2);
                    double currencyDivisions = doubleChange / currencyDenominations[i];
                    currencyDivisions = Math.Floor(currencyDivisions);
                    int currencyDivisionsRounded = Convert.ToInt32(currencyDivisions);
                    if (currencyDivisions >= 1)
                    {
                        denominationsList.Add(currencyDivisionsRounded);
                        doubleChange = doubleChange - Math.Round(currencyDivisionsRounded * currencyDenominations[i], 2);
                    }
                    else
                    {
                        denominationsList.Add(0);
                    }

                }
                else
                {
                    denominationsList.Add(0);
                }

            }
        }

        public static void PrintChange()
        {
            Console.WriteLine("-=-=-=-");
            Console.WriteLine("Change:");
            Console.WriteLine("-=-=-=-");
            Console.WriteLine("£50 notes: " + denominationsList[0]);
            Console.WriteLine("£20 notes: " + denominationsList[1]);
            Console.WriteLine("£10 notes: " + denominationsList[2]);
            Console.WriteLine("£5 notes: " + denominationsList[3]);
            Console.WriteLine("£2 coins: " + denominationsList[4]);
            Console.WriteLine("£1 coins: " + denominationsList[5]);
            Console.WriteLine("50p coins: " + denominationsList[6]);
            Console.WriteLine("20p coins: " + denominationsList[7]);
            Console.WriteLine("10p coins: " + denominationsList[8]);
            Console.WriteLine("5p coins: " + denominationsList[9]);
            Console.WriteLine("2p coins: " + denominationsList[10]);
            Console.WriteLine("1p coins: " + denominationsList[11]);
        }


    }
}
