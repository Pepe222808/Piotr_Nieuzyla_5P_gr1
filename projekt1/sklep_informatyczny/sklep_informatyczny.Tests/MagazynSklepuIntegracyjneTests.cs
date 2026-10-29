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

        // Test pozytywny 2: dodanie wielu produktow naraz
        [Fact]
        public void KoszykIMagazyn_WieleProduktow_PoprawnaIntegracja()
        {
            // Arrange
            var magazyn = new MagazynSklepu();
            var koszyk = new KoszykSklepu();

            // Act (sprawdzenie dostepnosci i sumowanie ceny 2200 + (2 * 700) = 3600)
            if (magazyn.SprawdzDostepnosc("Intel I7", 1))
                koszyk.DodajProdukt("Intel I7", magazyn.PobierzCene("Intel I7"), 1);

            if (magazyn.SprawdzDostepnosc("RAM 16gb", 2))
                koszyk.DodajProdukt("RAM 16gb", magazyn.PobierzCene("RAM 16gb"), 2);

            decimal kosztCalkowity = koszyk.ObliczKoszt(); 

            // Assert
            Assert.Equal(3600m, kosztCalkowity);
        }

        // Test pozytywny 3: sprawdzenie stanu dla wiekszej ilosci produktu niz w magazynie
        [Fact]
        public void KoszykIMagazyn_PrzekroczonaIlosc_OdrzucaZakup()
        {
            // Arrange
            var magazyn = new MagazynSklepu();
            string produkt = "Intel I7";
            int ilosc = 5; // W magazynie są tylko 2 sztuki

            // Act (sprawdza dostepnosc dla 5 inteli zwraca false)
            bool dostepny = magazyn.SprawdzDostepnosc(produkt, ilosc);

            // Assert
            Assert.False(dostepny);
        }

    }
}