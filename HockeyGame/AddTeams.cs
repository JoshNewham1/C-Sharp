using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HockeyGame
{
    public partial class AddTeams : Form
    {
        public AddTeams(string[][] teams)
        {
            InitializeComponent();
        }

        public void submitButton_Click(object sender, EventArgs e)
        {
            bool nameTaken = false;
            string[][] teams = Main.ReadTeams(); /* Calls the ReadTeams method from Main.cs 
                                                  * to read teams from CSV to 2D array
                                                  */
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i][0] == newTeamNameTextBox.Text) // If the team already exists in the CSV file
                {
                    MessageBox.Show("This team name is already taken. Please choose a different name");
                    nameTaken = true;
                }
            }
            if (nameTaken == false)
            {
                string[] newTeam = new string[7];
                newTeam[0] = newTeamNameTextBox.Text;
                newTeam[1] = playerOneTextBox.Text;
                newTeam[2] = playerTwoTextBox.Text;
                newTeam[3] = playerThreeTextBox.Text;
                newTeam[4] = playerFourTextBox.Text;
                newTeam[5] = playerFiveTextBox.Text;
                newTeam[6] = playerSixTextBox.Text;

                Main.WriteNewTeams(teams, newTeam);
                MessageBox.Show("Team added...");
            }
        }
    }
}
