namespace Pekeman
{
    partial class ControlPanel
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
            this.PctFlecheHaut = new System.Windows.Forms.PictureBox();
            this.PctFlecheBas = new System.Windows.Forms.PictureBox();
            this.PctFlecheDroite = new System.Windows.Forms.PictureBox();
            this.PctFlecheGauche = new System.Windows.Forms.PictureBox();
            this.BtnStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PctFlecheHaut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctFlecheBas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctFlecheDroite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctFlecheGauche)).BeginInit();
            this.SuspendLayout();
            // 
            // PctFlecheHaut
            // 
            this.PctFlecheHaut.BackgroundImage = global::Pekeman.Properties.Resources.fleche_h;
            this.PctFlecheHaut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PctFlecheHaut.Location = new System.Drawing.Point(69, 5);
            this.PctFlecheHaut.Name = "PctFlecheHaut";
            this.PctFlecheHaut.Size = new System.Drawing.Size(62, 80);
            this.PctFlecheHaut.TabIndex = 0;
            this.PctFlecheHaut.TabStop = false;
            this.PctFlecheHaut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PctFlecheHaut_MouseDown);
            this.PctFlecheHaut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PctFlecheHaut_MouseUp);
            // 
            // PctFlecheBas
            // 
            this.PctFlecheBas.BackgroundImage = global::Pekeman.Properties.Resources.fleche_b;
            this.PctFlecheBas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PctFlecheBas.Location = new System.Drawing.Point(69, 114);
            this.PctFlecheBas.Name = "PctFlecheBas";
            this.PctFlecheBas.Size = new System.Drawing.Size(62, 80);
            this.PctFlecheBas.TabIndex = 1;
            this.PctFlecheBas.TabStop = false;
            this.PctFlecheBas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PctFlecheBas_MouseDown);
            this.PctFlecheBas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PctFlecheBas_MouseUp);
            // 
            // PctFlecheDroite
            // 
            this.PctFlecheDroite.BackgroundImage = global::Pekeman.Properties.Resources.fleche_d;
            this.PctFlecheDroite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PctFlecheDroite.Location = new System.Drawing.Point(114, 69);
            this.PctFlecheDroite.Name = "PctFlecheDroite";
            this.PctFlecheDroite.Size = new System.Drawing.Size(80, 62);
            this.PctFlecheDroite.TabIndex = 2;
            this.PctFlecheDroite.TabStop = false;
            this.PctFlecheDroite.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PctFlecheDroite_MouseDown);
            this.PctFlecheDroite.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PctFlecheDroite_MouseUp);
            // 
            // PctFlecheGauche
            // 
            this.PctFlecheGauche.BackgroundImage = global::Pekeman.Properties.Resources.fleche_g;
            this.PctFlecheGauche.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PctFlecheGauche.Location = new System.Drawing.Point(5, 69);
            this.PctFlecheGauche.Name = "PctFlecheGauche";
            this.PctFlecheGauche.Size = new System.Drawing.Size(80, 62);
            this.PctFlecheGauche.TabIndex = 3;
            this.PctFlecheGauche.TabStop = false;
            this.PctFlecheGauche.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PctFlecheGauche_MouseDown);
            this.PctFlecheGauche.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PctFlecheGauche_MouseUp);
            // 
            // BtnStart
            // 
            this.BtnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStart.Location = new System.Drawing.Point(148, 5);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(46, 20);
            this.BtnStart.TabIndex = 4;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.PctFlecheGauche);
            this.Controls.Add(this.PctFlecheDroite);
            this.Controls.Add(this.PctFlecheBas);
            this.Controls.Add(this.PctFlecheHaut);
            this.DoubleBuffered = true;
            this.Name = "ControlPanel";
            this.Size = new System.Drawing.Size(200, 200);
            ((System.ComponentModel.ISupportInitialize)(this.PctFlecheHaut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctFlecheBas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctFlecheDroite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctFlecheGauche)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox PctFlecheHaut;
        public System.Windows.Forms.PictureBox PctFlecheBas;
        public System.Windows.Forms.PictureBox PctFlecheDroite;
        public System.Windows.Forms.PictureBox PctFlecheGauche;
        private System.Windows.Forms.Button BtnStart;
    }
}
