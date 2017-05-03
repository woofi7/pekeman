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
            this.components = new System.ComponentModel.Container();
            this.timerRender = new System.Windows.Forms.Timer(this.components);
            this.DeplacementJoueur = new System.Windows.Forms.Timer(this.components);
            this.map1 = new Pekeman.Map();
            this.chat1 = new Pekeman.Chat();
            this.controlPanel1 = new Pekeman.ControlPanel();
            this.map1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerRender
            // 
            this.timerRender.Enabled = true;
            this.timerRender.Interval = 30;
            this.timerRender.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DeplacementJoueur
            // 
            this.DeplacementJoueur.Enabled = true;
            this.DeplacementJoueur.Interval = 200;
            this.DeplacementJoueur.Tick += new System.EventHandler(this.DeplacementJoueur_Tick);
            // 
            // map1
            // 
            this.map1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.map1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.map1.Controls.Add(this.controlPanel1);
            this.map1.Controls.Add(this.chat1);
            this.map1.Location = new System.Drawing.Point(0, 0);
            this.map1.Name = "map1";
            this.map1.Size = new System.Drawing.Size(1008, 729);
            this.map1.TabIndex = 3;
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
            // controlPanel1
            // 
            this.controlPanel1.BackColor = System.Drawing.Color.Transparent;
            this.controlPanel1.Location = new System.Drawing.Point(808, 529);
            this.controlPanel1.Name = "controlPanel1";
            this.controlPanel1.Size = new System.Drawing.Size(200, 200);
            this.controlPanel1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.map1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(650, 650);
            this.Name = "Form1";
            this.Text = "Pékéman";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
        private Map map1;
        private System.Windows.Forms.Timer timerRender;
        private ControlPanel controlPanel1;
        private Chat chat1;
        private System.Windows.Forms.Timer DeplacementJoueur;
    }
}

