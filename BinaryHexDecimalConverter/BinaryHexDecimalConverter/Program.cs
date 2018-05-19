using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BinaryHexDecimalConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string menuOption; // Define a variable to store the user's menu option
            string userinputString; // Define a variable to hold the user's input
            long userDecimal; // Define a variable to convert the user's input into a 64-bit integer
            string userBinary; // Define a variable to convert the user's input into binary
            string hexConversion; // Define a variable to convert the user's input into hexadecimal
            bool isHex; // Define a boolean to determine whether the user's input is hex
            bool isDecimal; // Define a boolean to determine whether the user's input is a decimal
            bool isBinary; // Define a boolean to determine whether the user's input is a binary number

            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Binary/Hexadecimal/Decimal Converter");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

            while (true) // Infinite loop
            {
                Console.WriteLine("Would you like to convert:");
                Console.WriteLine("(1) Decimal to Binary");
                Console.WriteLine("(2) Decimal to Hexadecimal");
                Console.WriteLine("(3) Binary to Hexadecimal");
                Console.WriteLine("(4) Binary to Decimal");
                Console.WriteLine("(5) Hexadecimal to Decimal");
                Console.WriteLine("(6) Hexadecimal to Binary");
                Console.WriteLine("(7) Exit the program");

                menuOption = Console.ReadLine().ToUpper(); // Read the user's choice into a variable and capitalise it

                while (menuOption == "1") // If the user wants to convert decimal to binary
                {
                    Console.Clear(); // Clears the console
                    isDecimal = false; // Reset the boolean to its default of 'false'
                    Console.WriteLine("Please specify a decimal or type 'M' to go back to the menu"); // Ask for the user input
                    userinputString = Console.ReadLine(); // Store it in a string
                    if (userinputString.ToUpper() == "M") // Check if that string is 'M' or 'm'
                    {
                        Console.Clear(); // If it is, clear the console
                        menuOption = "M"; // Change the menuOption to break out of the loop
                    }
                    else // If the user types anything else
                    {
                        isDecimal = Regex.IsMatch(userinputString, "[0-9]"); // Assigns the boolean to true or false if it matches the pattern
                        if (isDecimal == true) // If the user's input matched the pattern (if the user's input was from 1 to 9)
                        {
                            userDecimal = Int64.Parse(userinputString); // Convert the user's input to a 64-bit integer
                            userBinary = Convert.ToString(userDecimal, 2); // Converts the decimal to a string and to Base-2 (the second parameter)
                            Console.WriteLine("Binary: " + userBinary); // Writes the binary to the screen
                            Console.ReadLine(); // Waits for user input
                            Console.Clear(); // Clears the console
                        }
                        else // If the string the user entered didn't match the pattern (contained other characters other than 1-9)
                        {
                            while (isDecimal == false) // While the user's input is invalid
                            {
                                Console.WriteLine("Please enter a decimal."); // Tell the user to re-enter the decimal
                                userinputString = Console.ReadLine(); // Read this into a variable
                                isDecimal = Regex.IsMatch(userinputString, "[0-9]"); // Recheck this variable
                            }
                            // When the user enters a valid decimal:
                            userDecimal = Int64.Parse(userinputString); // Convert the user's input to a 64-bit integer
                            userBinary = Convert.ToString(userDecimal, 2); // Converts the decimal to a string and to Base-2 (the second parameter)
                            Console.WriteLine("Binary: " + userBinary); // Writes the binary to the screen
                            Console.ReadLine(); // Waits for user input
                            Console.Clear(); // Clears the console
                        }

                    }
                }
                while (menuOption == "2") // If the user chosen to convert decimal to hexadecimal
                {
                    Console.Clear(); // Clears the console
                    isDecimal = false; // Reset the boolean to its default of 'false'
                    Console.WriteLine("Please specify a decimal or type 'M' to go back to the menu"); // Ask for the user input
                    userinputString = Console.ReadLine(); // Store it in a string
                    if (userinputString == "M") // Check if that string is 'M' or 'm'
                    {
                        Console.Clear(); // If it is, clear the console
                        menuOption = "M"; // Change the menuOption to break out of the loop
                    }
                    else // If the user types anything else
                    {
                        isDecimal = Regex.IsMatch(userinputString, "[0-9]"); // Assigns the boolean to true or false if it matches the pattern
                        if (isDecimal == true) // If the user's input matched the pattern (if the user's input was from 1 to 9)
                        {
                            userDecimal = Int64.Parse(userinputString); // Convert the user's input to a 64-bit integer
                            hexConversion = userDecimal.ToString("X"); // Converts the integer to a string and formats it hexadecimally (X is the IFormatProvider for hexadecimal)
                            Console.WriteLine("Hex: " + hexConversion); // Writes the hexadecimal value to the screen
                            Console.ReadLine(); // Waits for user input
                            Console.Clear(); // Clears the console
                        }
                        else // If the user types anything else
                        {
                            while (isDecimal == false) // While the user's input is invalid
                            {
                                Console.WriteLine("Please enter a decimal."); // Tell the user to re-enter the decimal
                                userinputString = Console.ReadLine(); // Read this into a variable
                                isDecimal = Regex.IsMatch(userinputString, "[0-9]"); // Recheck this variable
                            }
                            // When the user enters a valid decimal:
                            userDecimal = Int64.Parse(userinputString); // Convert the user's input to a 64-bit integer
                            hexConversion = userDecimal.ToString("X"); // Converts the integer to a string and formats it hexadecimally (X is the IFormatProvider for hexadecimal)
                            Console.WriteLine("Hex: " + hexConversion); // Writes the hexadecimal value to the screen
                            Console.ReadLine(); // Waits for user input
                            Console.Clear(); // Clears the console
                        }

                    }
                }
                while (menuOption == "3") // If the user has chosen to convert binary to hexadecimal
                {
                    Console.Clear(); // Clears the console
                    isBinary = false; // Reset the boolean to its default of 'false'
                    Console.WriteLine("Please specify a binary number or type 'M' to go back to the menu"); // Ask for the user input
                    userinputString = Console.ReadLine(); // Store it in a string
                    if (userinputString == "M") // Check if that string is 'M' or 'm'
                    {
                        Console.Clear(); // If it is, clear the console
                        menuOption = "M"; // Change the menuOption to break out of the loop
                    }
                    else // If the user types anything else
                    {
                        isBinary = Regex.IsMatch(userinputString, "^[01]+$"); // Assigns the boolean to true or false if it matches the pattern
                        if (isBinary == true) // If the user's input matched the pattern (if the user's input contained only 1s and 0s)
                        {
                            hexConversion = Convert.ToInt32(userinputString, 2).ToString("X"); // Convert the binary to an integer, specify that it is Base-2 and format it hexadecimally
                            Console.WriteLine("Hex: " + hexConversion); // Writes the hexadecimal value to the screen
                            Console.ReadLine(); // Waits for user input
                            Console.Clear(); // Clears the console
                        }
                        else // If the user types anything else
                        {
                            while (isBinary == false) // While the user's input is invalid
                            {
                                Console.WriteLine("Please enter a binary number."); // Tell the user to re-enter the binary number
                                userinputString = Console.ReadLine(); // Read this into a variable
                                isBinary = Regex.IsMatch(userinputString, "^[01]+$"); // Recheck this variable
                            }
                            // When the user enters a valid binary number:
                            hexConversion = Convert.ToInt32(userinputString, 2).ToString("X"); // Convert the binary to an integer, specify that it is Base-2 and format it hexadecimally
                            Console.WriteLine("Hex: " + hexConversion); // Writes the hexadecimal value to the screen
                            Console.ReadLine(); // Waits for user input
                            Console.Clear(); // Clears the console
                        }

                    }
                }
                while (menuOption == "4") // If the user has chosen to convert binary to decimal
                {
                    Console.Clear(); // Clears the console
                    isBinary = false; // Reset the boolean to its default of 'false'
                    Console.WriteLine("Please specify a binary number or type 'M' to go back to the menu"); // Ask for the user input
                    userinputString = Console.ReadLine(); // Store it in a string
                    if (userinputString == "M") // Check if that string is 'M' or 'm'
                    {
                        Console.Clear(); // If it is, clear the console
                        menuOption = "M"; // Change the menuOption to break out of the loop
                    }
                    else // If the user types anything else
                    {
                        isBinary = Regex.IsMatch(userinputString, "^[01]+$"); // Assigns the boolean to true or false if it matches the pattern
                        if (isBinary == true) // If the user's input matched the pattern (if the user's input contained only 1s and 0s)
                        {
                            userDecimal = Convert.ToInt64(userinputString, 2); // Converts the binary number into a 64-bit integer with Base-2
                            Console.WriteLine("Decimal: " + userDecimal); // Writes the decimal value to the screen
                            Console.ReadLine(); // Waits for user input
                            Console.Clear(); // Clears the console
                        }
                        else // If the user types anything else
                        {
                            while (isBinary == false) // While the user's input is invalid
                            {
                                Console.WriteLine("Please enter a binary number."); // Tell the user to re-enter the binary number
                                userinputString = Console.ReadLine(); // Read this into a variable
                                isBinary = Regex.IsMatch(userinputString, "^[01]+$"); // Recheck this variable
                            }
                            // When the user enters a valid binary number:
                            userDecimal = Convert.ToInt64(userinputString, 2); // Converts the binary number into a 64-bit integer with Base-2
                            Console.WriteLine("Decimal: " + userDecimal); // Writes the decimal value to the screen
                            Console.ReadLine(); // Waits for user input
                            Console.Clear(); // Clears the console
                        }

                    }
                }
                while (menuOption == "5") // If the user has chosen to convert hexadecimal to decimal
                {
                    Console.Clear(); // Clears the console
                    isHex = false; // Reset the boolean to its default of 'false'
                    Console.WriteLine("Please specify a hexadecimal number or type 'M' to go back to the menu"); // Ask for the user input
                    userinputString = Console.ReadLine(); // Store it in a string
                    if (userinputString == "M") // Check if that string is 'M' or 'm'
                    {
                        Console.Clear(); // If it is, clear the console
                        menuOption = "M"; // Change the menuOption to break out of the loop
                    }
                    else // If the user types anything else
                    {
                        isHex = Regex.IsMatch(userinputString, @"\A\b[0-9a-fA-F]+\b\Z"); // Assigns the boolean to true or false if it matches the pattern
                        if (isHex == true) // If the user's input matched the pattern (if the user's input contained 0-9 and A-F)
                        {
                            userDecimal = Int64.Parse(userinputString, System.Globalization.NumberStyles.HexNumber); // Convert the string into a 64-bit integer and format it using System.Globalization.NumberStyles.HexNumber
                            Console.WriteLine("Decimal: " + userDecimal); // Writes the decimal value to the screen
                            Console.ReadLine(); // Waits for user input
                            Console.Clear(); // Clears the console
                        }
                        else // If the user types anything else
                        {
                            while (isHex == false) // While the user's input is invalid
                            {
                                Console.WriteLine("Please specify a hexadecimal number"); // Tell the user to re-enter the hexadecimal number
                                userinputString = Console.ReadLine(); // Read this into a variable
                                isHex = Regex.IsMatch(userinputString, @"\A\b[0-9a-fA-F]+\b\Z"); // Recheck this variable
                            }
                            // When the user enters a valid hexadecimal value:
                            userDecimal = Int64.Parse(userinputString, System.Globalization.NumberStyles.HexNumber); // Convert the string into a 64-bit integer and format it using System.Globalization.NumberStyles.HexNumber
                            Console.WriteLine("Decimal: " + userDecimal); // Writes the decimal value to the screen
                            Console.ReadLine(); // Waits for user input
                            Console.Clear(); // Clears the console
                        }

                    }
                }
                while (menuOption == "6")
                {
                    Console.Clear(); // Clears the console
                    isHex = false; // Reset the boolean to its default of 'false'
                    Console.WriteLine("Please specify a hexadecimal number or type 'M' to go back to the menu"); // Ask for the user input
                    userinputString = Console.ReadLine(); // Store it in a string
                    if (userinputString == "M") // Check if that string is 'M' or 'm'
                    {
                        Console.Clear(); // If it is, clear the console
                        menuOption = "M"; // Change the menuOption to break out of the loop
                    }
                    else // If the user types anything else
                    {
                        isHex = Regex.IsMatch(userinputString, @"\A\b[0-9a-fA-F]+\b\Z"); // Assigns the boolean to true or false if it matches the pattern
                        if (isHex == true) // If the user's input matched the pattern (if the user's input contained 0-9 and A-F)
                        {
                            userBinary = Convert.ToString(Convert.ToInt64(userinputString, 16), 2); ; // Converts the hex into an integer using Base-16 and then converting that back to a string using Base-2
                            Console.WriteLine("Decimal: " + userBinary); // Writes the decimal value to the screen
                            Console.ReadLine(); // Waits for user input
                            Console.Clear(); // Clears the console
                        }
                        else // If the user types anything else
                        {
                            while (isHex == false) // While the user's input is invalid
                            {
                                Console.WriteLine("Please specify a hexadecimal number"); // Tell the user to re-enter the hexadecimal number
                                userinputString = Console.ReadLine(); // Read this into a variable
                                isHex = Regex.IsMatch(userinputString, @"\A\b[0-9a-fA-F]+\b\Z"); // Recheck this variable
                            }
                            // When the user enters a valid hexadecimal value:
                            userBinary = Convert.ToString(Convert.ToInt64(userinputString, 16), 2); ; // Converts the hex into an integer using Base-16 and then converting that back to a string using Base-2
                            Console.WriteLine("Decimal: " + userBinary); // Writes the decimal value to the screen
                            Console.ReadLine(); // Waits for user input
                            Console.Clear(); // Clears the console
                        }

                    }
                }
                if (menuOption == "7") // If the user has chosen to exit
                {
                    Environment.Exit(9); // Exit the program safely with code 9
                }
            }
        }
    }
}

