using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeofaverage;
            string numberlist;
            string endofprogram;
            double tempMean = 0;
            int middlenumber;
            double median;
            string writetotextfile;
            string windowsusername = Environment.UserName;
            string readfromtextfile;
            string line;
            string newline;

            while (true) {
                Console.Clear();
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("Josh's Average Program");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("Which average would you like to calculate? ");
                typeofaverage = Console.ReadLine();
                Console.WriteLine("Would you like to input your numbers from a text file? ");
                readfromtextfile = Console.ReadLine();
                if (readfromtextfile == "y" || readfromtextfile == "Y")
                {
                    StreamReader sr = new StreamReader("C:\\Users\\" + windowsusername + "\\Documents\\AverageList.txt");
                    line = sr.ReadLine();
                    if (line.EndsWith(","))
                    {
                        line = line.Remove(line.Length - 1); // If there is a comma at the end of the text file, this removes it so it can be interpretted properly.
                    }
                    sr.Close();
                    numberlist = line;
                }
                else
                {
                    Console.WriteLine("Please specify which numbers you would like to find the average of seperated by commas. ");
                    numberlist = Console.ReadLine();
                }
                string[] split = numberlist.Split(',');
                int[] intsplit = split.Select(int.Parse).ToArray();
                if (typeofaverage == "mean" || typeofaverage == "Mean") {
                    foreach (string item in split) {
                        tempMean = tempMean + Int32.Parse(item);
                    }
                    double totalMean = tempMean / split.Length;
                    Console.WriteLine("The mean of these numbers is " + totalMean);
                }
                if (typeofaverage == "median" || typeofaverage == "Median") {
                    if (split.Length % 2 == 0) { // Checks if length is even
                        Array.Sort(split);
                        int middle = intsplit.Length / 2;
                        double first = intsplit[middle];
                        double second = intsplit[middle - 1];
                        median = (first + second) / 2;
                        Console.WriteLine("The median of the list is " + median);

                    }
                    if (split.Length % 2 != 0) {
                        Array.Sort(split);
                        middlenumber = (split.Length / 2);
                        Console.WriteLine("The median of the list is " + split[middlenumber]);
                    }
                    
                }
                if (typeofaverage == "mode" || typeofaverage == "Mode") {
                    int mode = intsplit.GroupBy(i => i) // Groups the same items together
                                       .OrderByDescending(g => g.Count()) // Getting frequency of group
                                       .Select(g => g.Key) // Selecting the key of the group
                                       .First(); // Taking the most frequent value
                    Console.WriteLine("The mode of the list is " + mode);
                }
                Console.WriteLine("Would you like to save your list to a text file for later reference?");
                writetotextfile = Console.ReadLine();
                if (writetotextfile == "y" || writetotextfile == "Y")
                {
                    for (int i = 0; i < split.Length; i++)
                    {
                        newline = $"{split[i]},";
                        FileStream fs = new FileStream("C:\\Users\\" + windowsusername + "\\Documents\\AverageList.txt", FileMode.OpenOrCreate);
                        StreamWriter str = new StreamWriter(fs);
                        str.BaseStream.Seek(0, SeekOrigin.End);
                        str.Write(newline);
                        str.Flush();
                        str.Close();
                        fs.Close();
                    }
                }
                Console.WriteLine("Type 'Q' to quit or press enter to calculate another average. ");
                endofprogram = Console.ReadLine();
                if (endofprogram == "q" || endofprogram == "Q") {
                    Environment.Exit(0);
                }
            }
            
        }
    }
}
