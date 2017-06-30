using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnitConverter
{
    class Program
    {
        private static decimal exchangeRate; // Defines the exchange rate in the class so it can be viewed and changed by the ConvertCurrency method

        public static decimal ConvertCurrency(string from, string to) // ConvertCurrency method
        {
            var uriString = string.Format("http://finance.yahoo.com/d/quotes.csv?s={0}{1}=X&f=l1", from, to); // Specifies the exchange rate from and to a currency from a CSV document on Yahoo's website
            string response = new WebClient().DownloadString(uriString); // Downloads the exchange rate from the CSV document
            exchangeRate = decimal.Parse(response, System.Globalization.CultureInfo.InvariantCulture); // Format the exchange rate into a decimal
            return exchangeRate; // Returns the exchange rate to the rest of the program
        }
        static void Main(string[] args)
        {
            string unitToConvert;
            string temperatureMeasurement;
            string stringInput;
            double doubleInput;
            decimal decimalInput = 1000m;
            double fahrenheitConversion;
            double celsiusConversion;
            string currencyFrom;
            string currencyTo;
            decimal currencyConversion;
            string volumeFrom;
            string volumeTo;
            decimal finalVolume;
            string massFrom;
            string massTo;
            decimal finalMass;
            Dictionary<string, decimal> volumeConversion = new Dictionary<string, decimal> // Defines a dictionary with all of the volume conversion numbers in
            {
                { "ML", 0.001m }, // The m after each number signifies it is a decimal
                { "MP",  0.0017598m},
                { "MF",  0.033814m},
                { "MG",  0.000219969m},
                { "LM", 1000m },
                { "LP",  1.7598m},
                { "LF",  35.195m},
                { "LG",  0.219969m},
                { "PM", 568.261m },
                { "PL",  0.568261m},
                { "PF",  20m},
                { "PG",  0.125m},
                { "FM", 28.4131m },
                { "FL",  0.0284131m},
                { "FP",  0.05m},
                { "FG",  0.00625m},
                { "GM", 4546.09m },
                { "GL",  4.54609m},
                { "GF",  160m},
                { "GP",  8m}
            };
            Dictionary<string, decimal> massConversion = new Dictionary<string, decimal> // Defines a dictionary with all of the mass conversion numbers in
            {
                { "GK", 0.001m }, // The m after each number signifies it is a decimal
                { "GT",  0.001000000m},
                { "GS",  0.000157473m},
                { "GP",  0.00220462m},
                { "GO", 0.035274m },
                { "KG",  1000m },
                { "KT",  0.001m },
                { "KS",  0.157473m },
                { "KP", 2.20462m },
                { "KO",  35.274m },
                { "TG",  1000000m },
                { "TK",  1000m },
                { "TS", 157.473m },
                { "TP",  2204.62m },
                { "TO",  35274m},
                { "SG",  6350.29m},
                { "SK", 6.35029m },
                { "ST",  0.00635029m},
                { "SP",  14m},
                { "SO",  224m},
                { "PG",  453.592m},
                { "PK", 0.453592m },
                { "PT",  0.000453592m},
                { "PS",  0.0714286m},
                { "PO",  16m},
                { "OG",  28.3495m},
                { "OK", 0.0283495m },
                { "OT",  0.00002834952m},
                { "OS",  0.00446429m},
                { "OP",  0.0625m}
            };
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("Josh's Unit Converter");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");

            while (true)
            {
                Console.WriteLine("What would you like to convert:"); // Asks the user what they would like to convert
                Console.WriteLine("(T)emperature");
                Console.WriteLine("(C)urrency");
                Console.WriteLine("(V)olume");
                Console.WriteLine("(M)ass");

                unitToConvert = Console.ReadLine().ToUpper(); // Reads this into a variable and capitalises it
                if (unitToConvert == "T") // If the user wants to convert temperature
                {
                    Console.WriteLine("Would you like to:"); // Asks the user which way they would like to convert it
                    Console.WriteLine("Convert (c)elsius to fahrenheit");
                    Console.WriteLine("Convert (f)ahrenheit to celsius");
                    temperatureMeasurement = Console.ReadLine().ToUpper(); // Reads this into a variable and capitalises it
                    if (temperatureMeasurement == "C") // If they want to convert celsius to fahrenheit
                    {
                        Console.WriteLine("Please specify a number in celsius to convert."); // Asks the user how many celsius they would like to convert
                        stringInput = Console.ReadLine(); // Reads the string into a variable
                        doubleInput = Convert.ToDouble(stringInput); // Converts the string to a double
                        fahrenheitConversion = doubleInput * 1.8 + 32; // The formula of converting celsius into fahrenheit (x1.8 + 32)
                        Console.WriteLine(doubleInput + "°C = " + fahrenheitConversion + "°F"); // Prints the converted number
                        Console.ReadLine(); // Waits for user input
                        Console.Clear(); // Waits for user input
                    }
                    if (temperatureMeasurement == "F") // If the user wants to convert fahrenheit to celsius
                    {
                        Console.WriteLine("Please specify a number in fahrenheit to convert."); // Asks the user how many celsius they would like to convert
                        stringInput = Console.ReadLine(); // Reads the string into a variable
                        doubleInput = Convert.ToDouble(stringInput); // Converts the string to a double
                        celsiusConversion = (doubleInput - 32) / 1.8; // The formula of converting fahrenheit into celsius (-32 / 1.8)
                        Console.WriteLine(doubleInput + "°F = " + celsiusConversion + "°C"); // Prints the converted number
                        Console.ReadLine(); // Waits for user input
                        Console.Clear(); // Waits for user input
                    }
                }
                if (unitToConvert == "C") // If the user wants to convert currency
                {
                    Console.WriteLine("Convert from:"); // Ask the user what they would like to convert from
                    Console.WriteLine("GBP (British Pound)");
                    Console.WriteLine("USD (U.S Dollar)");
                    Console.WriteLine("EUR (Euro)");
                    Console.WriteLine("JPY (Japanese Yen)");
                    Console.WriteLine("CAD (Canadian Dollar)");
                    currencyFrom = Console.ReadLine().ToUpper(); // Read this into a variable and capitalise it

                    Console.WriteLine("Convert to:"); // Ask the user what they would like to convert to
                    Console.WriteLine("GBP (British Pound)");
                    Console.WriteLine("USD (U.S Dollar)");
                    Console.WriteLine("EUR (Euro)");
                    Console.WriteLine("JPY (Japanese Yen)");
                    Console.WriteLine("CAD (Canadian Dollar)");
                    currencyTo = Console.ReadLine().ToUpper(); // Read this into a variable and capitalise it

                    Console.WriteLine("How much would you like to convert? "); // Asks the user how much they would like to convert
                    stringInput = Console.ReadLine(); // Reads this string into a variable
                    stringInput = Regex.Replace(stringInput, "[^0-9A-Za-z]+", ""); // Strips the input of any special characters (such as currency signs)
                    decimalInput = Convert.ToDecimal(stringInput); // Converts it to decimal

                    while (currencyFrom == currencyTo) // While the currency converting from is the same as the currency converting to
                    {
                        Console.WriteLine("Please select a different currency"); // Asks the user to select a different currency
                        currencyTo = Console.ReadLine(); // Reads their new currency into a variable
                    }

                    ConvertCurrency(currencyFrom, currencyTo); // Calls the ConvertCurrency method and passes through the currencyFrom and currencyTo

                    currencyConversion = decimalInput * exchangeRate; // Multiplies the input with the exchange rate

                    Console.WriteLine(Math.Round(currencyConversion, 2) + " " + currencyTo); // Prints out the rounded conversion
                    Console.ReadLine(); // Waits for user input
                    Console.Clear(); // Clears the screen
                }
                if (unitToConvert == "V") // If the user wants to convert volume
                {
                    Console.WriteLine("Which unit would you like to convert from?"); // Ask the user what they would like to convert from
                    Console.WriteLine("(M)illilitres");
                    Console.WriteLine("(L)itres");
                    Console.WriteLine("(P)ints");
                    Console.WriteLine("(F)luid ounce");
                    Console.WriteLine("(G)allon");
                    volumeFrom = Console.ReadLine().ToUpper(); // Read this into a variable and capitalise it
                    Console.WriteLine("Which unit would you like to convert to?"); // Ask the user what they would like to convert to
                    Console.WriteLine("(M)illilitres");
                    Console.WriteLine("(L)itres");
                    Console.WriteLine("(P)ints");
                    Console.WriteLine("(F)luid ounce");
                    Console.WriteLine("(G)allon");
                    volumeTo = Console.ReadLine().ToUpper(); // Read this into a variable and capitalise it
                    while (volumeFrom == volumeTo) // While the volume measurement converting from is the same as the volume measurement converting to
                    {
                        Console.WriteLine("Please select a different volume measurement"); // Asks the user to select a different measurement
                        volumeTo = Console.ReadLine(); // Reads this into a variable
                    }
                    Console.WriteLine("How much volume would you like to convert?"); // Asks the user how much they want to convert
                    stringInput = Console.ReadLine(); // Reads this string in to a variable
                    decimalInput = Convert.ToDecimal(stringInput); // Converts this to decimal
                    finalVolume = decimalInput * volumeConversion[volumeFrom + volumeTo]; // Multiplies the decimal by the conversion formula in the dictionary (volumeFrom + volumeTo is how the dictionary is layed out)
                    Console.WriteLine(finalVolume); // Prints the converted volume
                    Console.ReadLine(); // Waits for user input
                    Console.Clear(); // Clears the screen
                }
                if (unitToConvert == "M") // If the user wants to convert mass
                {
                    Console.WriteLine("Which unit would you like to convert from:"); // Ask the user what they would like to convert from
                    Console.WriteLine("(G)rams");
                    Console.WriteLine("(K)ilograms");
                    Console.WriteLine("(T)onnes");
                    Console.WriteLine("(S)tone");
                    Console.WriteLine("(P)ound");
                    Console.WriteLine("(O)unce");
                    massFrom = Console.ReadLine().ToUpper(); // Read this into a variable and capitalise it
                    Console.WriteLine("Which unit would you like to convert to:"); // Ask the user what they would like to convert to
                    Console.WriteLine("(G)rams");
                    Console.WriteLine("(K)ilograms");
                    Console.WriteLine("(T)onnes");
                    Console.WriteLine("(S)tone");
                    Console.WriteLine("(P)ound");
                    Console.WriteLine("(O)unce");
                    massTo = Console.ReadLine().ToUpper(); // Read this into a variable and capitalise it
                    while (massFrom == massTo) // While the mass measurement converting from is the same as the mass measurement converting to
                    {
                        Console.WriteLine("Please select a different mass measurement"); // Asks the user to select a different mass measurement
                        massTo = Console.ReadLine(); // Reads this into a variable
                    }
                    Console.WriteLine("How much mass would you like to convert?"); // Asks the user how much they would like to convert
                    stringInput = Console.ReadLine(); // Stores this string in a variable
                    decimalInput = Convert.ToDecimal(stringInput); // Conevrts the string to a decimal
                    finalMass = decimalInput * massConversion[massFrom + massTo]; // Multiplies the decimal by the conversion formula in the dictionary (massFrom + massTo is how the dictionary is layed out)
                    Console.WriteLine(finalMass); // Print the converted mass
                    Console.ReadLine(); // Wait for user input
                    Console.Clear(); // Clears the screen
                }
            }
        }
    }
}
