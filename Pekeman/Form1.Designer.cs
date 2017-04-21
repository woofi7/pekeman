namespace Pekeman
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.customGUI1 = new Pekeman.CustomGUI();
            this.controlPanel1 = new Pekeman.ControlPanel();
            this.chat1 = new Pekeman.Chat();
            this.SuspendLayout();
            // 
            // customGUI1
            // 
            this.customGUI1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customGUI1.BackColor = System.Drawing.Color.Transparent;
            this.customGUI1.Location = new System.Drawing.Point(808, 0);
            this.customGUI1.Name = "customGUI1";
            this.customGUI1.Size = new System.Drawing.Size(200, 300);
            this.customGUI1.TabIndex = 2;
            // 
            // controlPanel1
            // 
            this.controlPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.controlPanel1.BackColor = System.Drawing.Color.Transparent;
            this.controlPanel1.Location = new System.Drawing.Point(808, 529);
            this.controlPanel1.Name = "controlPanel1";
            this.controlPanel1.Size = new System.Drawing.Size(200, 200);
            this.controlPanel1.TabIndex = 1;
            // 
            // chat1
            // 
            this.chat1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chat1.BackColor = System.Drawing.Color.Transparent;
            this.chat1.Location = new System.Drawing.Point(0, 589);
            this.chat1.Name = "chat1";
            this.chat1.Size = new System.Drawing.Size(400, 140);
            this.chat1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.customGUI1);
            this.Controls.Add(this.controlPanel1);
            this.Controls.Add(this.chat1);
            this.MinimumSize = new System.Drawing.Size(650, 650);
            this.Name = "Form1";
            this.Text = "Pékéman";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private Chat chat1;
        private ControlPanel controlPanel1;
        private CustomGUI customGUI1;
    }
}

