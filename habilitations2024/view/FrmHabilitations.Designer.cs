namespace habilitations2024.view
{
    partial class FrmHabilitations
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
            this.cbxProfil = new System.Windows.Forms.ComboBox();
            this.dgvDeveloppeurs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeveloppeurs)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxProfil
            // 
            this.cbxProfil.FormattingEnabled = true;
            this.cbxProfil.Location = new System.Drawing.Point(12, 12); // Example location
            this.cbxProfil.Name = "cbxProfil";
            this.cbxProfil.Size = new System.Drawing.Size(121, 24); // Example size
            this.cbxProfil.TabIndex = 0;
            // 
            // dgvDeveloppeurs
            // 
            this.dgvDeveloppeurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeveloppeurs.Location = new System.Drawing.Point(12, 42); // Example location below ComboBox
            this.dgvDeveloppeurs.Name = "dgvDeveloppeurs";
            this.dgvDeveloppeurs.RowHeadersWidth = 51;
            this.dgvDeveloppeurs.RowTemplate.Height = 24;
            this.dgvDeveloppeurs.Size = new System.Drawing.Size(776, 396); // Example size
            this.dgvDeveloppeurs.TabIndex = 1;
            // 
            // FrmHabilitations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvDeveloppeurs);
            this.Controls.Add(this.cbxProfil);
            this.Name = "FrmHabilitations";
            this.Text = "Habilitations";
            this.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeveloppeurs)).EndInit();
        }

        #endregion

        private System.Windows.Forms.ComboBox cbxProfil;
        private System.Windows.Forms.DataGridView dgvDeveloppeurs;
    }
}

