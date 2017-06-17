using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStatGenerator
{
    class Program
    {

        public static string name = "";
        static void Main(string[] args)
        {
            string[] race = { "Dragonborn", "Dwarf", "Eladrin", "Elf", "Gnome", "Half-elf", "Half-orc", "Halfling", "Human", "Tiefling" };
            int rndRace;
            string characterRace;
            string[] gender = { "Male", "Female" };
            int rndGender;
            string characterGender;
            int totalPoints = 27;
            int rndStrength;
            int rndMagic;
            int rndDexterity;
            float leftoverPoints;
            int leftoverPointsInt;
            int extraordinaryChance;
            bool extraordinaryAbility = false;
            int supernaturalChance;
            bool supernaturalAbility = false;
            string[] supernaturalAbilities = { "Antimagic field", "Null psionics field" };
            int rndsupernaturalAbility;
            string charactersupernaturalAbility = "";
            int spellLikeChance;
            string[] spellLikeAbilities = { "Dispel", "Spell resistance", "Antimagic field", "Attack of Opportunity" };
            int rndspellLikeAbility;
            bool spellLikeAbility = false;
            string characterspellLikeAbility = "";
            string savetotxtDoc;
            string windowsusername = Environment.UserName;
            string path = "C:\\Users\\" + windowsusername + "\\Documents\\RPGCharacters.txt";
            int count = 0;
            while (true)
            {
                totalPoints = 27;
                Console.Clear();
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Josh's RPG Stat Generator");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-");
                // Generate the character's name
                CreateName();
                Console.WriteLine("First Name: " + name);
                // Generate the character's race
                Random rnd = new Random();
                rndRace = rnd.Next(0, race.Length);
                characterRace = race[rndRace];
                Console.WriteLine("Race: " + characterRace);
                // Generate the character's gender
                rndGender = rnd.Next(0, gender.Length);
                characterGender = gender[rndGender];
                Console.WriteLine("Gender: " + characterGender);
                // Generate the character's points
                rndStrength = rnd.Next(1, totalPoints);
                totalPoints = totalPoints - rndStrength;
                rndMagic = rnd.Next(1, totalPoints);
                totalPoints = totalPoints - rndMagic;
                if (totalPoints == 0)
                {
                    rndDexterity = 0;
                }
                else
                {
                    rndDexterity = rnd.Next(1, totalPoints);
                }
                totalPoints = totalPoints - rndDexterity;
                if (totalPoints != 0) // If the points haven't been fully used up
                {
                    leftoverPoints = totalPoints / 3; // Share the leftover points between the different stats
                    leftoverPointsInt = Convert.ToInt32(leftoverPoints); // Round this decimal
                    rndStrength = rndStrength + leftoverPointsInt; // Add the leftover points to strength
                    rndMagic = rndMagic + leftoverPointsInt; // Add the leftover points to magic
                    rndDexterity = rndDexterity + leftoverPointsInt; // Add the leftover points to dexterity
                    // NOTE: Points are not added on if the leftover points cannot be shared equally so the total number of points will not always equal 27
                }
                Console.WriteLine("Strength: " + rndStrength);
                Console.WriteLine("Magic: " + rndMagic);
                Console.WriteLine("Dexterity: " + rndDexterity);
                // Generate the character's special abilities
                // Extraordinary abilities are nonmagical and quite rare (usually defined by Dungeon Master)
                extraordinaryChance = rnd.Next(1, 50); // 1 in 50 chance
                if (extraordinaryChance == 49)
                {
                    Console.WriteLine("Extraordinary ability: Yes");
                    extraordinaryAbility = true;
                }
                else
                {
                    Console.WriteLine("Extraordinary ability: No");
                    extraordinaryAbility = false;
                }
                // Supernatural abilities are magical and go away in an antimagic field
                supernaturalChance = rnd.Next(1, 10); // 1 in 10 chance
                if (supernaturalChance == 9)
                {
                    rndsupernaturalAbility = rnd.Next(0, supernaturalAbilities.Length);
                    charactersupernaturalAbility = supernaturalAbilities[rndsupernaturalAbility];
                    supernaturalAbility = true;
                    Console.WriteLine("Supernatural ability: " + charactersupernaturalAbility);
                }
                else
                {
                    supernaturalAbility = false;
                    Console.WriteLine("Supernatural ability: No");
                }
                // Spell-like abilities are magical and just work like spells
                spellLikeChance = rnd.Next(1, 5);
                if (spellLikeChance == 4)
                {
                    rndspellLikeAbility = rnd.Next(0, spellLikeAbilities.Length);
                    characterspellLikeAbility = spellLikeAbilities[rndspellLikeAbility];
                    spellLikeAbility = true;
                    Console.WriteLine("Spell-like ability: " + characterspellLikeAbility);
                }
                else
                {
                    spellLikeAbility = false;
                    Console.WriteLine("Spell-like ability: No");
                }
                Console.WriteLine("Would you like to save your character to a text document? (Y) or (N)");
                savetotxtDoc = Console.ReadLine().ToUpper();
                if (savetotxtDoc == "Y")
                {
                    count++;
                    StreamWriter txtfile = new StreamWriter(path, append: true);
                    txtfile.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-");
                    txtfile.WriteLine("Character No. " + count);
                    txtfile.WriteLine("Name: " + name);
                    txtfile.WriteLine("Race: " + characterRace);
                    txtfile.WriteLine("Gender: " + characterGender);
                    txtfile.WriteLine("Strength: " + rndStrength);
                    txtfile.WriteLine("Magic: " + rndMagic);
                    txtfile.WriteLine("Dexterity: " + rndDexterity);
                    if (extraordinaryAbility == true)
                    {
                        txtfile.WriteLine("Extraordinary ability: Yes");
                    }
                    else
                    {
                        txtfile.WriteLine("Extraordinary ability: No");
                    }
                    if (supernaturalAbility == true)
                    {
                        txtfile.WriteLine("Supernatural ability: " + charactersupernaturalAbility);
                    }
                    else
                    {
                        txtfile.WriteLine("Supernatural ability: No");
                    }
                    if (spellLikeAbility == true)
                    {
                        txtfile.WriteLine("Spell-like ability: " + characterspellLikeAbility);
                    }
                    else
                    {
                        txtfile.WriteLine("Spell-like ability: No");
                    }
                    txtfile.Close();
                    Console.WriteLine("Written to text file successfully.");
                    Console.ReadLine();
                }
                
            }
            string CreateName()
            {
                Random rnd = new Random();
                string[] firstnameSyllables = { "mon", "fay", "shi", "zag", "blarg", "rash", "izen", "ro", "shan", "von" };
                string[] lastnameSyllables = { "rah", "osu", "come", "stalker", "fer", "young", "dan", "dusk", "helm", "le", "spell", "bane", "fire", "water", "blade", "peace", "luna", "morning" };
                string firstName = "";
                int numberofSyllablesInFirstName = rnd.Next(2, 4);
                for (int i = 0; i < numberofSyllablesInFirstName; i++)
                {
                    firstName += firstnameSyllables[rnd.Next(0, firstnameSyllables.Length)];
                }
                string firstNameLetter = firstName.Substring(0, 1);
                firstName = firstName.Remove(0, 1);
                firstNameLetter = firstNameLetter.ToUpper();
                firstName = firstNameLetter + firstName;
                string lastName = "";
                int numberofSyllablesInLastName = rnd.Next(2, 3);
                for (int i = 0; i < numberofSyllablesInLastName; i++)
                {
                    lastName += lastnameSyllables[rnd.Next(0, lastnameSyllables.Length)];
                }
                string lastnameLetter = lastName.Substring(0, 1);
                lastName = lastName.Remove(0, 1);
                lastnameLetter = lastnameLetter.ToUpper();
                lastName = lastnameLetter + lastName;
                name = firstName + " " + lastName;
                return name;
            }
        }
        
    }
}
