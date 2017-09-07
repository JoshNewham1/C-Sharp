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
            Console.WriteLine(successfulDivisions + " successful divisions.");
            Console.ReadLine();
        }
    }
}
