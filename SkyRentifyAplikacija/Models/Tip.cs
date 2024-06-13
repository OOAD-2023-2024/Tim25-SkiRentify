using System.ComponentModel.DataAnnotations;

namespace SkyRentifyAplikacija.Models
{
    public enum Tip
    {
        [Display(Name = "Poliranje")]
        POLIRANJE, 
        [Display(Name ="Popravak vezova")]
        POPRAVAK_VEZOVA,
        [Display(Name = "Iznajmljivanje")]
        IZNAJMLJIVANJE //0 je prvo, 1 drugo, 2 trece i 2 je 0 cijena
    }
}
