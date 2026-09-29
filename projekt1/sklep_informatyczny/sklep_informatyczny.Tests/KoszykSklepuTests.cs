namespace sklep_informatyczny.Tests
{
    public class KoszykSklepuTests
    {
        //Test pozytywny 1: liczenie kosztu koszyk
        [Fact]
        public void ObliczKosztKoszyka()
        {
            //Arrange
            var koszyk = new KoszykSklepu();
            koszyk.DodajProdukt("RTX 3070", 1200m, 1);
            koszyk.DodajProdukt("Intel I7", 1300m, 1);
            koszyk.DodajProdukt("RAM 16gb", 1000m, 2);

            //Act (sumowanie cen 1200 + 1300 + 2*1000 = 4500)
            decimal koszt = koszyk.ObliczKoszt();

            //Assert
            Assert.Equal(4500m, koszt);
        }

        //Test pozytywny 2: doliczanie kosztu dostawy, liczby zmiennoprzecinkowe
        [Fact]
        public void DodawanieKosztuDostawy()
        {
            //Arrange
            var koszyk = new KoszykSklepu();
            koszyk.DodajProdukt("myszka", 65.99m, 1);

            //Act (65.99 + 15 za dostawe = 80.99)
            decimal koszt = koszyk.ObliczKoszt();

            //Assert
            Assert.Equal(80.99m, koszt);
        }

        //Test pozytywny 3: Obliczanie ceny gwarancji
        [Fact]
        public void ObliczanieGwarancji()
        {
            //Arrange
            var koszyk = new KoszykSklepu();

            //Act (cena 2000, 3 lata gwarancji = 2000*0.3 = 600
            decimal gwarancja = koszyk.ObliczGwarancje(2000m, 3);

            //Assert
            Assert.Equal(600m, gwarancja);
        }

        //Test negatywny: odrzucenie blednego kodu rabatwoego
        [Fact]
        public void BlednyKodRabatowy()
        {
            //Arange
            var koszyk = new KoszykSklepu();

            //Act i Assert (test czy wyrzuci ze kod rabatowy jest bledny)
            Assert.Throws<ArgumentException>(() => koszyk.DodajZnizke("za darmo"));

        }
    }
}
