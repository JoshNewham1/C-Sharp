using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string menuOption;
            string input;
            int vowelCount;
            int aCount = 0;
            int eCount = 0;
            int iCount = 0;
            int oCount = 0;
            int uCount = 0;

            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Josh's Vowel Counter");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=");

            while (true)
            {
                Console.Clear();
                Console.WriteLine("-=-=");
                Console.WriteLine("Menu");
                Console.WriteLine("-=-=");
                Console.WriteLine("Would you like to:");
                Console.WriteLine("(A)dd sentences manually");
                Console.WriteLine("E(x)it the program");

                menuOption = Console.ReadLine().ToUpper();

                while (menuOption == "A")
                {
                    Console.Clear();
                    Console.WriteLine("Please input words or sentences to count the vowels of. Press 'M' to exit to the menu.");
                    input = Console.ReadLine();
                    if (input.ToUpper() == "M")
                    {
                        menuOption = "M";
                    }
                    else
                    {
                        vowelCount = input.Count("aeiouAEIOU".Contains);
                        for (int i = 0; i < input.Length; i++)
                        {
                            if (input[i] == 'a' || input[i] == 'A')
                            {
                                aCount++;
                            }
                            if (input[i] == 'e' || input[i] == 'E')
                            {
                                eCount++;
                            }
                            if (input[i] == 'i' || input[i] == 'I')
                            {
                                iCount++;
                            }
                            if (input[i] == 'o' || input[i] == 'O')
                            {
                                oCount++;
                            }
                            if (input[i] == 'u' || input[i] == 'u')
                            {
                                uCount++;
                            }
                        }
                        Console.WriteLine("There are " + vowelCount + " vowels in the sentence");
                        Console.WriteLine("Vowels used:");
                        if (aCount > 0)
                        {
                            Console.WriteLine("A: " + aCount);
                        }
                        if (eCount > 0)
                        {
                            Console.WriteLine("E: " + eCount);
                        }
                        if (iCount > 0)
                        {
                            Console.WriteLine("I: " + iCount);
                        }
                        if (oCount > 0)
                        {
                            Console.WriteLine("O: " + oCount);
                        }
                        if (uCount > 0)
                        {
                            Console.WriteLine("U: " + uCount);
                        }
                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
