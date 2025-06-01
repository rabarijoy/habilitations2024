using habilitations2024.dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace habilitations2024.Tests
{
    [TestClass]
    public class DeveloppeurAccessTests
    {
        [TestMethod]
        public void TestGetLesDeveloppeursAvecProfil()
        {
            // Arrange
            var liste = DeveloppeurAccess.GetLesDeveloppeurs("DEV");

            // Assert
            Assert.AreEqual(3, liste.Count); // adapte ce nombre selon tes données
        }

        [TestMethod]
        public void TestGetLesDeveloppeursSansProfil()
        {
            // Arrange
            var liste = DeveloppeurAccess.GetLesDeveloppeurs("");

            // Assert
            Assert.IsTrue(liste.Count > 0); // ou le nombre attendu exact
        }
    }
}