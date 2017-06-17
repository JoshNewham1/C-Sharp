using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStatGenerator
{
    class Program
    {
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
            int supernaturalChance;
            string[] supernaturalAbilities = { "Antimagic field", "Null psionics field" };
            int rndsupernaturalAbility;
            string charactersupernaturalAbility;
            int spellLikeChance;
            string[] spellLikeAbilities = { "Dispel", "Spell resistance", "Antimagic field", "Attack of Opportunity" };
            int rndspellLikeAbility;
            string characterspellLikeAbility;
            while (true)
            {
                totalPoints = 27;
                Console.Clear();
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.WriteLine("Josh's RPG Stat Generator");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-");
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
                }
                else
                {
                    Console.WriteLine("Extraordinary ability: No");
                }
                // Supernatural abilities are magical and go away in an antimagic field
                supernaturalChance = rnd.Next(1, 10); // 1 in 10 chance
                if (supernaturalChance == 9)
                {
                    rndsupernaturalAbility = rnd.Next(0, supernaturalAbilities.Length);
                    charactersupernaturalAbility = supernaturalAbilities[rndsupernaturalAbility];
                    Console.WriteLine("Supernatural ability: " + charactersupernaturalAbility);
                }
                else
                {
                    Console.WriteLine("Supernatural ability: No");
                }
                // Spell-like abilities are magical and just work like spells
                spellLikeChance = rnd.Next(1, 5);
                if (spellLikeChance == 4)
                {
                    rndspellLikeAbility = rnd.Next(0, spellLikeAbilities.Length);
                    characterspellLikeAbility = spellLikeAbilities[rndspellLikeAbility];
                    Console.WriteLine("Spell-like ability: " + characterspellLikeAbility);
                }
                else
                {
                    Console.WriteLine("Spell-like ability: No");
                }
                Console.ReadLine();
            }
            
        }
    }
}
