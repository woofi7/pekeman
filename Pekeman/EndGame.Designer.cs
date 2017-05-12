namespace Pekeman
{
    partial class FrmEndGame
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
            this.BtnQuitter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnQuitter
            // 
            this.BtnQuitter.Location = new System.Drawing.Point(489, 293);
            this.BtnQuitter.Name = "BtnQuitter";
            this.BtnQuitter.Size = new System.Drawing.Size(88, 21);
            this.BtnQuitter.TabIndex = 0;
            this.BtnQuitter.Text = "Quitter";
            this.BtnQuitter.UseVisualStyleBackColor = true;
            this.BtnQuitter.Click += new System.EventHandler(this.BtnQuitter_Click);
            // 
            // FrmEndGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Pekeman.Properties.Resources.imageFinPerdu;
            this.ClientSize = new System.Drawing.Size(589, 326);
            this.Controls.Add(this.BtnQuitter);
            this.Name = "FrmEndGame";
            this.Text = "EndGame";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnQuitter;
    }
}