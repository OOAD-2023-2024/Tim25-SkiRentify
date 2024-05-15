using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SkyRentifyAplikacija.Models
{
    public class Klijent
    {
        [Key]
        public int Id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string brojTelefona { get; set; }
        public string email { get; set; }
        public double visina { get; set; }
        public Vjestina nivoVjestine { get; set; }
    }
}
