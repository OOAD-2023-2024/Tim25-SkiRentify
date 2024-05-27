using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SkyRentifyAplikacija.Models
{
    public class Klijent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:15, MinimumLength=2, ErrorMessage="Ime mora imati" +
            "između 2 i 15 znakova")]
        [RegularExpression(@"|a-z|A-Z]*",ErrorMessage ="Dozvoljeno je samo korištenje " +
            "velikih i malih slova!")]
        public string ime { get; set; }
        public string prezime { get; set; }
        public string brojTelefona { get; set; }
        public string email { get; set; }
        public double visina { get; set; }
        [EnumDataType(typeof(Vjestina))] public Vjestina nivoVjestine { get; set; }
    }
}
