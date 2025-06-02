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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblNewDevName = new System.Windows.Forms.Label();
            this.txtNewDevName = new System.Windows.Forms.TextBox();
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
            // lblNewDevName
            // 
            this.lblNewDevName = new System.Windows.Forms.Label();
            this.lblNewDevName.AutoSize = true;
            this.lblNewDevName.Location = new System.Drawing.Point(400, 15); // Adjusted location
            this.lblNewDevName.Name = "lblNewDevName";
            this.lblNewDevName.Size = new System.Drawing.Size(40, 16);
            this.lblNewDevName.TabIndex = 5; // Next TabIndex
            this.lblNewDevName.Text = "Nom:";
            // 
            // txtNewDevName
            // 
            this.txtNewDevName = new System.Windows.Forms.TextBox();
            this.txtNewDevName.Location = new System.Drawing.Point(440, 12); // Adjusted location
            this.txtNewDevName.Name = "txtNewDevName";
            this.txtNewDevName.Size = new System.Drawing.Size(150, 22);
            this.txtNewDevName.TabIndex = 6; // Next TabIndex
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
            // btnAdd
            // 
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAdd.Location = new System.Drawing.Point(600, 11); // Adjusted location
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Ajouter";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnEdit.Location = new System.Drawing.Point(231, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Modifier";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnDelete.Location = new System.Drawing.Point(312, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Supprimer";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // FrmHabilitations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450); // Potentially adjust size if controls overflow
            this.Controls.Add(this.txtNewDevName);
            this.Controls.Add(this.lblNewDevName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
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
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblNewDevName;
        private System.Windows.Forms.TextBox txtNewDevName;
    }
}

