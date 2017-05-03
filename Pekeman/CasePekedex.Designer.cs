namespace Pekeman
{
    partial class CasePekedex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CasePekedex));
            this.LblNumero = new System.Windows.Forms.Label();
            this.LblType = new System.Windows.Forms.Label();
            this.LblCapturer = new System.Windows.Forms.Label();
            this.LblDesc = new System.Windows.Forms.Label();
            this.LblNom = new System.Windows.Forms.Label();
            this.LblNomI = new System.Windows.Forms.Label();
            this.LblTypeI = new System.Windows.Forms.Label();
            this.LblCapturerI = new System.Windows.Forms.Label();
            this.LblDescI = new System.Windows.Forms.Label();
            this.LblNumI = new System.Windows.Forms.Label();
            this.PnlImgPeke = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // LblNumero
            // 
            this.LblNumero.AutoSize = true;
            this.LblNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumero.ForeColor = System.Drawing.Color.White;
            this.LblNumero.Location = new System.Drawing.Point(22, 23);
            this.LblNumero.Name = "LblNumero";
            this.LblNumero.Size = new System.Drawing.Size(34, 17);
            this.LblNumero.TabIndex = 1;
            this.LblNumero.Text = "No. ";
            this.LblNumero.Click += new System.EventHandler(this.LblNumero_Click);
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblType.ForeColor = System.Drawing.Color.White;
            this.LblType.Location = new System.Drawing.Point(122, 49);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(52, 17);
            this.LblType.TabIndex = 2;
            this.LblType.Text = "Type : ";
            this.LblType.Click += new System.EventHandler(this.label1_Click);
            // 
            // LblCapturer
            // 
            this.LblCapturer.AutoSize = true;
            this.LblCapturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCapturer.ForeColor = System.Drawing.Color.White;
            this.LblCapturer.Location = new System.Drawing.Point(122, 76);
            this.LblCapturer.Name = "LblCapturer";
            this.LblCapturer.Size = new System.Drawing.Size(70, 17);
            this.LblCapturer.TabIndex = 3;
            this.LblCapturer.Text = "Capturé : ";
            this.LblCapturer.Click += new System.EventHandler(this.label2_Click);
            // 
            // LblDesc
            // 
            this.LblDesc.AutoSize = true;
            this.LblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDesc.ForeColor = System.Drawing.Color.White;
            this.LblDesc.Location = new System.Drawing.Point(122, 102);
            this.LblDesc.Name = "LblDesc";
            this.LblDesc.Size = new System.Drawing.Size(87, 17);
            this.LblDesc.TabIndex = 4;
            this.LblDesc.Text = "Description :";
            this.LblDesc.Click += new System.EventHandler(this.LblDesc_Click);
            // 
            // LblNom
            // 
            this.LblNom.AutoSize = true;
            this.LblNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNom.ForeColor = System.Drawing.Color.White;
            this.LblNom.Location = new System.Drawing.Point(122, 23);
            this.LblNom.Name = "LblNom";
            this.LblNom.Size = new System.Drawing.Size(49, 17);
            this.LblNom.TabIndex = 5;
            this.LblNom.Text = "Nom : ";
            // 
            // LblNomI
            // 
            this.LblNomI.AutoSize = true;
            this.LblNomI.ForeColor = System.Drawing.Color.White;
            this.LblNomI.Location = new System.Drawing.Point(215, 27);
            this.LblNomI.Name = "LblNomI";
            this.LblNomI.Size = new System.Drawing.Size(25, 13);
            this.LblNomI.TabIndex = 6;
            this.LblNomI.Text = "???";
            this.LblNomI.Click += new System.EventHandler(this.LblNomI_Click);
            // 
            // LblTypeI
            // 
            this.LblTypeI.AutoSize = true;
            this.LblTypeI.ForeColor = System.Drawing.Color.White;
            this.LblTypeI.Location = new System.Drawing.Point(215, 53);
            this.LblTypeI.Name = "LblTypeI";
            this.LblTypeI.Size = new System.Drawing.Size(25, 13);
            this.LblTypeI.TabIndex = 7;
            this.LblTypeI.Text = "???";
            this.LblTypeI.Click += new System.EventHandler(this.LblTypeI_Click);
            // 
            // LblCapturerI
            // 
            this.LblCapturerI.AutoSize = true;
            this.LblCapturerI.ForeColor = System.Drawing.Color.White;
            this.LblCapturerI.Location = new System.Drawing.Point(215, 80);
            this.LblCapturerI.Name = "LblCapturerI";
            this.LblCapturerI.Size = new System.Drawing.Size(25, 13);
            this.LblCapturerI.TabIndex = 8;
            this.LblCapturerI.Text = "???";
            this.LblCapturerI.Click += new System.EventHandler(this.LblCapturerI_Click);
            // 
            // LblDescI
            // 
            this.LblDescI.AutoSize = true;
            this.LblDescI.ForeColor = System.Drawing.Color.White;
            this.LblDescI.Location = new System.Drawing.Point(215, 106);
            this.LblDescI.Name = "LblDescI";
            this.LblDescI.Size = new System.Drawing.Size(25, 13);
            this.LblDescI.TabIndex = 9;
            this.LblDescI.Text = "???";
            this.LblDescI.Click += new System.EventHandler(this.LblDescI_Click);
            // 
            // LblNumI
            // 
            this.LblNumI.AutoSize = true;
            this.LblNumI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumI.ForeColor = System.Drawing.Color.White;
            this.LblNumI.Location = new System.Drawing.Point(51, 23);
            this.LblNumI.Name = "LblNumI";
            this.LblNumI.Size = new System.Drawing.Size(32, 17);
            this.LblNumI.TabIndex = 10;
            this.LblNumI.Text = "???";
            // 
            // PnlImgPeke
            // 
            this.PnlImgPeke.BackColor = System.Drawing.Color.Transparent;
            this.PnlImgPeke.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PnlImgPeke.BackgroundImage")));
            this.PnlImgPeke.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PnlImgPeke.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PnlImgPeke.Location = new System.Drawing.Point(25, 59);
            this.PnlImgPeke.Name = "PnlImgPeke";
            this.PnlImgPeke.Size = new System.Drawing.Size(60, 60);
            this.PnlImgPeke.TabIndex = 0;
            // 
            // CasePekedex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.LblNumI);
            this.Controls.Add(this.LblDescI);
            this.Controls.Add(this.LblCapturerI);
            this.Controls.Add(this.LblTypeI);
            this.Controls.Add(this.LblNomI);
            this.Controls.Add(this.LblNom);
            this.Controls.Add(this.LblDesc);
            this.Controls.Add(this.LblCapturer);
            this.Controls.Add(this.LblType);
            this.Controls.Add(this.LblNumero);
            this.Controls.Add(this.PnlImgPeke);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "CasePekedex";
            this.Size = new System.Drawing.Size(400, 140);
            this.Load += new System.EventHandler(this.CasePekedex_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel PnlImgPeke;
        private System.Windows.Forms.Label LblNumero;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.Label LblCapturer;
        private System.Windows.Forms.Label LblDesc;
        private System.Windows.Forms.Label LblNom;
        public System.Windows.Forms.Label LblNomI;
        public System.Windows.Forms.Label LblTypeI;
        public System.Windows.Forms.Label LblCapturerI;
        public System.Windows.Forms.Label LblDescI;
        public System.Windows.Forms.Label LblNumI;
    }
}
