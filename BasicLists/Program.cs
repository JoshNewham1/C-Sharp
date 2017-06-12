using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BasicLists
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string menuChoice;
            string elementString;
            int elementInt;
            int startSlice;
            int endSlice;
            int itemstoTake;
            int elementToRemove;
            string windowsusername = Environment.UserName;
            string path = "C:\\Users\\" + windowsusername + "\\Documents\\namelist.txt";
            List<string> nameList = new List<string>();
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Josh's Basic List Program");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-");

            while (true)
            {
                Console.WriteLine("Please type a name to add to the list or type 'm' to view the menu");
                name = Console.ReadLine();
                if (name == "m" || name == "M")
                {
                    Console.WriteLine("Would you like to:");
                    Console.WriteLine("Print them out in (o)rder");
                    Console.WriteLine("Print them out in (r)everse");
                    Console.WriteLine("(C)hoose which element to print out");
                    Console.WriteLine("Choose a (s)lice of elements to print out");
                    Console.WriteLine("(D)elete an item from the list");
                    Console.WriteLine("(I)mport a list from a text document");
                    Console.WriteLine("(W)rite the list to a text document");
                    Console.WriteLine("E(x)it the program");
                    menuChoice = Console.ReadLine().ToUpper();
                    if (menuChoice == "O")
                    {
                        for (int i = 0; i < nameList.Count; i++)
                        {
                            Console.WriteLine(nameList[i]);
                        }
                    }
                    if (menuChoice == "R")
                    {
                        nameList.Reverse();
                        for (int i = 0; i < nameList.Count; i++)
                        {
                            Console.WriteLine(nameList[i]);
                        }
                    }
                    if (menuChoice == "C")
                    {
                        Console.WriteLine("Which element would you like to print?");
                        elementString = Console.ReadLine();
                        elementInt = Int32.Parse(elementString) - 1; // Add one because computers count from 0
                        Console.WriteLine(nameList[elementInt]);
                    }
                    if (menuChoice == "S")
                    {
                        Console.WriteLine("Where would you like your slice to start?");
                        startSlice = Int32.Parse(Console.ReadLine()) - 1;
                        Console.WriteLine("Where would you like your slice to end?");
                        endSlice = Int32.Parse(Console.ReadLine());
                        itemstoTake = endSlice - startSlice;
                        string[] namelistSliced = nameList.GetRange(startSlice, itemstoTake).ToArray();
                        foreach (string item in namelistSliced)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    if (menuChoice == "D")
                    {
                        Console.WriteLine("Which element would you like to remove?");
                        elementToRemove = Int32.Parse(Console.ReadLine()) - 1;
                        nameList.RemoveAt(elementToRemove);
                    }
                    if (menuChoice == "I")
                    {
                        nameList = File.ReadAllLines(path).ToList();
                        Console.WriteLine("File read successfully...");
                    }
                    if (menuChoice == "W")
                    {
                        File.WriteAllLines(path, nameList);
                        Console.WriteLine("Text file written to successfully...");
                    }
                    if (menuChoice == "X")
                    {
                        Environment.Exit(9);
                    }
                    Console.WriteLine("Press enter to continue adding to the list...");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    nameList.Add(name);
                }
            }
        }
    }
}
