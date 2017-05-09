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
            while (true)
            {
                
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

                    int numberofcorrectdigits = 0;
                    int randomnumlength = randomnum.Length;
                    Console.WriteLine(randomnumlength);
                    for (int i = 0; i < randomnumlength; i++)
                    {
                        Console.WriteLine("The loop has incremented " + i + "times");



                        if (inpArray[i] == randomArray[i])
                        {
                            if (mode == "E")
                            {
                                // Easy Mode
                                Console.WriteLine("You have guessed digit number " + (i) + " in the random number. Try again!");
                                //i++;
                            }

                            if (mode == "H")
                            {
                                // Hard Mode
                                numberofcorrectdigits++;
                                if (i == randomnumlength - 1)
                                {
                                    Console.WriteLine("You have got " + numberofcorrectdigits + " digits correct.");
                                    //i++;
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
