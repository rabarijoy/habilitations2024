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
    }
}
