using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PasswordChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            string loadfromtextfile;
            string password;
            string confirmedPassword;
            string windowsusername = Environment.UserName;
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

                }

            }

        }
    }
}
