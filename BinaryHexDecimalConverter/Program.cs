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
                Console.WriteLine("Decimal to (B)inary");
                Console.WriteLine("Decimal to (H)exadecimal");
                Console.WriteLine("Binary to He(x)adecimal");
                Console.WriteLine("Hexadecimal to (D)ecimal");

                menuOption = Console.ReadLine().ToUpper(); // Read the user's choice into a variable and capitalise it

                while (menuOption == "B") // If the user wants to convert decimal to binary
                {
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
                while (menuOption == "H") // If the user chose 'H'
                {
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
                while (menuOption == "X") // If the user has chosen 'X'
                {
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
                while (menuOption == "D") // If the user has chosen 'D'
                {
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
            }
        }
    }
}

