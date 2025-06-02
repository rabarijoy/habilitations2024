using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using habilitations2024.dal;
using habilitations2024.model;

namespace habilitations2024.view
{
    public partial class FrmHabilitations : Form
    {
        private readonly ProfilAccess profilAccess;
        private readonly DeveloppeurAccess developpeurAccess;

        public FrmHabilitations()
        {
            InitializeComponent();
            profilAccess = new ProfilAccess();
            developpeurAccess = new DeveloppeurAccess();
            this.Load += new System.EventHandler(this.FrmHabilitations_Load);
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
        }

        private void FrmHabilitations_Load(object sender, EventArgs e)
        {
            // Populate Profil ComboBox
            List<Profil> listeProfils = profilAccess.GetLesProfils();
            cbxProfil.Items.Add(""); // Empty line
            foreach (var profil in listeProfils)
            {
                cbxProfil.Items.Add(profil.Nom); // Use profil.Nom
            }
            cbxProfil.SelectedIndex = 0;

            // Subscribe to SelectedIndexChanged event
            cbxProfil.SelectedIndexChanged += CbxProfil_SelectedIndexChanged;

            // Initial load of developers (all)
            LoadDeveloppeurs(null);
        }

        private void CbxProfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selectedProfilNom = cbxProfil.SelectedItem?.ToString();
            LoadDeveloppeurs(selectedProfilNom);
        }

        private void LoadDeveloppeurs(string? profilNom)
        {
            var listeDevs = developpeurAccess.GetLesDeveloppeurs(profilNom);
            dgvDeveloppeurs.DataSource = null; // Clear previous data
            dgvDeveloppeurs.DataSource = listeDevs;
            // You might want to configure columns, e.g.:
            // dgvDeveloppeurs.Columns["Id"].Visible = false;
            // dgvDeveloppeurs.Columns["Profil"].HeaderText = "Profil"; 
            // etc.
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string newDevName = txtNewDevName.Text.Trim();
            if (string.IsNullOrWhiteSpace(newDevName))
            {
                MessageBox.Show("Veuillez entrer un nom pour le nouveau développeur.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewDevName.Focus();
                return;
            }

            string? selectedProfilNomInComboBox = cbxProfil.SelectedItem?.ToString();
            Profil? targetProfil = null;

            if (string.IsNullOrEmpty(selectedProfilNomInComboBox)) // "All" profiles are selected
            {
                // If "All" is selected in ComboBox, we need a specific profile for the new developer.
                // Option 1: Prompt user or use a default. For now, try to use the first available actual profile.
                targetProfil = profilAccess.GetLesProfils().FirstOrDefault();
                if (targetProfil == null)
                {
                    MessageBox.Show("Aucun profil n'est disponible dans la base de données pour assigner au nouveau développeur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                targetProfil = profilAccess.GetLesProfils().FirstOrDefault(p => p.Nom == selectedProfilNomInComboBox);
            }

            if (targetProfil == null) // Should not happen if profiles exist and selection is valid
            {
                MessageBox.Show("Profil sélectionné invalide ou aucun profil disponible.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Developpeur newDev = new Developpeur
            {
                Nom = newDevName, // Use name from TextBox
                Prenom = "(Prénom à définir)", // Placeholder
                Mail = newDevName.ToLower() + "@example.com", // Placeholder
                Tel = "(Téléphone à définir)", // Placeholder
                Profil = targetProfil
            };

            if (developpeurAccess.AddDeveloppeur(newDev))
            {
                MessageBox.Show($"Développeur '{newDev.Nom}' (Profil: {targetProfil.Nom}) ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewDevName.Clear();
                LoadDeveloppeurs(cbxProfil.SelectedItem?.ToString()); // Refresh list respecting current filter
            }
            else
            {
                MessageBox.Show("Erreur lors de l'ajout du développeur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDeveloppeurs.CurrentRow == null || dgvDeveloppeurs.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un développeur à modifier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Developpeur selectedDev = (Developpeur)dgvDeveloppeurs.CurrentRow.DataBoundItem;
            
            // For simplicity, we'll just change the name and assign to 'admin' profile for testing.
            // A real app would open a dialog to edit details.
            selectedDev.Nom = selectedDev.Nom + "_Modifié";
            Profil adminProfil = profilAccess.GetLesProfils().FirstOrDefault(p => p.Nom == "admin");
             if (adminProfil == null && profilAccess.GetLesProfils().Any())
            {
                 adminProfil = profilAccess.GetLesProfils().First(); // Fallback to first profile
            }

            if(adminProfil != null) selectedDev.Profil = adminProfil;

            if (developpeurAccess.UpdateDeveloppeur(selectedDev))
            {
                MessageBox.Show($"Développeur '{selectedDev.Nom}' (Profil: {selectedDev.Profil?.Nom}) modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDeveloppeurs(cbxProfil.SelectedItem?.ToString());
            }
            else
            {
                MessageBox.Show("Erreur lors de la modification du développeur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDeveloppeurs.CurrentRow == null || dgvDeveloppeurs.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un développeur à supprimer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Developpeur selectedDev = (Developpeur)dgvDeveloppeurs.CurrentRow.DataBoundItem;

            if (MessageBox.Show($"Êtes-vous sûr de vouloir supprimer {selectedDev.Prenom} {selectedDev.Nom} (Profil: {selectedDev.Profil?.Nom})?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (developpeurAccess.DeleteDeveloppeur(selectedDev.Id))
                {
                    MessageBox.Show($"Développeur '{selectedDev.Nom}' (Profil: {selectedDev.Profil?.Nom}) supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDeveloppeurs(cbxProfil.SelectedItem?.ToString());
                }
                else
                {
                    MessageBox.Show("Erreur lors de la suppression du développeur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
