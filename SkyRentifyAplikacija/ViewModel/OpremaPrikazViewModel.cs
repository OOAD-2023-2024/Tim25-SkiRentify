using SkyRentifyAplikacija.Models;

namespace SkyRentifyAplikacija.ViewModel
{
    public class OpremaPrikazViewModel
    {
        public List<Skije> Skije { get; set; }
        public List<Pancerice> Pancerice { get; set; }
        public List<Snowboard> Snowboards { get; set; }
        public List<SnowboardCipele> SnowboardCipele { get; set; }
        public int ZahtjevId { get; set; } // ID zahteva
    }
}
