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
            string loadfromtextfile;
            string password;
            string confirmedPassword;
            string windowsusername = Environment.UserName;
            string specifiedUsername;
            string oldPassword;
            string newPassword;
            
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Welcome to Josh's Password Reset Program");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            while (true)
            {
                Console.WriteLine("Would you like to load from a text file?");
                loadfromtextfile = Console.ReadLine();

                if (loadfromtextfile == "n" || loadfromtextfile == "N")
                {
                    Console.WriteLine("Please input a password");
                    password = Console.ReadLine();

                    while (password.Length < 8)
                    {
                        Console.WriteLine("Invalid password - please use 8 or more characters");
                        password = Console.ReadLine();
                    }

                    while (password.Any(char.IsUpper) != true || password.Any(char.IsLower) != true)
                    {
                        Console.WriteLine("Invalid password - please use a mixture of upper and lower case characters");
                        password = Console.ReadLine();
                    }


                    Console.WriteLine("Please confirm your password");
                    confirmedPassword = Console.ReadLine();

                    while (confirmedPassword != password)
                    {
                        Console.WriteLine("These passwords do not match. Please try again.");
                        confirmedPassword = Console.ReadLine();
                    }

                    Console.WriteLine("The password you have entered is valid.");
                    PasswordScore score = CheckStrength(password);
                    Console.WriteLine("Your password is of " + score + " strength");
                    Console.WriteLine("Press enter to check another password");
                    Console.ReadLine();
                    Console.Clear();
                }
                if (loadfromtextfile == "y" || loadfromtextfile == "Y")
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
                            oldPassword = Console.ReadLine();
                            string nextLine = sr.ReadLine();
                            string[] nextLineSplit = nextLine.Split(' ');
                            if (oldPassword == nextLineSplit[1]) // Checks if the user has typed the password below that username
                            {
                                Console.WriteLine("What would you like your new password to be?");
                                newPassword = Console.ReadLine();
                                Console.WriteLine("Please confirm your new password");
                                confirmedPassword = Console.ReadLine();
                                if (newPassword == confirmedPassword)
                                {
                                    entireFile = File.ReadAllText("C:\\Users\\" + windowsusername + "\\Documents\\PasswordReset.txt");
                                    entireFile = entireFile.Replace(oldPassword, newPassword);
                                    replaceText = true;
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
                        Console.WriteLine(entireFile);
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
