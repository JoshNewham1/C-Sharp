using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int totalWords = 0;
            string menuOption;
            string input = "";
            string windowsusername = Environment.UserName;
            string path = "C:\\Users\\" + windowsusername + "\\Documents\\wordcounter.txt";
            string showSummary = "";
            var wordCountList = new List<int>();

            Console.WriteLine("-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Josh's Word Counter");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-");

            while (true)
            {
                Console.WriteLine("-=-=");
                Console.WriteLine("Menu");
                Console.WriteLine("-=-=");
                Console.WriteLine("(A)dd words and sentences to be counted");
                Console.WriteLine("(R)ead a text file of sentences to count");
                Console.WriteLine("E(x)it the program");
                menuOption = Console.ReadLine().ToUpper();

                while (menuOption == "A")
                {
                    Console.Clear();
                    Console.WriteLine("Please write words that you would like to be counted or type 'M' to return to the menu.");
                    input = Console.ReadLine();
                    if (input.ToUpper() == "M")
                    {
                        menuOption = "M";
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine(CountWords(input) + " words");
                        Console.ReadLine();
                    }
                    
                }

                if (menuOption == "R")
                {
                    Console.Clear();
                    if (File.Exists(path))
                    {
                        StreamReader sr = new StreamReader(path);
                        while (!sr.EndOfStream)
                        {
                            count++;
                            input = sr.ReadLine();
                            wordCountList.Add(CountWords(input));
                        }
                        Console.WriteLine("Would you like to see a summary? ");
                        showSummary = Console.ReadLine().ToUpper();
                        if (showSummary == "Y")
                        {
                            Console.WriteLine("-=-=-=-");
                            Console.WriteLine("Summary");
                            Console.WriteLine("-=-=-=-");
                            for (int i = 0; i < wordCountList.Count; i++)
                            {
                                Console.WriteLine("The number of words in line " + (i + 1) + " is " + wordCountList[i]);
                                totalWords += wordCountList[i];                                
                            }
                            Console.WriteLine("The total number of words for the text document is " + totalWords);
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please create a text file here: " + path);
                        Console.ReadLine();
                    }
                    
                }

                if (menuOption == "X")
                {
                    Environment.Exit(9);
                }
            }
        }

        public static int CountWords (string input)
        {
            MatchCollection words = Regex.Matches(input, @"[\S]+");
            return words.Count;
        }
    }
}
