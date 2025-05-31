using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using habilitations2024.model;
using habilitations2024.bddmanager;
using MySql.Data.MySqlClient;

namespace habilitations2024.dal
{
    public class ProfilAccess
    {
        // IMPORTANT: Replace with your actual connection string or configuration mechanism
        private readonly string connectionString = "server=localhost;user=habilitations;database=habilitations;password=motdepasseuser";
        private readonly BddManager bddManager;

        public ProfilAccess()
        {
            bddManager = BddManager.GetInstance(connectionString);
        }

        public List<Profil> GetLesProfils()
        {
            List<Profil> lesProfils = new List<Profil>();
            string query = "SELECT idprofil, nom FROM profil ORDER BY nom";
            using (MySqlDataReader reader = bddManager.ReqSelect(query))
            {
                while (reader.Read())
                {
                    lesProfils.Add(new Profil
                    {
                        Id = reader.GetInt32("idprofil"),
                        Nom = reader.GetString("nom")
                    });
                }
            }
            return lesProfils;
        }
    }
}
