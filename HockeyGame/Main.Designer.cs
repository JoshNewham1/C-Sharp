namespace HockeyGame
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.addTeamButton = new System.Windows.Forms.Button();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.updateTeamButton = new System.Windows.Forms.Button();
            this.createReportButton = new System.Windows.Forms.Button();
            this.leaderboardButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addTeamButton
            // 
            this.addTeamButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTeamButton.Location = new System.Drawing.Point(12, 73);
            this.addTeamButton.Name = "addTeamButton";
            this.addTeamButton.Size = new System.Drawing.Size(105, 50);
            this.addTeamButton.TabIndex = 0;
            this.addTeamButton.Text = "Add Team...";
            this.addTeamButton.UseVisualStyleBackColor = true;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.Location = new System.Drawing.Point(51, 9);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(377, 40);
            this.welcomeLabel.TabIndex = 1;
            this.welcomeLabel.Text = "                    Welcome to Hockey Game. \r\nPlease select one of the buttons be" +
    "low to continue...";
            // 
            // playButton
            // 
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.Location = new System.Drawing.Point(177, 73);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(107, 50);
            this.playButton.TabIndex = 2;
            this.playButton.Text = "Play Game...";
            this.playButton.UseVisualStyleBackColor = true;
            // 
            // updateTeamButton
            // 
            this.updateTeamButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateTeamButton.Location = new System.Drawing.Point(345, 73);
            this.updateTeamButton.Name = "updateTeamButton";
            this.updateTeamButton.Size = new System.Drawing.Size(127, 50);
            this.updateTeamButton.TabIndex = 3;
            this.updateTeamButton.Text = "Update Team...";
            this.updateTeamButton.UseVisualStyleBackColor = true;
            // 
            // createReportButton
            // 
            this.createReportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createReportButton.Location = new System.Drawing.Point(12, 165);
            this.createReportButton.Name = "createReportButton";
            this.createReportButton.Size = new System.Drawing.Size(460, 50);
            this.createReportButton.TabIndex = 4;
            this.createReportButton.Text = "Create Report...";
            this.createReportButton.UseVisualStyleBackColor = true;
            // 
            // leaderboardButton
            // 
            this.leaderboardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderboardButton.Location = new System.Drawing.Point(12, 375);
            this.leaderboardButton.Name = "leaderboardButton";
            this.leaderboardButton.Size = new System.Drawing.Size(115, 28);
            this.leaderboardButton.TabIndex = 5;
            this.leaderboardButton.Text = "Leaderboard";
            this.leaderboardButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(414, 375);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 421);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.leaderboardButton);
            this.Controls.Add(this.createReportButton);
            this.Controls.Add(this.updateTeamButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.addTeamButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Hockey Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addTeamButton;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button updateTeamButton;
        private System.Windows.Forms.Button createReportButton;
        private System.Windows.Forms.Button leaderboardButton;
        private System.Windows.Forms.Button button1;
    }
}

