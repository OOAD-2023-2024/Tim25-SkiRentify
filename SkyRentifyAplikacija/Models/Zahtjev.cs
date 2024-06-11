using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkyRentifyAplikacija.Models
{
    public class Zahtjev
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Datum podnošenja zahtjeva")]
        public DateTime datumPodnosenjaZahtjeva { get; set; }

        [DisplayName("Datum izdavanja usluge")]
        [FutureDate(ErrorMessage = "Datum izdavanja usluge mora biti u budućnosti")]
        public DateTime datumIzdavanjaUsluge { get; set; }

        [DisplayName("Datum završetka usluge")]
        [DateGreaterThan("datumIzdavanjaUsluge", ErrorMessage = "Datum završetka usluge mora biti nakon datuma izdavanja")]
        public DateTime datumZavrsetkaUsluge { get; set; }

        [ForeignKey("Klijent")]
        public int KlijentId { get; set; }

        public Klijent klijent { get; set; }

        public double cijena { get; set; }

        public double popust { get; set; }

        public bool placeno { get; set; }
    }

    /*public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid1(object value)
        {
            if (value is DateTime dateTime)
            {
                return dateTime > DateTime.Now;
            }
            return false;
        }
    }*/

    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
            {
                throw new ArgumentException("Property with this name not found");
            }

            var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance);
            var currentValue = (DateTime)value;

            if (currentValue > comparisonValue)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "Datum mora biti nakon datuma izdavanja");
        }
    }
}
