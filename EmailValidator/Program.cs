using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EmailValidator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    // http://net-informations.com/csprj/communications/validate-email.htm

    namespace EmailChecker
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                string loadfromtextfile;
                string email;
                bool hasSpaces = false;
                bool hasatSign = false;
                bool hasDot = false;
                string line;
                int counter = 1;
                string windowsusername = Environment.UserName;
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine("Welcome to Josh's Email Tester");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                while (true)
                {
                    Console.WriteLine("Would you like to load from a text file?");
                    loadfromtextfile = Console.ReadLine();

                    if (loadfromtextfile == "n" || loadfromtextfile == "N")
                    {
                        Console.WriteLine("Please input an email.");
                        email = Console.ReadLine();
                        hasSpaces = email.Contains(" "); // Sets a boolean to true if it contains a space
                        hasatSign = email.Contains("@"); // Sets a boolean to true if it contains an @ sign
                        hasDot = email.Contains("."); // Sets a boolean to true if it contains a dot
                        while (hasSpaces == true)
                        {
                            Console.WriteLine("Please type an email without spaces.");
                            email = Console.ReadLine();
                            hasSpaces = email.Contains(" ");
                            hasatSign = email.Contains("@");
                        }
                        while (hasatSign == false)
                        {
                            Console.WriteLine("Please type an email address with an '@' sign");
                            email = Console.ReadLine();
                            hasSpaces = email.Contains(" ");
                            hasatSign = email.Contains("@"); // Checks that the new address contains an @ sign before exiting the loop
                        }
                        if (hasatSign == true)
                        {
                            string[] afteratSign = email.Split('@');
                            hasDot = afteratSign[1].Contains(".");
                        }
                        while (hasDot == false)
                        {
                            Console.WriteLine("Please type an email address with a dot after the '@' symbol");
                            email = Console.ReadLine();
                            hasSpaces = email.Contains(" ");
                            hasatSign = email.Contains("@");
                            if (email.Contains("@"))
                            {
                                string[] afteratSign = email.Split('@');
                                hasDot = afteratSign[1].Contains(".");
                            }

                        }

                        Console.WriteLine("This email is valid.");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    if (loadfromtextfile == "y" || loadfromtextfile == "Y")
                    {
                        StreamReader sr = new StreamReader("C:\\Users\\" + windowsusername + "\\Documents\\Emails.txt");
                        while ((line = sr.ReadLine()) != null)
                        {
                            hasSpaces = line.Contains(" ");
                            hasatSign = line.Contains("@");
                            if (hasSpaces == true)
                            {
                                Console.WriteLine("Email no. " + counter + " contains a space.");
                            }
                            if (hasatSign == false)
                            {
                                Console.WriteLine("Email no. " + counter + " does not contain an '@' symbol.");
                            }
                            if (hasatSign == true)
                            {
                               string[] afteratSign = line.Split('@');
                               hasDot = afteratSign[1].Contains("."); // If the second part of the email (after the @ sign) contains a dot 
                               if (hasDot == false)
                               {
                                  Console.WriteLine("Email no. " + counter + " does not contain a '.' after the '@' sign");
                               }
                            }
                            
                            if (hasSpaces == false && hasatSign == true && hasDot == true)
                            {
                                Console.WriteLine("Email no. " + counter + " is a valid email.");
                            }
                            counter++;
                        }
                        sr.Close();
                        Console.ReadLine();
                        Console.Clear();
                    }

                }
            }
        }
    }

}