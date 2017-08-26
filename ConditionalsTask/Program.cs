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
            int userNumber = Convert.ToInt32(Console.ReadLine());
            if (userNumber >= 1 && userNumber <= 10)
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid");
            }
            Console.ReadLine();
        }
        public static void Task2()
        {
            Console.WriteLine("Please enter your first number");
            int firstNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter your second number");
            int secondNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine(Math.Max(firstNumber, secondNumber) + " is the largest number");
            Console.ReadLine();
        }
        public static void Task2WithConditionals()
        {
            Console.WriteLine("Please enter your first number");
            int firstNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter your second number");
            int secondNumber = Convert.ToInt32(Console.ReadLine());
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
        public static void Task3()
        {
            Console.WriteLine("Please enter the width of the image");
            int imageWidth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the height of the image");
            int imageHeight = Convert.ToInt32(Console.ReadLine());
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
            Console.ReadLine();
        }
        public static void Task4()
        {
            Console.WriteLine("Please enter the speed limit");
            int speedLimit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the current speed of the car");
            int currentSpeed = Convert.ToInt32(Console.ReadLine());
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
            Console.ReadLine();
        }
    }
}