using System;
using Xunit;

namespace sklep_informatyczny.Tests
{
    public class MagazynSklepuIntegracyjneTests
    {
        // Test pozytywny 1: polaczenie koszyka z magazynem i dodanie do koszyka przedmiotu z magazynu
        [Fact]
        public void KoszykIMagazyn_DostepnyProdukt_ZwracaPrawdaISumujeCene()
        {
            // Arrange
            var magazyn = new MagazynSklepu();
            var koszyk = new KoszykSklepu();
            string produkt = "RTX 3070";
            int ilosc = 1;

            // Act (sprawdzenie dostepnosci, pobranie cemy i dodanie do koszyka)
            bool dostepny = magazyn.SprawdzDostepnosc(produkt, ilosc);
            if (dostepny)
            {
                decimal cena = magazyn.PobierzCene(produkt);
                koszyk.DodajProdukt(produkt, cena, ilosc);
            }

            // Assert
            Assert.True(dostepny);
            Assert.Equal(1400m, koszyk.ObliczKoszt());
        }

    }
}