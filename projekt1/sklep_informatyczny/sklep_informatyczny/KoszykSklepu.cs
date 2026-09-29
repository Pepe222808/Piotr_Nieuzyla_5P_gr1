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

        public void DodajProdukt(string nazwa, decimal cena, int ilosc)
        {
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

        public decimal ObliczKoszt()
        {
            decimal koszt = 0;
            decimal dostawa = 15;

            foreach(var produkt in _produkty)
            {
                koszt += (produkt.Cena * produkt.Ilosc);
            }

            if (koszt > 0 && koszt < 200)
            {
                koszt += dostawa;
            }

            return koszt;
        }


    }
}
