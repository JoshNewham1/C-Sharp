using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordToGuess;
            string wordToGuessWithoutSpaces;
            int maxGuess = 0;
            char userGuess;
            var wordtoguessList = new List<char>();
            var guessedLetterList = new List<char>();
            int i = 0;
            int totalGuesses = 0;
            while (true)
            {
                totalGuesses = 0;
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("Josh's Hangman Program");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine();
                Console.WriteLine("Which word would you like to use in Hangman?");
                wordToGuess = Console.ReadLine().ToLower();
                Console.WriteLine("How many guesses would you like to allow?");
                maxGuess = Int32.Parse(Regex.Replace(Console.ReadLine(), "[^0-9]", ""));
                guessedLetterList.Clear();
                wordtoguessList.AddRange(wordToGuess);
                for (i = 0; i < wordToGuess.Length; i++)
                {
                    if (wordToGuess[i] != ' ')
                    {
                        guessedLetterList.Add('*');
                    }
                    else
                    {
                        guessedLetterList.Add(' ');
                    }
                    
                }
                for (i = 0; i <= maxGuess; i++)
                {
                    int correctGuesses = wordtoguessList.Count;
                    Console.Clear();
                    Console.WriteLine("Please guess a letter");
                    userGuess = Convert.ToChar(Console.ReadLine().ToLower());
                    totalGuesses++;
                    Console.WriteLine();
                    while (wordtoguessList.Contains(userGuess))
                    {
                        int correctletterPos = wordtoguessList.IndexOf(userGuess);
                        guessedLetterList.RemoveAt(correctletterPos);
                        guessedLetterList.Insert(correctletterPos, userGuess);
                        wordtoguessList.RemoveAt(correctletterPos);
                        wordtoguessList.Insert(correctletterPos, '*');
                    }
                    while (wordtoguessList.Contains(' '))
                    {
                        int spacePos = wordtoguessList.IndexOf(' ');
                        wordtoguessList.RemoveAt(spacePos);
                        wordtoguessList.Insert(spacePos, '/');
                    }
                    for (int x = 0; x < guessedLetterList.Count; x++)
                    {
                        if (x == 0)
                        {
                            Console.Write(guessedLetterList[x].ToString().ToUpper() + " ");
                        }
                        else if (wordtoguessList[x] == '/')
                        {
                            Console.Write(" / ");
                        }

                        else
                        {
                            Console.Write(guessedLetterList[x] + " ");
                        }
                        
                    }
                    string guessedListString = String.Join("", guessedLetterList.ToArray());
                    guessedListString = guessedListString.Replace(" ", String.Empty);
                    wordToGuessWithoutSpaces = wordToGuess.Replace(" ", String.Empty);
                    if (guessedListString == wordToGuessWithoutSpaces)
                    {
                        Console.Clear();
                        Console.WriteLine("Congratulations! The word was " + wordToGuess + " and you guessed it in " + totalGuesses + " guesses");
                        Console.ReadLine();
                        break;

                    }
                    Console.ReadLine();
                }
                if (i == maxGuess)
                {
                    Console.WriteLine("Game over! You have ran out of guesses. Press enter to restart the program");
                    Console.ReadLine();
                    Console.Clear();
                }
                Console.Clear();

            }


        }
    }
}

