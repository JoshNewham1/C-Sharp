using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLists
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string order;
            List<string> nameList = new List<string>();
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Josh's Basic List Program");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-");
            
            while (true)
            {
                Console.WriteLine("Please type a name to add to the list or type 'l' to view the list");
                name = Console.ReadLine();
                if (name == "l" || name == "L")
                {
                    Console.WriteLine("Would you like to print them out in (o)rder or in (r)everse?");
                    order = Console.ReadLine().ToUpper();
                    if (order == "O")
                    {
                        for (int i = 0; i < nameList.Count; i++)
                        {
                            Console.WriteLine(nameList[i]);
                        }
                    }
                    if (order == "R")
                    {
                        nameList.Reverse();
                        for (int i = 0; i < nameList.Count; i++)
                        {
                            Console.WriteLine(nameList[i]);
                        }
                    }
                }
                else
                {
                    nameList.Add(name);
                }
            }
        }
    }
}
