using habilitations2024.model;
using habilitations2024.bddmanager;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System;

namespace habilitations2024.dal
{
    public class DeveloppeurAccess
    {
        private readonly string connectionString = "server=localhost;user=habilitations;database=habilitations;password=motdepasseuser";
        private readonly BddManager bddManager;

        public DeveloppeurAccess()
        {
            bddManager = BddManager.GetInstance(connectionString);
        }

        public List<Developpeur> GetLesDeveloppeurs(string? profilNom = null)
        {
            List<Developpeur> lesDeveloppeurs = new List<Developpeur>();
            string query = "SELECT d.iddeveloppeur, d.nom, d.prenom, d.tel, d.mail, p.idprofil, p.nom AS profilNom " +
                           "FROM developpeur d JOIN profil p ON d.idprofil = p.idprofil";

            Dictionary<string, object> parameters = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(profilNom))
            {
                query += " WHERE p.nom = @profilNom";
                parameters.Add("@profilNom", profilNom);
            }
            query += " ORDER BY d.nom, d.prenom";

            using (MySqlDataReader reader = bddManager.ReqSelect(query, parameters))
            {
                while (reader.Read())
                {
                    Developpeur dev = new Developpeur
                    {
                        Id = reader.GetInt32("iddeveloppeur"),
                        Nom = reader.GetString("nom"),
                        Prenom = reader.GetString("prenom"),
                        Tel = reader.IsDBNull(reader.GetOrdinal("tel")) ? null : reader.GetString("tel"),
                        Mail = reader.IsDBNull(reader.GetOrdinal("mail")) ? null : reader.GetString("mail"),
                        Profil = new Profil
                        {
                            Id = reader.GetInt32("idprofil"),
                            Nom = reader.GetString("profilNom")
                        }
                    };
                    lesDeveloppeurs.Add(dev);
                }
            }
            return lesDeveloppeurs;
        }

        public bool AddDeveloppeur(Developpeur developpeur)
        {
            if (developpeur.Profil == null || developpeur.Profil.Id == 0)
            {
                // Profil is mandatory, or handle error appropriately
                return false; 
            }
            string query = "INSERT INTO developpeur (nom, prenom, tel, mail, idprofil) VALUES (@nom, @prenom, @tel, @mail, @idprofil)";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@nom", developpeur.Nom },
                { "@prenom", developpeur.Prenom },
                { "@tel", (object)developpeur.Tel ?? DBNull.Value },
                { "@mail", (object)developpeur.Mail ?? DBNull.Value },
                { "@idprofil", developpeur.Profil.Id }
            };
            try
            {
                bddManager.ReqUpdate(query, parameters);
                return true;
            }
            catch (Exception)
            {
                // Log error
                return false;
            }
        }

        public bool UpdateDeveloppeur(Developpeur developpeur)
        {
            if (developpeur.Profil == null || developpeur.Profil.Id == 0)
            {
                return false;
            }
            string query = "UPDATE developpeur SET nom = @nom, prenom = @prenom, tel = @tel, mail = @mail, idprofil = @idprofil WHERE iddeveloppeur = @iddeveloppeur";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@iddeveloppeur", developpeur.Id },
                { "@nom", developpeur.Nom },
                { "@prenom", developpeur.Prenom },
                { "@tel", (object)developpeur.Tel ?? DBNull.Value },
                { "@mail", (object)developpeur.Mail ?? DBNull.Value },
                { "@idprofil", developpeur.Profil.Id }
            };
            try
            {
                bddManager.ReqUpdate(query, parameters);
                return true;
            }
            catch (Exception)
            {
                // Log error
                return false;
            }
        }

        public bool DeleteDeveloppeur(int idDeveloppeur)
        {
            string query = "DELETE FROM developpeur WHERE iddeveloppeur = @iddeveloppeur";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@iddeveloppeur", idDeveloppeur }
            };
            try
            {
                bddManager.ReqUpdate(query, parameters);
                return true;
            }
            catch (Exception)
            {
                // Log error
                return false;
            }
        }
    }
}
