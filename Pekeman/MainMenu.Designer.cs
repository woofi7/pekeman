namespace Pekeman
{
    partial class FrmMainMenu
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
            this.BtnPlay = new System.Windows.Forms.Label();
            this.BtnQuitter = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnPlay
            // 
            this.BtnPlay.BackColor = System.Drawing.Color.Transparent;
            this.BtnPlay.Location = new System.Drawing.Point(349, 99);
            this.BtnPlay.Name = "BtnPlay";
            this.BtnPlay.Size = new System.Drawing.Size(219, 38);
            this.BtnPlay.TabIndex = 0;
            this.BtnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // BtnQuitter
            // 
            this.BtnQuitter.BackColor = System.Drawing.Color.Transparent;
            this.BtnQuitter.Location = new System.Drawing.Point(18, 233);
            this.BtnQuitter.Name = "BtnQuitter";
            this.BtnQuitter.Size = new System.Drawing.Size(219, 38);
            this.BtnQuitter.TabIndex = 1;
            this.BtnQuitter.Click += new System.EventHandler(this.BtnQuitter_Click);
            // 
            // TxtName
            // 
            this.TxtName.Location = new System.Drawing.Point(352, 76);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(100, 20);
            this.TxtName.TabIndex = 2;
            this.TxtName.Text = "Denis";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.BackColor = System.Drawing.Color.Transparent;
            this.LblName.Location = new System.Drawing.Point(349, 60);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(79, 13);
            this.LblName.TabIndex = 3;
            this.LblName.Text = "Nom du joueur:";
            // 
            // FrmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Pekeman.Properties.Resources.mainMenu;
            this.ClientSize = new System.Drawing.Size(589, 332);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.BtnQuitter);
            this.Controls.Add(this.BtnPlay);
            this.Name = "FrmMainMenu";
            this.Text = "Pekeman";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BtnPlay;
        private System.Windows.Forms.Label BtnQuitter;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label LblName;
    }
}