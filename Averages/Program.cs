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
            int tempMean = 0;
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
                    double totalMean = tempMean / split.Length + 1;
                    Console.WriteLine("The mean of these numbers is " + totalMean);
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
