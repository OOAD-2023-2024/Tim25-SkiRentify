using System.ComponentModel.DataAnnotations;

namespace SkyRentifyAplikacija.Models
{
    public abstract class Oprema
    {
        [Key]
        protected int Id { get; set; }
        protected double cijena { get; set; }
        protected string marka { get; set; }
        protected string materijal { get; set; }

    }
}
