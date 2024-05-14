
using System.ComponentModel.DataAnnotations;
namespace SkyRentifyAplikacija.Models
{
    public class TipZahtjeva
    {
        [Key]
        public int ID { get; set;}
        public Tip naziv { get; set; }
        public double cijena { get; set; }
    }
}
