
using System.ComponentModel.DataAnnotations;
namespace SkyRentifyAplikacija.Models
{
    public class TipZahtjeva
    {
        [Key]
        public int ID { get; set;}
        [Display(Name = "Naziv usluge:")]
        [EnumDataType(typeof(Tip))]
        public Tip naziv { get; set; }
        [Display(Name = "Cijena usluge:")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Dozvoljen je unos samo brojeva.")]
        [Range(10, 50, ErrorMessage = "Cijena mora biti između 10 i 50.")]
        public double cijena { get; set; }
    }
}
