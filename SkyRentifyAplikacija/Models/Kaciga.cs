using System.ComponentModel.DataAnnotations;

namespace SkyRentifyAplikacija.Models
{
    public class Kaciga : Oprema
    {
        [Display(Name = "Veličina kacige")]
        [Required(ErrorMessage = "Polje veličina kacige je obavezno.")]
        public char velicina { get; set; }
    }
}
