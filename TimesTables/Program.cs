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
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Times Tables by Josh Newham");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-");

            while (true)
            {
                Console.WriteLine("Which times table would you like to list"); // Asks the user to specify a number
                usernumberString = Console.ReadLine(); // Stores this as a string
                usernumberLong = Int64.Parse(Regex.Replace(usernumberString, "[^0-9]", "")); // Converts this into a long because the max 32 bit integer (2,147,483,647) could be too small
                long i = 1;
                while (true) // Repeats until it reaches max number
                {
                    Console.WriteLine(i + " x " + usernumberLong + " = " +  i * usernumberLong); // Writes the answer of i x usernumber (i is the number the loop is on)
                    i++;
                    Console.CancelKeyPress += delegate // If the user types Ctrl-C or Ctrl-Break (Only works when not debugging)
                    {
                    };
                }

            }

        }
    }
}

