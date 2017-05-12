namespace Pekeman
{
    partial class WindowStart
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnPekedex = new System.Windows.Forms.Button();
            this.BtnPekeman = new System.Windows.Forms.Button();
            this.BtnOption = new System.Windows.Forms.Button();
            this.BtnQuit = new System.Windows.Forms.Button();
            this.BtnAPropos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnPekedex
            // 
            this.BtnPekedex.Location = new System.Drawing.Point(20, 25);
            this.BtnPekedex.Name = "BtnPekedex";
            this.BtnPekedex.Size = new System.Drawing.Size(120, 25);
            this.BtnPekedex.TabIndex = 0;
            this.BtnPekedex.Text = "PeKedex";
            this.BtnPekedex.UseVisualStyleBackColor = true;
            this.BtnPekedex.Click += new System.EventHandler(this.BtnPekedex_Click);
            // 
            // BtnPekeman
            // 
            this.BtnPekeman.Location = new System.Drawing.Point(20, 75);
            this.BtnPekeman.Name = "BtnPekeman";
            this.BtnPekeman.Size = new System.Drawing.Size(120, 25);
            this.BtnPekeman.TabIndex = 1;
            this.BtnPekeman.Text = "PeKeman";
            this.BtnPekeman.UseVisualStyleBackColor = true;
            // 
            // BtnOption
            // 
            this.BtnOption.Location = new System.Drawing.Point(20, 125);
            this.BtnOption.Name = "BtnOption";
            this.BtnOption.Size = new System.Drawing.Size(120, 25);
            this.BtnOption.TabIndex = 2;
            this.BtnOption.Text = "Option";
            this.BtnOption.UseVisualStyleBackColor = true;
            this.BtnOption.Click += new System.EventHandler(this.BtnOption_Click);
            // 
            // BtnQuit
            // 
            this.BtnQuit.Location = new System.Drawing.Point(20, 225);
            this.BtnQuit.Name = "BtnQuit";
            this.BtnQuit.Size = new System.Drawing.Size(120, 25);
            this.BtnQuit.TabIndex = 4;
            this.BtnQuit.Text = "Quitter";
            this.BtnQuit.UseVisualStyleBackColor = true;
            this.BtnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // BtnAPropos
            // 
            this.BtnAPropos.Location = new System.Drawing.Point(20, 175);
            this.BtnAPropos.Name = "BtnAPropos";
            this.BtnAPropos.Size = new System.Drawing.Size(120, 25);
            this.BtnAPropos.TabIndex = 3;
            this.BtnAPropos.Text = "À propos";
            this.BtnAPropos.UseVisualStyleBackColor = true;
            this.BtnAPropos.Click += new System.EventHandler(this.BtnAPropos_Click);
            // 
            // WindowStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnQuit);
            this.Controls.Add(this.BtnAPropos);
            this.Controls.Add(this.BtnOption);
            this.Controls.Add(this.BtnPekeman);
            this.Controls.Add(this.BtnPekedex);
            this.DoubleBuffered = true;
            this.Name = "WindowStart";
            this.Size = new System.Drawing.Size(160, 275);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnPekedex;
        private System.Windows.Forms.Button BtnPekeman;
        private System.Windows.Forms.Button BtnOption;
        private System.Windows.Forms.Button BtnQuit;
        private System.Windows.Forms.Button BtnAPropos;
    }
}
