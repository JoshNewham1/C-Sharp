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
                Console.WriteLine("Task 5 without (c)onditionals");
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
                else if (menuInput == "4")
                {
                    Task4();
                }
                else if (menuInput == "C")
                {
                    Task5WithoutConditionals();
                }
                else if (menuInput == "5")
                {
                    Task5();
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
                bool parseSuccessful = Int32.TryParse(userInput, out int userNumber);
                if (parseSuccessful == true)
                {
                    numberSum = numberSum + userNumber;
                    Console.WriteLine("The sum of all numbers entered is: " + numberSum);
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Please type an integer. Press enter to continue...");
                    Console.ReadLine();
                }
                
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
                    bool parseSuccessful = Int32.TryParse(userInput, out int userNumber);
                    if (parseSuccessful == true)
                    {
                        long result = userNumber;
                        for (int i = 1; i < userNumber; i++)
                        {
                            result = result * i;
                        }
                        Console.WriteLine(userNumber + "! = " + result);
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Please type an enteger. Press enter to continue...");
                        Console.ReadLine();
                    }
                }
            }
        }
        public static void Task4()
        {
            Console.Clear();
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 10);
            // Console.WriteLine("Random number: " + randomNumber);
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine("Guess a number:");
                int userGuess = Int32.Parse(Console.ReadLine());
                if (userGuess == randomNumber)
                {
                    Console.WriteLine("Congratulations! You guessed the number in " + i + " guesses.");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.WriteLine("You guessed the incorrect number. Press enter to try again.");
                    Console.ReadLine();
                }
            }
            Console.WriteLine("You have exceeded the number of allowed guesses. Press enter to return to the menu...");
            Console.ReadLine();
        }
        public static void Task5WithoutConditionals()
        {
            Console.WriteLine("Please enter a list of numbers seperated by a comma:");
            string numberListString = Console.ReadLine();
            List<int> numberList = numberListString.Split(',').Select(Int32.Parse).ToList();
            Console.WriteLine("The max number in the list is: " + numberList.Max());
            Console.ReadLine();
        }
        public static void Task5()
        {
            Console.WriteLine("Please enter a list of numbers seperated by a comma:");
            string numberList = Console.ReadLine();
            string[] numberlistSplit = numberList.Split(',');
            int max = Int32.Parse(numberlistSplit[0]);
            for (int i = 0; i < numberlistSplit.Length; i++)
            {
                int currentNumber = Int32.Parse(numberlistSplit[i]);
                if (currentNumber > max)
                {
                    max = currentNumber;
                }
            }
            Console.WriteLine("The max number in the list is: " + max);
            Console.ReadLine();
        }
    }
}
