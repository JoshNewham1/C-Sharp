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
                Console.WriteLine("Task (2)");
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

                }
                else if (menuInput == "3")
                {

                }
                else if (menuInput == "4")
                {

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
    }
}