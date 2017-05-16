using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AverageGraphical
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string[] split;
        public static int[] intsplit;
        public static double tempMean;
        public static double median;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void typeofaverage_SelectedIndexChanged(object sender, EventArgs e)
        {   

        }

        private void importButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Import Text File";
            string username = Environment.UserName;
            theDialog.InitialDirectory = @"C:\Users\" + username + @"\Documents";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string line;
                string windowsusername = Environment.UserName;
                string filename = theDialog.FileName;
                StreamReader sr = new StreamReader(filename);
                line = sr.ReadLine();
                if (line.EndsWith(","))
                {
                    line = line.Remove(line.Length - 1); // If there is a comma at the end of the text file, this removes it so it can be interpretted properly.
                }
                sr.Close();
                numberlist.Text = line;
               
            }
        }

        public void numberlist_TextChanged(object sender, EventArgs e)
        {

            string numberList;
            numberList = numberlist.Text;
            split = numberList.Split(',');

        }


        private void calculateButton_Click(object sender, EventArgs e)
        {
            intsplit = split.Select(int.Parse).ToArray();
            if (typeofaverage.SelectedIndex == 0) // If the user has selected 'Mean' from the drop-down list
            {
                foreach (int item in intsplit)
                {
                    tempMean = tempMean + item;
                }
                double totalMean = tempMean / split.Length;

                answer.Show();
                answer.Text = "The mean of those numbers is: " + totalMean;
            }

            else if (typeofaverage.SelectedIndex == 1) // If the user has selected 'Median' from the drop-down list
            {
                if (split.Length % 2 == 0)
                { // Checks if length is even
                    Array.Sort(intsplit);
                    int middle = intsplit.Length / 2;
                    double first = intsplit[middle];
                    double second = intsplit[middle - 1];
                    median = (first + second) / 2;

                }
                if (intsplit.Length % 2 != 0)
                {
                    Array.Sort(intsplit);
                    int middlenumber = (intsplit.Length / 2);
                    median = intsplit[middlenumber];
                }
                answer.Show();
                answer.Text = "The median of those numbers is: " + median;
            }

            else if (typeofaverage.SelectedIndex == 2) // If the user has selected 'Median' from the drop-down list
            {
                int mode = intsplit.GroupBy(i => i) // Groups the same items together
                                   .OrderByDescending(g => g.Count()) // Getting frequency of group
                                   .Select(g => g.Key) // Selecting the key of the group
                                   .First(); // Taking the most frequent value
                answer.Show();
                answer.Text = "The mode of those numbers is: " + mode;
            }
        }

        private void answer_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
