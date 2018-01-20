using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HockeyGame
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void exitButton_click(object sender, EventArgs e) // When the exit button is clicked
        {
            Environment.Exit(9); // Close the app
        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            string[][] teams = ReadTeams(); // Read CSV and store it in a 2D array
            AddTeams createAddTeamsForm = new AddTeams(teams); // Create the add teams menu and pass in the 2D array
            createAddTeamsForm.Show(); // Show the add teams menu
        }



        public static string[][] ReadTeams() // Method to read teams from a CSV file
        {
            string path = "D:\\Git Code\\HockeyGame\\teams.csv"; // Change to where the CSV file is stored
            string[][] teams = File.ReadLines(path).Select(x => x.Split(',')).ToArray();
            return teams;
        }
    }
}
