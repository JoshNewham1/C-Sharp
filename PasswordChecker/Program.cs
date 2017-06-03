using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace PasswordChecker
{
    public enum PasswordScore
    {
        VeryWeak = 0,
        Weak = 1,
        Medium = 2,
        Strong = 3,
        VeryStrong = 4
    } 
    class Program
    {
        public static string entireFile;
        private static bool replaceText;

        static void Main(string[] args)
        {
            string menuoption;
            string password;
            string confirmedPassword;
            string windowsusername = Environment.UserName;
            string specifiedUsername;
            string newPassword;
            
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Welcome to Josh's Password Reset Program");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            while (true)
            {
                Console.WriteLine("Would you like to:");
                Console.WriteLine("(C)heck a password and determine its strength");
                Console.WriteLine("(R)eset a password in the text document");
                Console.WriteLine("(E)xit the program");
                menuoption = Console.ReadLine();

                if (menuoption == "e" || menuoption == "E")
                {
                    Environment.Exit(0);
                }

                if (menuoption == "c" || menuoption == "C")
                {
                    Console.WriteLine("Please input a password");
                    password = ReadPassword();

                    while (password.Length < 8)
                    {
                        Console.WriteLine("Invalid password - please use 8 or more characters");
                        password = ReadPassword();
                    }

                    while (password.Any(char.IsUpper) != true || password.Any(char.IsLower) != true)
                    {
                        Console.WriteLine("Invalid password - please use a mixture of upper and lower case characters");
                        password = ReadPassword();
                    }


                    Console.WriteLine("Please confirm your password");
                    confirmedPassword = ReadPassword();

                    while (confirmedPassword != password)
                    {
                        Console.WriteLine("These passwords do not match. Please try again.");
                        confirmedPassword = ReadPassword();
                    }

                    Console.WriteLine("The password you have entered is valid.");
                    PasswordScore score = CheckStrength(password);
                    Console.WriteLine("Your password is of " + score + " strength");
                    Console.WriteLine("Press enter to check another password");
                    Console.ReadLine();
                    Console.Clear();
                }
                if (menuoption == "r" || menuoption == "R")
                {
                    StreamReader sr = new StreamReader("C:\\Users\\" + windowsusername + "\\Documents\\PasswordReset.txt");
                    Console.WriteLine("Which username would you like to modify the password of?");
                    specifiedUsername = Console.ReadLine();
                    replaceText = false;
                    while (!sr.EndOfStream) // Cycles through all of the lines of text in the txt file
                    {
                        string username = sr.ReadLine();
                        string[] usernameSplit = username.Split(' ');
                        if (specifiedUsername == usernameSplit[1]) // Checks if the user has typed a valid username
                        {
                            Console.WriteLine("Please type the password you would like to change");
                            string oldPassword = ReadPassword();
                            string nextLine = sr.ReadLine();
                            string[] nextLineSplit = nextLine.Split(' ');
                            if (oldPassword == nextLineSplit[1]) // Checks if the user has typed the password below that username
                            {
                                Console.WriteLine("What would you like your new password to be?");
                                newPassword = ReadPassword();
                                Console.WriteLine("Please confirm your new password");
                                confirmedPassword = ReadPassword();
                                if (newPassword == confirmedPassword)
                                {
                                    entireFile = File.ReadAllText("C:\\Users\\" + windowsusername + "\\Documents\\PasswordReset.txt");
                                    entireFile = entireFile.Replace(oldPassword, newPassword);
                                    replaceText = true;
                                    PasswordScore score = CheckStrength(newPassword);
                                    Console.WriteLine("Your password is of " + score + " strength");
                                }
                            }
                            if (nextLine.IndexOf(oldPassword, StringComparison.CurrentCultureIgnoreCase) == 1)
                            {
                                break;
                            } 
                        }
                    }
                    if (replaceText == true)
                    {
                        sr.Close();
                        File.WriteAllText("C:\\Users\\" + windowsusername + "\\Documents\\PasswordReset.txt", entireFile);
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    if (replaceText == false)
                    {
                        Console.WriteLine("You have typed the wrong username/password. Please try again.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    

                }



            }
        }
        public static string ReadPassword() // Method to place asterisks instead of password
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true); // Reads which keys the user presses
            while (info.Key != ConsoleKey.Enter) // While the key isn't enter
            {
                if (info.Key != ConsoleKey.Backspace) // And while the key isn't backspace
                {
                    Console.Write("*"); // Write an asterisk to the screen
                    password += info.KeyChar; // Add the character to a string
                }
                else if (info.Key == ConsoleKey.Backspace) // If the key is backspace
                {
                    if (!string.IsNullOrEmpty(password)) // And the password isn't empty
                    {
                        // Remove one character from the list of password characters
                        password = password.Substring(0, password.Length - 1);
                        // Get the location of the cursor
                        int pos = Console.CursorLeft;
                        // Move the cursor to the left by one character
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // Replace it with space
                        Console.Write(" ");
                        // Move the cursor to the left by one character again
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }

            // Adds a new line after the user has pressed enter
            Console.WriteLine();
            return password;
        }
    

        public static PasswordScore CheckStrength(string password)
        {
            int score = 0;
            if (password.Length >= 8) // If the length is above or equal to 8
            {
                score++;
            }
            if (password.Length >= 10) // If the length is above or equal to 10
            {
                score++;
            }
            if (Regex.Match(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript).Success) // If the password contains special characters
            {
                score++;
            }
            if (password.Any(char.IsDigit)) // If there is a number in the password
            {
                score++;
            }
            return (PasswordScore)score;
        }
    }
}
