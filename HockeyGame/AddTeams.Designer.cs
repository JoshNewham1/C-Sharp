namespace HockeyGame
{
    partial class AddTeams
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTeams));
            this.teamNameLabel = new System.Windows.Forms.Label();
            this.teamNameDropDown = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // teamNameLabel
            // 
            this.teamNameLabel.AutoSize = true;
            this.teamNameLabel.Location = new System.Drawing.Point(12, 22);
            this.teamNameLabel.Name = "teamNameLabel";
            this.teamNameLabel.Size = new System.Drawing.Size(68, 13);
            this.teamNameLabel.TabIndex = 0;
            this.teamNameLabel.Text = "Team Name:";
            // 
            // teamNameDropDown
            // 
            this.teamNameDropDown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.teamNameDropDown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.teamNameDropDown.FormattingEnabled = true;
            this.teamNameDropDown.Location = new System.Drawing.Point(86, 19);
            this.teamNameDropDown.Name = "teamNameDropDown";
            this.teamNameDropDown.Size = new System.Drawing.Size(162, 21);
            this.teamNameDropDown.TabIndex = 1;
            // 
            // AddTeams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 328);
            this.Controls.Add(this.teamNameDropDown);
            this.Controls.Add(this.teamNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddTeams";
            this.Text = "Add Teams...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label teamNameLabel;
        private System.Windows.Forms.ComboBox teamNameDropDown;
    }
}