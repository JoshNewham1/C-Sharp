using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalsTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string menuInput;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("-=-=-=-=-=-=");
                Console.WriteLine("Conditionals");
                Console.WriteLine("-=-=-=-=-=-=");
                Console.WriteLine("Task (1)");
                Console.WriteLine("Task (2) without conditionals");
                Console.WriteLine("Task 2 with (c)onditionals");
                Console.WriteLine("Task (3)");
                Console.WriteLine("Task (4)");
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
                else if (menuInput == "C")
                {
                    Task2WithConditionals();
                }
                else if (menuInput == "3")
                {
                    Task3();
                }
                else if (menuInput == "4")
                {
                    Task4();
                }
                else if (menuInput == "X")
                {
                    Environment.Exit(9);
                }
            }
        }
        public static void Task1()
        {
            Console.WriteLine("Please enter a number");
            string userNumberString = Console.ReadLine();
            bool parseSuccessful = int.TryParse(userNumberString, out int userNumber);
            if (parseSuccessful == true)
            {
                if (userNumber >= 1 && userNumber <= 10)
                {
                    Console.WriteLine("Valid");
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }
            else
            {
                Console.WriteLine("Please type an integer");
                Console.ReadLine();
            }
        }
        public static void Task2()
        {
            Console.WriteLine("Please enter your first number");
            string firstnumberString = Console.ReadLine();
            Console.WriteLine("Please enter your second number");
            string secondnumberString = Console.ReadLine();
            bool parseFirstNumber = int.TryParse(firstnumberString, out int firstNumber);
            bool parseSecondNumber = int.TryParse(secondnumberString, out int secondNumber);
            if (parseFirstNumber == true && parseSecondNumber == true)
            {
                Console.WriteLine();
                Console.WriteLine(Math.Max(firstNumber, secondNumber) + " is the largest number");
            }
            else
            {
                Console.WriteLine("Please input only integers.");
            }
            Console.ReadLine();
        }
        public static void Task2WithConditionals()
        {
            Console.WriteLine("Please enter your first number");
            string firstnumberString = Console.ReadLine();
            Console.WriteLine("Please enter your second number");
            string secondnumberString = Console.ReadLine();
            bool parseFirstNumber = int.TryParse(firstnumberString, out int firstNumber);
            bool parseSecondNumber = int.TryParse(secondnumberString, out int secondNumber);
            if (parseFirstNumber == true && parseSecondNumber == true)
            {
                if (firstNumber > secondNumber)
                {
                    Console.WriteLine(firstNumber + " is the largest number");
                }
                else
                {
                    Console.WriteLine(secondNumber + " is the largest number");
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Please input only integers.");
            }
            Console.ReadLine();
        }
        public static void Task3()
        {
            Console.WriteLine("Please enter the width of the image");
            string imagewidthString = Console.ReadLine();
            Console.WriteLine("Please enter the height of the image");
            string imageheightString = Console.ReadLine();
            bool parseWidth = int.TryParse(imagewidthString, out int imageWidth);
            bool parseHeight = int.TryParse(imageheightString, out int imageHeight);
            if (parseWidth == true && parseHeight == true)
            {
                if (imageWidth > imageHeight)
                {
                    Console.WriteLine("The image is landscape");
                }
                else if (imageWidth == imageHeight)
                {
                    Console.WriteLine("The image is a perfect square");
                }
                else
                {
                    Console.WriteLine("The image is portrait");
                }
            }
            else
            {
                Console.WriteLine("Please input only integers.");
            }
            Console.ReadLine();
        }
        public static void Task4()
        {
            Console.WriteLine("Please enter the speed limit");
            string speedlimitString = Console.ReadLine();
            Console.WriteLine("Please enter the current speed of the car");
            string currentspeedString = Console.ReadLine();
            bool parsespeedLimit = int.TryParse(speedlimitString, out int speedLimit);
            bool parsecurrentSpeed = int.TryParse(currentspeedString, out int currentSpeed);
            if (parsespeedLimit == true && parsecurrentSpeed == true)
            {
                if (currentSpeed <= speedLimit)
                {
                    Console.WriteLine("OK");
                }
                else
                {
                    decimal speedPoints = Math.Floor(Convert.ToDecimal(((currentSpeed - speedLimit) / 5)));
                    if (speedPoints >= 12)
                    {
                        Console.WriteLine("License Suspended");
                    }
                    Console.WriteLine(speedPoints + " demerit points acquired");
                }
            }
            else
            {
                Console.WriteLine("Please input only integers.");
            }
            Console.ReadLine();
        }
    }
}