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
            for (int i = 0; i < teams[0].Length; i++)
            {
                teamNameDropDown.Items.Add(teams[i][0]);
            }
        }
    }
}
