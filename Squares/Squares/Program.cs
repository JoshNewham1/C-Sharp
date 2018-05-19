using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TimesTables
{
    class Program
    {
        static void Main(string[] args)
        {
            string usernumberString; // Define a string for the max number
            long usernumberLong; // Define a long (64 bit integer) for the parse
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Squares by Josh Newham");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=");

            while (true)
            {
                Console.WriteLine("Please specify a number"); // Asks the user to specify a number
                usernumberString = Console.ReadLine(); // Stores this as a string
                usernumberLong = Int64.Parse(Regex.Replace(usernumberString, "[^0-9]", "")); // Converts this into a long because the max 32 bit integer (2,147,483,647) could be too small for some calculations

                for (long i = 1; i <= usernumberLong; i++) // Repeats until it reaches max number
                {
                    Console.WriteLine(i + " squared is " + (i * i)); // Writes the answer of i x i to the screen (i is the current number the loop is on)
                }
                Console.ReadLine(); // When finished, wait for user input
                Console.Clear(); // Clear the console
            }

        }
    }
}

