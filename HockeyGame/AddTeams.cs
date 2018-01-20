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
            string[][] teams = Main.ReadTeams(); /* Calls the ReadTeams method from Main.cs 
                                                  * to read teams from CSV to 2D array
                                                  */
            for (int i = 0; i < teams[0].Length; i++)
            {
                if (teams[0][i] == newTeamNameTextBox.Text) // If the team already exists in the CSV file
                {
                    MessageBox.Show("This team name is already taken. Please choose a different name");
                }
            }
        }
    }
}
