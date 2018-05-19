using System;

namespace AverageGraphical
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.typeofaverage = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.importButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.numberlist = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.answer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Which average would you like to calculate? ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // typeofaverage
            // 
            this.typeofaverage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeofaverage.FormattingEnabled = true;
            this.typeofaverage.Items.AddRange(new object[] {
            "Mean",
            "Median",
            "Mode"});
            this.typeofaverage.Location = new System.Drawing.Point(16, 39);
            this.typeofaverage.Name = "typeofaverage";
            this.typeofaverage.Size = new System.Drawing.Size(104, 21);
            this.typeofaverage.TabIndex = 1;
            this.typeofaverage.SelectedIndexChanged += new System.EventHandler(this.typeofaverage_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Please type a list of numbers or import them from a text file.";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(16, 119);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 6;
            this.importButton.Text = "Import...";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Text Files (*.txt) | *.txt";
            // 
            // numberlist
            // 
            this.numberlist.Location = new System.Drawing.Point(16, 164);
            this.numberlist.Name = "numberlist";
            this.numberlist.Size = new System.Drawing.Size(333, 20);
            this.numberlist.TabIndex = 7;
            this.numberlist.TextChanged += new System.EventHandler(this.numberlist_TextChanged);
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(16, 218);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(75, 23);
            this.calculateButton.TabIndex = 8;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // answer
            // 
            this.answer.AutoSize = true;
            this.answer.Location = new System.Drawing.Point(13, 269);
            this.answer.Name = "answer";
            this.answer.Size = new System.Drawing.Size(35, 13);
            this.answer.TabIndex = 9;
            this.answer.Text = "label3";
            this.answer.Visible = false;
            this.answer.Click += new System.EventHandler(this.answer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 331);
            this.Controls.Add(this.answer);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.numberlist);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.typeofaverage);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Josh\'s Average Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox typeofaverage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox numberlist;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label answer;
    }
}

