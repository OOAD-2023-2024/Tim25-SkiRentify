using System.ComponentModel.DataAnnotations;

namespace SkyRentifyAplikacija.Models
{
    public abstract class Oprema
    {
        [Key]
        public int Id { get; set; }
        public double cijena { get; set; }
        public string marka { get; set; }
        public string materijal { get; set; }

    }
}
