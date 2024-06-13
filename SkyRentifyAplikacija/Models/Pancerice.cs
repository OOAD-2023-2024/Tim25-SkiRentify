using System.ComponentModel.DataAnnotations;

namespace SkyRentifyAplikacija.Models
{
    public class Pancerice: Oprema
    {
        [Required(ErrorMessage = "Polje veličina pancerica je obavezno.")]
        [Display(Name = "Veličina")]
        [Range(20, 50,ErrorMessage="Unesite odgovarajuću veličinu (raspon 20 do 50)")]
        public double velicina { get; set; }
    }
}
