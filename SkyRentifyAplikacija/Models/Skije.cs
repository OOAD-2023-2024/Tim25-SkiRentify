using System.ComponentModel.DataAnnotations;

namespace SkyRentifyAplikacija.Models
{
    public class Skije: Oprema
    {
        [Display(Name = "Dužina skija")]
        public double duzina { get; set; }
        [Display(Name = "Širina skija")]
        public double sirina { get; set; }
    }
}
