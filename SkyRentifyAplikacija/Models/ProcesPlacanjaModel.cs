namespace SkyRentifyAplikacija.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ProcesPlacanjaModel
    {
        [Required]
        public int ZahtjevId { get; set; }

        [Required(ErrorMessage = "Unesite broj kartice")]
        [CreditCard(ErrorMessage = "Unesite ispravan broj kartice")]
        [Display(Name = "Broj kartice")]
        public string BrojKartice { get; set; }

        [Required(ErrorMessage = "Unesite ime")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Dozvoljeno je samo korištenje " +
        "velikih i malih slova.")]
        [Display(Name = "Ime na kartici")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Unesite datum isteka")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        [FutureDate(ErrorMessage = "Datum isteka mora biti u budućnosti")]
        [Display(Name = "Datum isteka")]
        public DateTime DatumIsteka { get; set; }

        [Required(ErrorMessage = "Unesite CVV")]
        [Range(100, 999, ErrorMessage = "Unesite ispravan CVV")]
        [Display(Name = "CVV")]
        public int CVV { get; set; }

        public double UkupnaCijena { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime > DateTime.Now;
            }
            return false;
        }
    }

}
