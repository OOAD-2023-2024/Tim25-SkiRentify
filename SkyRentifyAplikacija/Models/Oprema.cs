using System.ComponentModel.DataAnnotations;

namespace SkyRentifyAplikacija.Models
{
    public abstract class Oprema
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Cijena")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unesite validan iznos.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Unesite validan iznos.")] 
        public double cijena { get; set; }
        [Display(Name = "Marka")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Polje Marka mora biti između 2 i 50 karaktera.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Dozvoljeni su samo slova.")]
        public string marka { get; set; }
        [Display(Name = "Materijal")]
        [StringLength(50, ErrorMessage = "Polje Materijal ne može biti duže od 50 karaktera.")]
        [RegularExpression(@"^[a-zA-Z\s\\]*$", ErrorMessage = "Dozvoljena su samo slova i \\.")]
        public string materijal { get; set; }

    }
}
