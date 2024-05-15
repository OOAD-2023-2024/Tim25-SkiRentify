using System.ComponentModel.DataAnnotations;

namespace SkyRentifyAplikacija.Models
{
    public abstract class Osoblje
    {
        [Key]
        public int Id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string korisnickoIme { get; set; }
        public string sifra { get; set; }
    }
}
