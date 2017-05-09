namespace Pekeman
{
    partial class Chat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
            this.Content = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Content
            // 
            this.Content.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Content.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Content.Location = new System.Drawing.Point(5, 5);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(390, 130);
            this.Content.TabIndex = 0;
            this.Content.Text = resources.GetString("Content.Text");
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Content);
            this.DoubleBuffered = true;
            this.Name = "Chat";
            this.Size = new System.Drawing.Size(400, 140);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Content;
    }
}
