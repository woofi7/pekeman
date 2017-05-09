namespace Pekeman
{
    partial class FrmPekeman
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
            this.ControlPanel = new Pekeman.ControlPanel();
            this.Chat = new Pekeman.Chat();
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
            this.map1.Controls.Add(this.ControlPanel);
            this.map1.Controls.Add(this.Chat);
            this.map1.Location = new System.Drawing.Point(0, 0);
            this.map1.Name = "map1";
            this.map1.Size = new System.Drawing.Size(1008, 729);
            this.map1.TabIndex = 3;
            // 
            // ControlPanel
            // 
            this.ControlPanel.BackColor = System.Drawing.Color.Transparent;
            this.ControlPanel.Location = new System.Drawing.Point(808, 529);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(200, 200);
            this.ControlPanel.TabIndex = 1;
            // 
            // Chat
            // 
            this.Chat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Chat.BackColor = System.Drawing.Color.Transparent;
            this.Chat.Location = new System.Drawing.Point(0, 589);
            this.Chat.Name = "Chat";
            this.Chat.Size = new System.Drawing.Size(400, 140);
            this.Chat.TabIndex = 0;
            // 
            // FrmPekeman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.map1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(650, 650);
            this.Name = "FrmPekeman";
            this.Text = "Pékéman";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.map1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Map map1;
        private System.Windows.Forms.Timer timerRender;
        private ControlPanel ControlPanel;
        private Chat Chat;
        private System.Windows.Forms.Timer DeplacementJoueur;
    }
}

