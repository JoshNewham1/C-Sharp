using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MaxAndMinList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = new List<int>();
            List<string> numberListString = new List<string>();
            string numberString;
            int numberInt;
            int listMin;
            int listMax;
            string menuChoice;
            string minimumBoundaryString = "";
            int minimumBoundaryInt = 0;
            string maximumBoundaryString = "";
            int maximumBoundaryInt = 0;
            string boundariesSet = "";
            string windowsusername = Environment.UserName;
            string path = "C:\\Users\\" + windowsusername + "\\Documents\\NumberList.txt";
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Josh's Max and Min List Program");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Would you like to set any boundaries? (Y) or (N)");
            boundariesSet = Console.ReadLine().ToUpper();
            if (boundariesSet == "Y")
            {
                Console.WriteLine("Please specify the minimum boundary.");
                minimumBoundaryString = Console.ReadLine();
                minimumBoundaryInt = Int32.Parse(minimumBoundaryString);
                Console.WriteLine("Please specify the maximum boundary.");
                maximumBoundaryString = Console.ReadLine();
                maximumBoundaryInt = Int32.Parse(maximumBoundaryString);
            }
            else if (boundariesSet == "N")
            {
                Console.WriteLine("A boundary can be set later in the menu.");
            }


            while (true)
            {
                Console.WriteLine("Please type a number to add to the list or type 'm' to view the menu");
                numberString = Console.ReadLine();
                bool parseSuccessful = int.TryParse(numberString, out numberInt);
                if (numberString == "m")
                {
                    Console.Clear();
                    Console.WriteLine("Would you like to:");
                    Console.WriteLine("(S)how the numbers in the list");
                    Console.WriteLine("(D)efine boundaries for the numbers");
                    Console.WriteLine("(W)rite the numbers to a text file");
                    Console.WriteLine("(L)oad numbers from a text file");
                    menuChoice = Console.ReadLine().ToUpper();
                    if (menuChoice == "S")
                    {
                        foreach (int i in numberList)
                        {
                            Console.WriteLine(i);
                        }
                    }
                    if (menuChoice == "D")
                    {
                        boundariesSet = "Y";
                        Console.WriteLine("Please specify the minimum boundary.");
                        minimumBoundaryString = Console.ReadLine();
                        minimumBoundaryInt = Int32.Parse(minimumBoundaryString);
                        Console.WriteLine("Please specify the maximum boundary.");
                        maximumBoundaryString = Console.ReadLine();
                        maximumBoundaryInt = Int32.Parse(maximumBoundaryString);
                    }
                    if (menuChoice == "W")
                    {
                        numberListString = numberList.ConvertAll<string>(x => x.ToString());
                        File.WriteAllLines(path, numberListString);
                    }
                    if (menuChoice == "L")
                    {
                        string line;
                        Console.WriteLine("NOTE: This will not import numbers that are outside of the boundaries. These can be set in the menu.");
                        System.IO.StreamReader file = new System.IO.StreamReader(path);
                        while ((line = file.ReadLine()) != null)
                        {
                            if (boundariesSet == "Y")
                            {
                                if (Int32.Parse(line) >= minimumBoundaryInt && Int32.Parse(line) <= maximumBoundaryInt)
                                {
                                    numberList.Add(Int32.Parse(line));
                                }
                                else
                                {
                                    Console.WriteLine("The number " + line + " is not within the boundaries so has not been imported to the list");
                                }
                            }
                            if (boundariesSet == "N")
                            {
                                numberList.Add(Int32.Parse(line));
                            }
                        }
                    }
                }
                else if (parseSuccessful == false)
                {
                    Console.WriteLine("Please type a valid number");
                    numberString = Console.ReadLine();
                    parseSuccessful = int.TryParse(numberString, out numberInt);
                }
                if (parseSuccessful == true)
                {
                    if (boundariesSet == "Y")
                    {
                        if (numberInt >= minimumBoundaryInt && numberInt <= maximumBoundaryInt)
                        {
                            numberList.Add(numberInt);
                            listMin = numberList.Min();
                            listMax = numberList.Max();
                            Console.WriteLine("Min value: " + listMin);
                            Console.WriteLine("Max value: " + listMax);
                        }
                        else
                        {
                            Console.WriteLine("Please type a number that is within the boundaries.");
                        }

                    }
                    else if (boundariesSet != "Y")
                    {
                        numberList.Add(numberInt);
                        listMin = numberList.Min();
                        listMax = numberList.Max();
                        Console.WriteLine("Min value: " + listMin);
                        Console.WriteLine("Max value: " + listMax);
                    }

                }

            }

        }
    }
}


