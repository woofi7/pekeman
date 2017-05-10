namespace Pekeman
{
    partial class BattleManager
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.PnlWild = new System.Windows.Forms.Panel();
            this.PnlPeke = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PnlWild
            // 
            this.PnlWild.BackColor = System.Drawing.Color.Transparent;
            this.PnlWild.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PnlWild.Location = new System.Drawing.Point(355, 113);
            this.PnlWild.Name = "PnlWild";
            this.PnlWild.Size = new System.Drawing.Size(60, 60);
            this.PnlWild.TabIndex = 0;
            // 
            // PnlPeke
            // 
            this.PnlPeke.BackColor = System.Drawing.Color.Transparent;
            this.PnlPeke.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PnlPeke.Location = new System.Drawing.Point(136, 211);
            this.PnlPeke.Name = "PnlPeke";
            this.PnlPeke.Size = new System.Drawing.Size(60, 60);
            this.PnlPeke.TabIndex = 1;
            // 
            // BattleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Pekeman.Properties.Resources.BattleScene;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.PnlPeke);
            this.Controls.Add(this.PnlWild);
            this.DoubleBuffered = true;
            this.Name = "BattleManager";
            this.Size = new System.Drawing.Size(512, 287);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlWild;
        private System.Windows.Forms.Panel PnlPeke;
    }
}
