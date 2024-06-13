using System.ComponentModel.DataAnnotations;

namespace SkyRentifyAplikacija.Models
{
    public class SnowboardCipele: Oprema
    {
        [Required]
        [Display(Name = "Veličina")]
        [Range(35, 50,ErrorMessage ="Veličina cipela mora biti u rangu (35,50)")]
        public double velicina { get; set; }
    }
}
