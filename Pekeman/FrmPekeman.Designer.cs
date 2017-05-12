using Pekeman.Map2;

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
            this.Deplacement = new System.Windows.Forms.Timer(this.components);
            this.MapPeke = new Map();
            this.WinStart = new global::Pekeman.WindowStart();
            this.ControlPanel = new global::Pekeman.ControlPanel();
            this.Chat = new global::Pekeman.Chat();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.MapPeke.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerRender
            // 
            this.timerRender.Enabled = true;
            this.timerRender.Interval = 30;
            this.timerRender.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Deplacement
            // 
            this.Deplacement.Enabled = true;
            this.Deplacement.Interval = 200;
            this.Deplacement.Tick += new System.EventHandler(this.Deplacement_Tick);
            // 
            // MapPeke
            // 
            this.MapPeke.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MapPeke.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MapPeke.Controls.Add(this.WinStart);
            this.MapPeke.Controls.Add(this.ControlPanel);
            this.MapPeke.Controls.Add(this.Chat);
            this.MapPeke.Location = new System.Drawing.Point(0, 0);
            this.MapPeke.Name = "MapPeke";
            this.MapPeke.Size = new System.Drawing.Size(1008, 729);
            this.MapPeke.TabIndex = 3;
            // 
            // WinStart
            // 
            this.WinStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.WinStart.BackColor = System.Drawing.Color.Transparent;
            this.WinStart.Location = new System.Drawing.Point(848, 0);
            this.WinStart.Name = "WinStart";
            this.WinStart.Size = new System.Drawing.Size(160, 275);
            this.WinStart.TabIndex = 2;
            // 
            // ControlPanel
            // 
            this.ControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.Controls.Add(this.MapPeke);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(650, 650);
            this.Name = "FrmPekeman";
            this.Text = "Pékéman";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MapPeke.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public Map MapPeke;
        private System.Windows.Forms.Timer timerRender;
        private ControlPanel ControlPanel;
        private Chat Chat;
        private System.Windows.Forms.Timer Deplacement;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public WindowStart WinStart;
    }
}

