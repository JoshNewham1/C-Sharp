using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string menuInput;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-=-=-");
                Console.WriteLine("Loops");
                Console.WriteLine("-=-=-");
                Console.WriteLine("Task (1)");
                Console.WriteLine("Task (2)");
                Console.WriteLine("Task (3)");
                Console.WriteLine("Task (4)");
                Console.WriteLine("Task (5)");
                Console.WriteLine("E(x)it the program");
                menuInput = Console.ReadLine().ToUpper();

                if (menuInput == "1")
                {
                    Task1();
                }
                else if (menuInput == "2")
                {
                    Task2();
                }
                else if (menuInput == "3")
                {
                    Task3();
                }
                else if (menuInput == "X")
                {
                    Environment.Exit(9);
                }
            }
        }
        public static void Task1()
        {
            int maxInt = 100;
            int successfulDivisions = 0;
            for (int i = 1; i < maxInt; i++)
            {
                if (i % 3 == 0)
                {
                    successfulDivisions++;
                }
            }
            Console.WriteLine("There are " + successfulDivisions + " numbers that are divisible by 3 between 1 and " + maxInt);
            Console.ReadLine();
        }
        public static void Task2()
        {
            int numberSum = 0;
            while (true)
            {
                Console.WriteLine("Enter a number or type 'OK' to exit...");
                string userInput = Console.ReadLine().ToUpper();
                if (userInput == "OK")
                {
                    break;
                }
                numberSum = numberSum + Int32.Parse(userInput);
                Console.WriteLine("The sum of all numbers entered is: " + numberSum);
                Console.ReadLine();
                Console.Clear();
            }
        }
        public static void Task3()
        {
            while (true)
            {
                Console.WriteLine("Please enter the number you would like a factorial of or type 'OK' to exit...");
                string userInput = Console.ReadLine().ToUpper();
                if (userInput == "OK")
                {
                    break;
                }
                else
                {
                    int userNumber = Int32.Parse(userInput);
                    long result = userNumber;
                    for (int i = 1; i < userNumber; i++)
                    {
                        result = result * i;
                    }
                    Console.WriteLine(userNumber + "! = " + result);
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
