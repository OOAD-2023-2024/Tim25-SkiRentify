using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyRentifyAplikacija.Models
{
    public class StavkaZahtjeva
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Zahtjev")]
        public int ZahtjevId { get; set; }
        [ForeignKey("Oprema")]
        public int OpremaId { get; set; }
        public Zahtjev zahtjev { get; set; }
        public Oprema oprema { get; set; }
    }
}
