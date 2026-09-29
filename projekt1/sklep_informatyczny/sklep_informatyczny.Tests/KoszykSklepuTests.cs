namespace sklep_informatyczny.Tests
{
    public class KoszykSklepuTests
    {
        [Fact]
        public void ObliczKosztKoszyka()
        {
            var koszyk = new KoszykSklepu();
            koszyk.DodajProdukt("RTX 3070", 1200m, 1);
            koszyk.DodajProdukt("Intel I7", 1300m, 1);
            koszyk.DodajProdukt("RAM 16gb", 1000m, 2);

            decimal koszt = koszyk.ObliczKoszt();

            Assert.Equal(4500m, koszt);
        }

        [Fact]
        public void DodawanieKosztuDostawy()
        {
            var koszyk = new KoszykSklepu();
            koszyk.DodajProdukt("myszka", 65.99m, 1);

            decimal koszt = koszyk.ObliczKoszt();

            Assert.Equal(80.99m, koszt);
        }
    }
}
