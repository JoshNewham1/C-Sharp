using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    class Program
    {
        private static decimal exchangeRate;

        public static decimal ConvertCurrency(string from, string to)
        {
            var uriString = string.Format("http://finance.yahoo.com/d/quotes.csv?s={0}{1}=X&f=l1", from, to);
            string response = new WebClient().DownloadString(uriString);
            exchangeRate = decimal.Parse(response, System.Globalization.CultureInfo.InvariantCulture);
            return exchangeRate;
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
            Dictionary<string, decimal> volumeConversion = new Dictionary<string, decimal>
            {
                { "ML", 0.001m },
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
            Dictionary<string, decimal> massConversion = new Dictionary<string, decimal>
            {
                { "GK", 0.001m },
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
                Console.WriteLine("What would you like to convert:");
                Console.WriteLine("(T)emperature");
                Console.WriteLine("(C)urrency");
                Console.WriteLine("(V)olume");
                Console.WriteLine("(M)ass");

                unitToConvert = Console.ReadLine().ToUpper();
                if (unitToConvert == "T")
                {
                    Console.WriteLine("Would you like to:");
                    Console.WriteLine("Convert (c)elsius to fahrenheit");
                    Console.WriteLine("Convert (f)ahrenheit to celsius");

                    temperatureMeasurement = Console.ReadLine().ToUpper();
                    if (temperatureMeasurement == "C")
                    {
                        Console.WriteLine("Please specify a number in celsius to convert.");
                        stringInput = Console.ReadLine();
                        doubleInput = Convert.ToDouble(stringInput);
                        fahrenheitConversion = doubleInput * 1.8 + 32;
                        Console.WriteLine(doubleInput + "°C = " + fahrenheitConversion + "°F");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    if (temperatureMeasurement == "F")
                    {
                        Console.WriteLine("Please specify a number in fahrenheit to convert.");
                        stringInput = Console.ReadLine();
                        doubleInput = Convert.ToDouble(stringInput);
                        celsiusConversion = (doubleInput - 32) / 1.8;
                        Console.WriteLine(doubleInput + "°F = " + celsiusConversion + "°C");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                if (unitToConvert == "C")
                {
                    Console.WriteLine("Convert from:");
                    Console.WriteLine("GBP (British Pound)");
                    Console.WriteLine("USD (U.S Dollar)");
                    Console.WriteLine("EUR (Euro)");
                    Console.WriteLine("JPY (Japanese Yen)");
                    Console.WriteLine("CAD (Canadian Dollar)");
                    currencyFrom = Console.ReadLine().ToUpper();

                    Console.WriteLine("Convert to:");
                    Console.WriteLine("GBP (British Pound)");
                    Console.WriteLine("USD (U.S Dollar)");
                    Console.WriteLine("EUR (Euro)");
                    Console.WriteLine("JPY (Japanese Yen)");
                    Console.WriteLine("CAD (Canadian Dollar)");
                    currencyTo = Console.ReadLine().ToUpper();

                    Console.WriteLine("How much would you like to convert? ");
                    stringInput = Console.ReadLine();
                    decimalInput = Convert.ToDecimal(stringInput);

                    while (currencyFrom == currencyTo)
                    {
                        Console.WriteLine("Please select a different currency");
                        currencyTo = Console.ReadLine();
                    }

                    ConvertCurrency(currencyFrom, currencyTo);

                    currencyConversion = decimalInput * exchangeRate;

                    Console.WriteLine(Math.Round(currencyConversion, 2) + " " + currencyTo);
                    Console.ReadLine();
                    Console.Clear();
                }
                if (unitToConvert == "V")
                {
                    Console.WriteLine("Which unit would you like to convert from?");
                    Console.WriteLine("(M)illilitres");
                    Console.WriteLine("(L)itres");
                    Console.WriteLine("(P)ints");
                    Console.WriteLine("(F)luid ounce");
                    Console.WriteLine("(G)allon");
                    volumeFrom = Console.ReadLine().ToUpper();
                    Console.WriteLine("Which unit would you like to convert to?");
                    Console.WriteLine("(M)illilitres");
                    Console.WriteLine("(L)itres");
                    Console.WriteLine("(P)ints");
                    Console.WriteLine("(F)luid ounce");
                    Console.WriteLine("(G)allon");
                    volumeTo = Console.ReadLine().ToUpper();
                    while (volumeFrom == volumeTo)
                    {
                        Console.WriteLine("Please select a different volume measurement");
                        volumeTo = Console.ReadLine();
                    }
                    Console.WriteLine("How much volume would you like to convert?");
                    stringInput = Console.ReadLine();
                    decimalInput = Convert.ToDecimal(stringInput);
                    finalVolume = decimalInput * volumeConversion[volumeFrom + volumeTo];
                    Console.WriteLine(finalVolume);
                    Console.ReadLine();
                    Console.Clear();
                }
                if (unitToConvert == "M")
                {
                    Console.WriteLine("Which unit would you like to convert from:");
                    Console.WriteLine("(G)rams");
                    Console.WriteLine("(K)ilograms");
                    Console.WriteLine("(T)onnes");
                    Console.WriteLine("(S)tone");
                    Console.WriteLine("(P)ound");
                    Console.WriteLine("(O)unce");
                    massFrom = Console.ReadLine().ToUpper();
                    Console.WriteLine("Which unit would you like to convert to:");
                    Console.WriteLine("(G)rams");
                    Console.WriteLine("(K)ilograms");
                    Console.WriteLine("(T)onnes");
                    Console.WriteLine("(S)tone");
                    Console.WriteLine("(P)ound");
                    Console.WriteLine("(O)unce");
                    massTo = Console.ReadLine().ToUpper();
                    while (massFrom == massTo)
                    {
                        Console.WriteLine("Please select a different mass measurement");
                    }
                    Console.WriteLine("How much mass would you like to convert?");
                    stringInput = Console.ReadLine();
                    decimalInput = Convert.ToDecimal(stringInput);
                    finalMass = decimalInput * massConversion[massFrom + massTo];
                    Console.WriteLine(finalMass);
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
