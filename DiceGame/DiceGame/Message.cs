using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DiceGame
{
    class Message
    {
        public static string path = Environment.CurrentDirectory + @"\Data\"; // Define a string variable called path and set it to /bin/Debug/data (where the text files are stored)
        public static string GetStartMessage() // GetStartMessage method
        {
            return File.ReadAllText(path + "welcomemessage.txt"); // Read in the text from welcomemessage.txt and return it
        }
        public static string GetDoubleDiceMessage() // GetDoubleDiceMessage method
        {
            string tempText = File.ReadAllText(path + "doubledicemessage.txt"); // Read in all the text from doubledicemessage.txt into a temporary variable
            if (tempText.Contains("*")) // If the text file contains an asterisk
            {
                string diceTotal = (Library.GlobalVariables.diceValue1 + Library.GlobalVariables.diceValue2).ToString(); // Calculate the total of the two dice and store it in a variable
                return tempText.Replace("*", diceTotal);
                /* The text in the .txt file has an asterisk 
                 * where the variable should be inserted,
                 * this code replaces the asterisk in the text
                 * with the total of the two dice and
                 * returns it to the main program
                 */

            }
            else // If the text file doesn't contain an asterisk
            {
                return tempText; // Return the text from doubledicemessage.txt without replacing anything
            }
            
        }
        public static string GetWinMessage() // GetWinMessage method
        {
            string tempText = File.ReadAllText(path + "winmessage.txt"); // Read in all the text from winmessage.txt into a temporary variable
            if (tempText.Contains("*")) // If the text file contains an asterisk
            {
                string totalTurns = Library.GlobalVariables.playerStats.GetValue(Library.GlobalVariables.currentPlayer, 2).ToString();
                /* Fetch the number of turns the current player has taken
                   from the playerStats array and store it in a variable */

                return tempText.Replace("*", totalTurns); // Return the replaced text so it can be displayed
                /* The text in the .txt file has an asterisk 
                 * where the variable should be inserted,
                 * this code replaces the asterisk in the text
                 * with the total number of turns the player has taken
                 * and returns it to the main program
                 */
            }
            else // If the text file doesn't contain an asterisk
            {
                return tempText; // Return the text from winmessage.txt without replacing anything
            }
        }
    }
}
