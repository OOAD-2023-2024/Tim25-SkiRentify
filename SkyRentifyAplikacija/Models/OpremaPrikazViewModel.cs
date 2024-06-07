namespace SkyRentifyAplikacija.Models
{
    public class OpremaPrikazViewModel
    {
        public List<Skije> Skije { get; set; }
        public List<Pancerice> Pancerice { get; set; }
        public List<Snowboard> Snowboard { get; set; }
        public List<SnowboardCipele> SnowboardCipele { get; set; }

        public List<Stapovi> Stapovi { get; set; }

        public List<Kaciga> Kacige { get; set; }
        public int ZahtjevId { get; set; } // ID zahteva
    }
}

