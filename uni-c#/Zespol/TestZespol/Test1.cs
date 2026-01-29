using OsobaZespol;

namespace TestZespol
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void UstawienieNazwyZespoluTestMethod()
        {
            // Arrange
            Zespol zespol = new Zespol();
            string nazwa = "Grupa IT";

            // Act
            zespol.NazwaZespolu = nazwa;

            // Assert
            Assert.AreEqual(nazwa, zespol.NazwaZespolu);
        }

        [TestMethod]
        public void InicjalizacjaCzlonkowZespoluTestMethod()
        {
            // Arrange
            Zespol zespol;

            // Act
            zespol = new Zespol();

            // Assert
            Assert.IsNotNull(zespol.CzlonkowieZespolu);
        }

        [TestMethod]
        public void DodawanieNowegoCzlonkaTestMethod()
        {
            // Arrange
            Zespol zespol = new Zespol();

            // Act
            CzlonekZespolu cz = new CzlonekZespolu();
            zespol.DodajCzlonkaZespolu(cz);

            // Assert
            Assert.AreEqual(1, zespol.CzlonkowieZespolu.Count());
        }

        [TestMethod]
        public void TestowanieComparetoTestMethod()
        {
            // Arrange
            Zespol zespol = new Zespol();

            // Act
            CzlonekZespolu cz1 = new CzlonekZespolu("Jan", "Nowak", "2020-10-10", "11111111111", EnumPlec.M, "2000.10.10", "", true);
            CzlonekZespolu cz2 = new CzlonekZespolu("Adam", "Nowak", "2020-10-10", "11111111111", EnumPlec.M, "2000.10.10", "", true);
            // Assert
            Assert.Equals(1, cz1.CompareTo(cz2));
        }

        [TestMethod]
        //[ExpectedException(typeof(wrongPeselException))]
        public void BladPrzyUstawianiuPeselTestMethod()
        {
            // Arrange
            CzlonekZespolu cz = new CzlonekZespolu();
            string niepoprawnypesel = "aaaa";

            // Act
            //cz.PESEL = niepoprawnypesel;

            // Assert - gdy to ponizej jest uzywane to komentujemy to co jest powyzej
            Assert.ThrowsException<wrongPeselException>(() => cz.Pesel = niepoprawnypesel);
        }

        [TestMethod]
        public void PorownywaniePoPeselTestMethod()
        {
            // Arrange
            CzlonekZespolu cz1 = new CzlonekZespolu("Jan", "Nowak", "2020-10-10", "11111111111", EnumPlec.M, "2000.10.10", "", true);
            CzlonekZespolu cz2 = new CzlonekZespolu("Adam", "Nowak", "2020-10-10", "11111111111", EnumPlec.M, "2000.10.10", "", true);

            // Assert
            Assert.IsTrue(cz1.Equals(cz2));

        }

        [TestMethod]
        public void KlonowanieZespoluTestMethod()
        {
            //Arrange
            KierownikZespolu k1 = new KierownikZespolu("Adam", "Kowalski", "01.07.1990", "90070142412", EnumPlec.M, 5, 405324001);
            CzlonekZespolu cz1 = new CzlonekZespolu("Beata", "Nowak", "1992-10-22", "00990413987", EnumPlec.K, "2020-05-01", "Projektant", true);
            Zespol z1 = new Zespol("Klonowanie", k1);
            z1.DodajCzlonkaZespolu(cz1);

            // Act
            Zespol z2 = (Zespol)z1.Clone();

            // Assert
            Assert.AreEqual(z1.NazwaZespolu, z2.NazwaZespolu);
            Assert.AreEqual(z1.CzlonkowieZespolu.Count, z2.CzlonkowieZespolu.Count);
            Assert.AreNotSame(z1, z2);

        }
    }
}
