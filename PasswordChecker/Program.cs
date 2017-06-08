using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

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
        private static string input;
        private static string keyword = "abcdefghijklmnopqrstuvwxyz"; // keyword that the generation of the hash is based off
                                                                      // (the alphabet is not the most secure keyword but this can be changed by the user and all future encryptions/decryptions will use it)
        private static string encryptResult;
        private static string decryptResult;
        private static string decryptedPassword;

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
                Console.WriteLine("(A)dd a username and password to the text document");
                Console.WriteLine("(E)ncrypt a password");
                Console.WriteLine("(D)ecrypt a password");
                Console.WriteLine("E(x)it the program");
                menuoption = Console.ReadLine().ToUpper();

                if (menuoption == "X")
                {
                    Environment.Exit(0);
                }

                if (menuoption == "C")
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
                if (menuoption == "R")
                {
                    StreamReader sr = new StreamReader("C:\\Users\\" + windowsusername + "\\Documents\\PasswordReset.txt");
                    Console.WriteLine("Which username would you like to modify the password of?");
                    specifiedUsername = Console.ReadLine();
                    replaceText = false;
                    while (!sr.EndOfStream) // Cycles through all of the lines of text in the txt file
                    {
                        string username = sr.ReadLine();
                        if (specifiedUsername == username) // Checks if the user has typed a valid username
                        {
                            Console.WriteLine("Please type the password you would like to change");
                            string oldPassword = ReadPassword();
                            string nextLine = sr.ReadLine();
                            DecryptText(nextLine, keyword);
                            decryptedPassword = decryptResult;
                            if (oldPassword == decryptedPassword) // Checks if the user has typed the password below that username
                            {
                                Console.WriteLine("What would you like your new password to be?");
                                newPassword = ReadPassword();
                                while (newPassword.Length < 8)
                                {
                                    Console.WriteLine("Invalid password - please use 8 or more characters");
                                    newPassword = ReadPassword();
                                }

                                while (newPassword.Any(char.IsUpper) != true || newPassword.Any(char.IsLower) != true)
                                {
                                    Console.WriteLine("Invalid password - please use a mixture of upper and lower case characters");
                                    newPassword = ReadPassword();
                                }
                                Console.WriteLine("Please confirm your new password");
                                confirmedPassword = ReadPassword();
                                if (newPassword == confirmedPassword)
                                {
                                    EncryptText(newPassword, keyword);
                                    newPassword = encryptResult;
                                    entireFile = File.ReadAllText("C:\\Users\\" + windowsusername + "\\Documents\\PasswordReset.txt");
                                    entireFile = entireFile.Replace(nextLine, newPassword);
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

                if (menuoption == "A")
                {
                    string [] entireFileArray = File.ReadAllLines("C:\\Users\\" + windowsusername + "\\Documents\\PasswordReset.txt");
                    Console.WriteLine("What would you like your new username to be? ");
                    string newUsername = Console.ReadLine();
                    bool usernameExists = entireFileArray.Contains(newUsername);
                    while (usernameExists == true) {
                        Console.WriteLine("That username already exists, please pick again.");
                        newUsername = Console.ReadLine();
                        usernameExists = entireFileArray.Contains(newUsername);
                    }
                    Console.WriteLine("Please enter your new password.");
                    string NewPassword = ReadPassword();
                    while (NewPassword.Length < 8)
                    {
                        Console.WriteLine("Invalid password - please use 8 or more characters");
                        NewPassword = ReadPassword();
                    }

                    while (NewPassword.Any(char.IsUpper) != true || NewPassword.Any(char.IsLower) != true)
                    {
                        Console.WriteLine("Invalid password - please use a mixture of upper and lower case characters");
                        NewPassword = ReadPassword();
                    }
                    Console.WriteLine("Please confirm your new password.");
                    string ConfirmedPassword = ReadPassword();

                    if (ConfirmedPassword == NewPassword)
                    {
                        EncryptText(NewPassword, keyword);
                        string encryptedPassword = encryptResult;
                        using (StreamWriter sw = File.AppendText("C:\\Users\\" + windowsusername + "\\Documents\\PasswordReset.txt"))
                        {
                            sw.WriteLine(newUsername);
                            sw.WriteLine(encryptedPassword);
                        }
                    }

                }

                if (menuoption == "E")
                {
                    Console.WriteLine("Please type the password you would like to encrypt: ");
                    input = Console.ReadLine();
                    EncryptText(input, keyword);
                    Console.WriteLine(encryptResult);
                    Console.ReadLine();
                    Console.Clear();
                }

                if (menuoption == "D")
                {
                    Console.WriteLine("Please type the hash created from the encryption: ");
                    input = Console.ReadLine();
                    DecryptText(input, keyword);
                    Console.WriteLine(decryptResult);
                    Console.ReadLine();
                    Console.Clear();

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

        public static string DecryptText(string input, string keyword)
        {
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(keyword);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            decryptResult = Encoding.UTF8.GetString(bytesDecrypted);

            return decryptResult;
        }

        public static string EncryptText(string input, string keyword)
        {
            // Get the bytes of the string
            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(keyword);

            // Hash the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            encryptResult = Convert.ToBase64String(bytesEncrypted);

            return encryptResult;
        }

        public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Salt is set here and must be at least 8 bytes
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    // Sets the maximum size of the key (larger keysize = more possibilities)
                    AES.KeySize = 256;
                    // The size of the block of data that is being encrypted (Rijndael has a fixed block size of 128)
                    AES.BlockSize = 128;

                    // Takes a password, salt and iteration count and generates the key
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    // Sets the key for the encryption
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    // Sets the initialisation vector for the encryption (required to generate random keys)
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    // Sets CBC (Cipher Block Chaining) as the mode of operation for AES
                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        // Writes the bytes to CryptoStream which then encrypts them
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray(); // Takes the encrypted bytes from the Memory Stream and adds them to an array
                }
            }

            return encryptedBytes;
        }

        public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Salt is set here and must be at least 8 bytes
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    // Sets the maximum size of the key (larger keysize = more possibilities)
                    AES.KeySize = 256;
                    // The size of the block of data that is being decrypted (Rijndael has a fixed block size of 128)
                    AES.BlockSize = 128;

                    // Takes a password, salt and iteration count and generates the key
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    // Sets the key for the decryption
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    // Sets the initialisation vector for the encryption (required to generate random keys)
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    // Sets CBC (Cipher Block Chaining) as the mode of operation for AES
                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        // Writes the bytes to CryptoStream which then encrypts them
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray(); // Takes the encrypted bytes from the Memory Stream and adds them to an array
                }
            }

            return decryptedBytes;
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
