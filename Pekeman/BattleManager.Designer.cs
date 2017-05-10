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
            this.PnlBattleScene = new System.Windows.Forms.Panel();
            this.PnlPeke = new System.Windows.Forms.Panel();
            this.PnlWild = new System.Windows.Forms.Panel();
            this.BtnAttack = new System.Windows.Forms.Button();
            this.BtnCatch = new System.Windows.Forms.Button();
            this.BtnRun = new System.Windows.Forms.Button();
            this.customGUI1 = new Pekeman.CustomGUI();
            this.PnlBattleScene.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlBattleScene
            // 
            this.PnlBattleScene.AllowDrop = true;
            this.PnlBattleScene.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PnlBattleScene.BackgroundImage = global::Pekeman.Properties.Resources.BattleScene;
            this.PnlBattleScene.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlBattleScene.Controls.Add(this.PnlPeke);
            this.PnlBattleScene.Controls.Add(this.PnlWild);
            this.PnlBattleScene.Location = new System.Drawing.Point(0, 0);
            this.PnlBattleScene.Name = "PnlBattleScene";
            this.PnlBattleScene.Size = new System.Drawing.Size(512, 287);
            this.PnlBattleScene.TabIndex = 0;
            // 
            // PnlPeke
            // 
            this.PnlPeke.BackColor = System.Drawing.Color.Transparent;
            this.PnlPeke.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlPeke.Location = new System.Drawing.Point(111, 187);
            this.PnlPeke.Name = "PnlPeke";
            this.PnlPeke.Size = new System.Drawing.Size(100, 100);
            this.PnlPeke.TabIndex = 1;
            // 
            // PnlWild
            // 
            this.PnlWild.BackColor = System.Drawing.Color.Transparent;
            this.PnlWild.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlWild.Location = new System.Drawing.Point(342, 79);
            this.PnlWild.Name = "PnlWild";
            this.PnlWild.Size = new System.Drawing.Size(100, 100);
            this.PnlWild.TabIndex = 0;
            // 
            // BtnAttack
            // 
            this.BtnAttack.BackColor = System.Drawing.Color.Red;
            this.BtnAttack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAttack.Location = new System.Drawing.Point(29, 312);
            this.BtnAttack.Name = "BtnAttack";
            this.BtnAttack.Size = new System.Drawing.Size(132, 50);
            this.BtnAttack.TabIndex = 2;
            this.BtnAttack.Text = "Attack";
            this.BtnAttack.UseVisualStyleBackColor = false;
            this.BtnAttack.Click += new System.EventHandler(this.BtnAttack_Click);
            // 
            // BtnCatch
            // 
            this.BtnCatch.BackColor = System.Drawing.Color.LimeGreen;
            this.BtnCatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCatch.Location = new System.Drawing.Point(190, 312);
            this.BtnCatch.Name = "BtnCatch";
            this.BtnCatch.Size = new System.Drawing.Size(132, 50);
            this.BtnCatch.TabIndex = 3;
            this.BtnCatch.Text = "Catch";
            this.BtnCatch.UseVisualStyleBackColor = false;
            this.BtnCatch.Click += new System.EventHandler(this.button2_Click);
            // 
            // BtnRun
            // 
            this.BtnRun.BackColor = System.Drawing.Color.Yellow;
            this.BtnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRun.Location = new System.Drawing.Point(351, 312);
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(132, 50);
            this.BtnRun.TabIndex = 4;
            this.BtnRun.Text = "Run";
            this.BtnRun.UseVisualStyleBackColor = false;
            this.BtnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // customGUI1
            // 
            this.customGUI1.BackColor = System.Drawing.Color.Transparent;
            this.customGUI1.Location = new System.Drawing.Point(0, 287);
            this.customGUI1.Name = "customGUI1";
            this.customGUI1.Size = new System.Drawing.Size(512, 95);
            this.customGUI1.TabIndex = 1;
            // 
            // BattleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.BtnRun);
            this.Controls.Add(this.BtnCatch);
            this.Controls.Add(this.BtnAttack);
            this.Controls.Add(this.customGUI1);
            this.Controls.Add(this.PnlBattleScene);
            this.DoubleBuffered = true;
            this.Name = "BattleManager";
            this.Size = new System.Drawing.Size(512, 382);
            this.PnlBattleScene.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlBattleScene;
        private System.Windows.Forms.Panel PnlPeke;
        private System.Windows.Forms.Panel PnlWild;
        private CustomGUI customGUI1;
        private System.Windows.Forms.Button BtnAttack;
        private System.Windows.Forms.Button BtnCatch;
        private System.Windows.Forms.Button BtnRun;
    }
}
