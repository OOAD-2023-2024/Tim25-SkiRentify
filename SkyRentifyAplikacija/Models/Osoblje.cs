using System.ComponentModel.DataAnnotations;

namespace SkyRentifyAplikacija.Models
{
    public abstract class Osoblje
    {
        [Key]
        protected int Id { get; set; }
        protected string ime { get; set; }
        protected string prezime { get; set; }
        protected string korisnickoIme { get; set; }
        protected string sifra { get; set; }
    }
}
