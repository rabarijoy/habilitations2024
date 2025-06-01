using Microsoft.VisualStudio.TestTools.UnitTesting;
using habilitations2024.dal;
using habilitations2024.model;
using System.Collections.Generic;

namespace habilitations2024.Tests
{
    [TestClass]
    public class DeveloppeurAccessTests
    {
        [TestMethod]
        public void GetLesDeveloppeurs_ProfilSpecifique_RetourneBonNombre()
        {
            // Arrange
            DeveloppeurAccess developpeurAccess = new DeveloppeurAccess();
            // From habilitations.sql, 'designer' (idprofil 2) is associated with 3 developers.
            string profilNom = "designer"; 
            int expectedCount = 3;

            // Act
            List<Developpeur> liste = developpeurAccess.GetLesDeveloppeurs(profilNom);

            // Assert
            Assert.AreEqual(expectedCount, liste.Count, $"Expected {expectedCount} developers for profile '{profilNom}' but found {liste.Count}.");
        }

        [TestMethod]
        public void GetLesDeveloppeurs_SansProfil_RetourneTous()
        {
            // Arrange
            DeveloppeurAccess developpeurAccess = new DeveloppeurAccess();
            // Passing "" or null should return all developers.
            // From habilitations.sql, there are 20 developers in total.
            string profilNom = ""; 
            int expectedCount = 20;

            // Act
            List<Developpeur> liste = developpeurAccess.GetLesDeveloppeurs(profilNom);

            // Assert
            Assert.AreEqual(expectedCount, liste.Count, $"Expected {expectedCount} total developers but found {liste.Count}.");
        }
    }
}