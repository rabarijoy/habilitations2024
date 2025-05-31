using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.model
{
    public class Developpeur
    {
        public int Id { get; set; } // Corresponds to iddeveloppeur
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public Profil Profil { get; set; } // Linked via idprofil
        // public int IdProfil { get; set; } // Could be used if Profil object is not immediately needed
    }
}
