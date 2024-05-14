using System.ComponentModel.DataAnnotations;

namespace SkyRentifyAplikacija.Models
{
    public class Zahtjev
    {
        [Key]
        public int Id { get; set; }
        public DateTime datumPodnosenjaZahtjeva { get; set; }
        public DateTime datumIzdavanjaUsluje { get; set; }
        public DateTime datumZavrsetkaUsluge { get; set; }
        public Klijent klijent { get; set; }
        public double cijena { get; set; }
        public double popust { get; set; }
        public bool placeno { get; set; }
    }
}
