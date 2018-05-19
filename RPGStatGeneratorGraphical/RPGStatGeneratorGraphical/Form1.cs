using RPGStatGeneratorGraphical.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace RPGStatGeneratorGraphical
{
    public partial class Form1 : Form
    {
        public static string name = "";
        private int count;
        private bool extraordinaryAbility;
        private bool supernaturalAbility;
        private bool spellLikeAbility;
        private string path;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openButton.Enabled = false;
            appendButton.Enabled = false;
            count = 0;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            string[] race = { "Dragonborn", "Dwarf", "Eladrin", "Elf", "Gnome", "Half-elf", "Half-orc", "Halfling", "Human", "Tiefling" };
            string characterRace;
            int rndRace;
            string imageName;
            int rndColour;
            string characterColour = "";
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
            string charactersupernaturalAbility = "";
            int spellLikeChance;
            string[] spellLikeAbilities = { "Dispel", "Spell resistance", "Antimagic field", "Attack of Opportunity" };
            int rndspellLikeAbility;
            string characterspellLikeAbility = "";

            totalPoints = 27;
            // Generate the character's name
            CreateName();
            playerName.Text = name;
            // Generate the character's race
            Random rnd = new Random();
            rndRace = rnd.Next(0, race.Length);
            characterRace = race[rndRace];
            playerRace.Text = characterRace;
            characterRace = characterRace.Replace("Half-", ""); // Removing the "Half-" from the character's race as the images do not have hyphens
            rndColour = rnd.Next(1, 5); // Picks a random colour
            if (rndColour == 1)
            {
                characterColour = "blue";
            }
            else if (rndColour == 2)
            {
                characterColour = "green";
            }
            else if (rndColour == 3)
            {
                characterColour = "orange";
            }
            else if (rndColour == 4)
            {
                characterColour = "pink";
            }
            else if (rndColour == 5)
            {
                characterColour = "red";
            }
            // Gets where the application is executed (in the bin folder) and then adds on the images folder, the character race, character colour and adds on the file extension .png
            imageName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"images\" + characterRace.ToLower() + characterColour + ".png");
            // Puts this path into a bitmap so it can be handled by the ImageBox
            Bitmap bmp = new Bitmap(imageName);
            // Sets the ImageBox to the image
            speciesImage.Image = bmp;
            // Generate the character's gender
            rndGender = rnd.Next(0, gender.Length);
            characterGender = gender[rndGender];
            playerGender.Text = characterGender;
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
                playerStrength.Text = rndStrength.ToString();
                playerMagic.Text = rndMagic.ToString();
                playerDexterity.Text = rndDexterity.ToString();
                // Generate the character's special abilities
                // Extraordinary abilities are nonmagical and quite rare (usually defined by Dungeon Master)
                extraordinaryChance = rnd.Next(1, 50); // 1 in 50 chance
                if (extraordinaryChance == 49)
                {
                    playerExtraordinary.Text = "Yes";
                    extraordinaryAbility = true;
                }
                else
                {
                    playerExtraordinary.Text = "No";
                    extraordinaryAbility = false;
                }
                // Supernatural abilities are magical and go away in an antimagic field
                supernaturalChance = rnd.Next(1, 10); // 1 in 10 chance
                if (supernaturalChance == 9)
                {
                    rndsupernaturalAbility = rnd.Next(0, supernaturalAbilities.Length);
                    charactersupernaturalAbility = supernaturalAbilities[rndsupernaturalAbility];
                    supernaturalAbility = true;
                    playerSupernatural.Text = charactersupernaturalAbility;
                }
                else
                {
                    supernaturalAbility = false;
                    playerSupernatural.Text = "No";
                }
                // Spell-like abilities are magical and just work like spells
                spellLikeChance = rnd.Next(1, 5);
                if (spellLikeChance == 4)
                {
                    rndspellLikeAbility = rnd.Next(0, spellLikeAbilities.Length);
                    characterspellLikeAbility = spellLikeAbilities[rndspellLikeAbility];
                    spellLikeAbility = true;
                    playerSpellLike.Text = characterspellLikeAbility;
                }
                else
                {
                    spellLikeAbility = false;
                    playerSpellLike.Text = "No";
                }
                openButton.Enabled = true;
                appendButton.Enabled = true;
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

        private void playerExtraordinary_Click(object sender, EventArgs e)
        {

        }

        public void openButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = saveFileDialog1.FileName;                
            }
        }

        private void appendButton_Click(object sender, EventArgs e)
        {

            count++;
            StreamWriter txtfile = new StreamWriter(path, append: true);
            txtfile.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-");
            txtfile.WriteLine("Character No. " + count);
            txtfile.WriteLine("Name: " + name);
            txtfile.WriteLine("Race: " + playerRace.Text);
            txtfile.WriteLine("Gender: " + playerGender.Text);
            txtfile.WriteLine("Strength: " + playerStrength.Text);
            txtfile.WriteLine("Magic: " + playerMagic.Text);
            txtfile.WriteLine("Dexterity: " + playerDexterity.Text);
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
                txtfile.WriteLine("Supernatural ability: " + playerSupernatural.Text);
            }
            else
            {
                txtfile.WriteLine("Supernatural ability: No");
            }
            if (spellLikeAbility == true)
            {
                txtfile.WriteLine("Spell-like ability: " + playerSpellLike.Text);
            }
            else
            {
                txtfile.WriteLine("Spell-like ability: No");
            }
            txtfile.Close();

        }
    }
}
