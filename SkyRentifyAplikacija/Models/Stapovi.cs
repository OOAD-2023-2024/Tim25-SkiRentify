using System.ComponentModel.DataAnnotations;

namespace SkyRentifyAplikacija.Models
{
    public class Stapovi: Oprema
    {
        [Required]
        [Display(Name = "Dužina")]
        [Range(100, 170,ErrorMessage ="Dužina štapova mora bit u rangu (100,170)")]
        public double duzina { get; set; }
    }
}
