using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
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
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage ="Dozvoljeno je samo korištenje " +
            "velikih i malih slova!")]
        [DisplayName("Ime")]
        public string ime { get; set; }
        [Required]
        [StringLength(maximumLength: 15, MinimumLength = 2, ErrorMessage = "Prezime mora imati" +
            "između 2 i 15 znakova")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Dozvoljeno je samo korištenje " +
            "velikih i malih slova!")]
        [DisplayName("Prezime")]
        public string prezime { get; set; }
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Broj telefona mora sadržavati samo brojeve.")]
        [DisplayName("Broj telefona")]
        public string brojTelefona { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("Visina")]
        public double visina { get; set; }
        [Required]
        [DisplayName("Nivo vještine")]
        [EnumDataType(typeof(Vjestina))] public Vjestina nivoVjestine { get; set; }
    }
}
