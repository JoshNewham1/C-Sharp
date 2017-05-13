using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeofaverage;
            string numberlist;
            string endofprogram;
            double tempMean = 0;
            int middlenumber;
            double median;
            while (true) {
                Console.Clear();
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("Josh's Average Program");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("Which average would you like to calculate? ");
                typeofaverage = Console.ReadLine();
                Console.WriteLine("Please specify which numbers you would like to find the average of seperated by commas. ");
                numberlist = Console.ReadLine();
                string[] split = numberlist.Split(',');
                if (typeofaverage == "mean" || typeofaverage == "Mean") {
                    foreach (string item in split) {
                        tempMean = tempMean + Int32.Parse(item);
                    }
                    double totalMean = tempMean / split.Length;
                    Console.WriteLine("The mean of these numbers is " + totalMean);
                }
                if (typeofaverage == "median" || typeofaverage == "Median") {
                    if (split.Length % 2 == 0) { // Checks if length is even
                        Array.Sort(split);
                        int[] intsplit = split.Select(int.Parse).ToArray();
                        int middle = intsplit.Length / 2;
                        double first = intsplit[middle];
                        double second = intsplit[middle - 1];
                        median = (first + second) / 2;
                        Console.WriteLine("The median of the list is " + median);

                    }
                    if (split.Length % 2 != 0) {
                        Array.Sort(split);
                        middlenumber = (split.Length / 2);
                        Console.WriteLine("The median of the list is " + split[middlenumber]);
                    }
                    
                }
                Console.WriteLine("Type 'Q' to quit or press enter to calculate another average. ");
                endofprogram = Console.ReadLine();
                if (endofprogram == "q" || endofprogram == "Q") {
                    Environment.Exit(0);
                }
            }
            
        }
    }
}
