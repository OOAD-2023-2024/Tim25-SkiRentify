using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyRentifyAplikacija.Models
{
    public class TipoviZahtjeva
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Zahtjev")]
        public int ZahtjevId { get; set; }
        [ForeignKey("TipZahtjeva")]
        public int TipZahtjevaId { get; set; }
        public Zahtjev zahtjev { get; set; }
        public TipZahtjeva tipZahtjeva { get; set; }
    }
}
