using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

namespace sklep_informatyczny
{
    public class Produkt
    {
        public string Nazwa { get; set; } = string.Empty;
        public decimal Cena { get; set; }
        public int Ilosc { get; set; }
    }

    public class KoszykSklepu
    {
        private readonly List<Produkt> _produkty = new();
        private decimal _znizka = 0;

        public void DodajProdukt(string nazwa, decimal cena, int ilosc)
        {
            //funkcja dodaje produkty do koszyka i sprawdza podana cene i ilosc 
            if (cena < 0)
            {
                throw new ArgumentException("Cena nie moze byc ujemna");
            }
            if (ilosc <= 0)
            {
                throw new ArgumentException("Ilosc musi byc wieksza od 0");
            }
            
            _produkty.Add(new Produkt { Nazwa = nazwa, Cena = cena, Ilosc = ilosc });
        }

        public void DodajZnizke(string kod)
        {
            //funckja sprawdza czy podany kod rabatowy jest poprawny i nalicza znizke
            if (string.IsNullOrWhiteSpace(kod))
            {
                throw new ArgumentException("kod nie moze byc pusty");
            }

            switch (kod.Trim().ToUpper())
            {
                case "STUDENT":
                    _znizka = 0.15m;
                    break;
                case "PROMO5":
                    _znizka = 0.5m;
                    break;
                default:
                    throw new ArgumentException("Bledny kod rabatowy");
            }
        }

        public decimal ObliczKoszt()
        {
            //funkcja oblicza koszt wszystkich przedmiotow w koszyku, odlicza znizke jesli podany byl kod rabatowy i 
            // jesli cena jest nizsza niz 200 zl dolicza dostawe
            //zwraca calkowity koszt zamowienia
            decimal koszt = 0;
            decimal dostawa = 15m;

            foreach(var produkt in _produkty)
            {
                koszt += (produkt.Cena * produkt.Ilosc);
            }

            koszt = koszt * (1 - _znizka);


            if (koszt > 0 && koszt < 200)
            {
                koszt += dostawa;
            }

            return koszt;
        }

        public decimal ObliczGwarancje(decimal cena, int lata)
        {
            // funkcja pobiera cene produktu i dlugosc trwania gwarancji i oblicza gwarancje jako 1/10 ceny * czas trwania
            // zwraca cene gwarancji
            if (lata < 1 || lata > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(lata), "Gwarancja tylko w okresie od 1 do 5 lat");
            }

            return cena * 0.10m * lata;
        }

        


    }
}
