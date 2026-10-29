using System;
using System.Collections.Generic;

namespace sklep_informatyczny
{
    public class MagazynSklepu
    {
        // Słownik przechowujący stan magazynowy podzespołów: (Cena, Dostępna liczba sztuk)
        private readonly Dictionary<string, (decimal Cena, int Sztuki)> _magazyn = new(StringComparer.OrdinalIgnoreCase)
        {
            { "RTX 3070", (1400m, 5) },
            { "Intel I7", (2200m, 2) },
            { "RAM 16gb", (700m, 10) },
            { "SSD 1024gb", (950m, 12) },
            { "Myszka steelseries", (80m, 25) },
            { "Klawiatura steelseries", (220m, 20) }
        };

        public bool SprawdzDostepnosc(string nazwa, int ilosc)
        {
            if (string.IsNullOrWhiteSpace(nazwa))
                throw new ArgumentException("Nazwa produktu nie może być pusta.");
            if (ilosc <= 0)
                throw new ArgumentException("Ilość musi być większa od zera.");

            if (!_magazyn.ContainsKey(nazwa))
                return false;

            return _magazyn[nazwa].Sztuki >= ilosc;
        }

        public decimal PobierzCene(string nazwa)
        {
            if (!_magazyn.ContainsKey(nazwa))
                throw new ArgumentException("Produkt nie istnieje w magazynie.");

            return _magazyn[nazwa].Cena;
        }

    }
}