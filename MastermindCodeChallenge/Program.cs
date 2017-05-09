using System;
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
            Random rnd = new Random();
            bool win = false;
            string randomnum = Convert.ToString(rnd.Next(1000, 9999));
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
                    randomnum = Convert.ToString(rnd.Next(1000, 9999));
                    win = false;
                }
                var randomArray = randomnum.ToCharArray();
                int randomnumconverted = Int32.Parse(randomnum);
                Console.WriteLine(randomnum);
                var playerinp = Console.ReadLine();
                if (playerinp.Length > 4)
                {
                    Console.WriteLine("Incorrect input. You might have typed too many number. Try again.");
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
                        if (inpArray[i] == randomArray[i])
                        {
                            if (mode == "E")
                            {
                                // Easy Mode
                                digitsguessed[i] = randomArray[i].ToString(); // Add the number guessed right to its corresponding position in the array (array starts at 0)
                                if (i == (randomnumlength - 1))
                                {
                                    for (int concatenation = 0; concatenation < randomnumlength; concatenation++)
                                    {
                                        outputEasyMatched = outputEasyMatched + digitsguessed[concatenation];
                                    }
                                    Console.WriteLine("You guessed these digits correctly "+outputEasyMatched);
                                }
                            }

                            if (mode == "H")
                            {
                                // Hard Mode
                                numberofcorrectdigits++;
                                if (i == (randomnumlength - 1))
                                {
                                    Console.WriteLine("You have got " + numberofcorrectdigits + " digits correct.");
                                }

                            }
                        }




                    }

                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
}
