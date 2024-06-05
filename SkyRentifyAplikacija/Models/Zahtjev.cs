using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyRentifyAplikacija.Models
{
    public class Zahtjev
    {
        [Key]
        public int Id { get; set; }
        public DateTime datumPodnosenjaZahtjeva { get; set; }
        [DisplayName("Datum izdavanja usluge")]
        public DateTime datumIzdavanjaUsluge { get; set; }
        [DisplayName("Datum završetka usluge")]
        public DateTime datumZavrsetkaUsluge { get; set; }

        [ForeignKey("Klijent")]
        public int KlijentId { get; set; }
        public Klijent klijent { get; set; }
        public double cijena { get; set; }
        public double popust { get; set; }
        public bool placeno { get; set; }
    }
}
