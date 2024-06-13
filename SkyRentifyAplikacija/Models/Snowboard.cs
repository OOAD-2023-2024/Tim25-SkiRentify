using System.ComponentModel.DataAnnotations;

namespace SkyRentifyAplikacija.Models
{
    public class Snowboard : Oprema
    {
        [Required]
        [Display(Name = "Dužina")]
        [Range(60, 300, ErrorMessage = "Dužina mora biti između 60 i 300 cm")]
        public double duzina { get; set; }
    }
}
