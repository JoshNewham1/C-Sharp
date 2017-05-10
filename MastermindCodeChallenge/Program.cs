﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastermindCodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which mode would you like to pick (E)asy mode or (H)ard mode? ");
            string mode = Console.ReadLine();
            if (mode == "e" || mode == "easy" || mode == "Easy") { // Just in case the user decides to type a different character instead of E which means the same thing
                mode = "E";
            }
            if (mode == "h" || mode == "hard" || mode == "Hard") { // Just in case the user decides to type a different character instead of H which means the same thing
                mode = "H";
            }
            Console.WriteLine("(4) or (5) digits?");
            string amountofdigits = Console.ReadLine();
            
            Random rnd = new Random();
            bool win = false;
            int minRndValue = 1000;
            int maxRndValue = 9999;
            if (amountofdigits == "4") {
                minRndValue = 1000;
                maxRndValue = 9999;
            }
            if (amountofdigits == "5") {
                minRndValue = 10000;
                maxRndValue = 99999;
            }
            string randomnum = Convert.ToString(rnd.Next(minRndValue, maxRndValue));
            int numberofcorrectdigits = 0;
            int randomnumlength = randomnum.Length;
            string[] digitsguessed; // Creates an array for the digits guessed correctly
            digitsguessed = new string[randomnumlength]; // Restricts the array to 4 numbers



            while (true)
            {
                numberofcorrectdigits = 0;
                string outputEasyMatched = "";
                for (int n = 0; n < randomnumlength; n++)
                {
                    digitsguessed[n] = "*";
                }
                if (win == true) // Creates a new number if the previous one was guessed
                {
                    Console.WriteLine("-=-=-=NEW GAME-=-=-=");
                    randomnum = Convert.ToString(rnd.Next(minRndValue, maxRndValue));
                    win = false;
                }
                var randomArray = randomnum.ToCharArray();
                int randomnumconverted = Int32.Parse(randomnum);
                Console.WriteLine(randomnum);
                var playerinp = Console.ReadLine();
                if (playerinp.Length != randomnumlength)
                {
                    Console.WriteLine("Incorrect input. You might have typed the incorrect amount of numbers. Try again.");
                    playerinp = Console.ReadLine();
                }
                while (playerinp == "") {
                    Console.WriteLine("Please input a number.");
                    playerinp = Console.ReadLine();
                }
                var inpArray = playerinp.ToCharArray();
                int playerinpconverted = Int32.Parse(playerinp);
                if (playerinpconverted == randomnumconverted)
                { // Check if player guessed the correct number
                    Console.WriteLine("Congratulations!");
                    Console.ReadLine();
                    win = true;
                }
                if (win != true)
                {
                    for (int i = 0; i < randomnumlength; i++)
                    {
                        if (i == (randomnumlength - 1) && mode == "E" ) // If it is at the end of the checking and it is Easy Mode
                                {
                                    for (int concatenation = 0; concatenation < randomnumlength; concatenation++)
                                    {
                                        outputEasyMatched = outputEasyMatched + digitsguessed[concatenation];
                                    }
                                    Console.WriteLine("You guessed these digits correctly " + outputEasyMatched);
                                }
                        if (i == (randomnumlength - 1) && mode == "H" ) // If it is at the end of the checking and it is Hard Mode
                                {
                                    Console.WriteLine("You have got " + numberofcorrectdigits + " digits correct.");
                                }
                        if (inpArray[i] == randomArray[i]) // If there is a match
                        {
                            if (mode == "E")
                            {
                                // Easy Mode
                                digitsguessed[i] = randomArray[i].ToString(); // Add the number guessed right to its corresponding position in the array (array starts at 0)
                                
                            }

                            if (mode == "H")
                            {
                                // Hard Mode
                                numberofcorrectdigits++;

                            }

                        }




                    }
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
}