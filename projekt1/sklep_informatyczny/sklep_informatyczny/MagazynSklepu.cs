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

        
    }
}