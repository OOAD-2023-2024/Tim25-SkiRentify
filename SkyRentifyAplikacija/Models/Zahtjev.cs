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
        [FutureDate(ErrorMessage = "Datum izdavanja mora biti u budućnosti")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Datum izdavanja usluge je obavezan.")]
        [ValidDates(ErrorMessage = "Datum izdavanja mora biti veći od današnjeg i manji od datuma završetka.")]
        public DateTime datumIzdavanjaUsluge { get; set; }

        [DisplayName("Datum završetka usluge")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [FutureDate(ErrorMessage = "Datum završetka mora biti u budućnosti")]
        [Required(ErrorMessage = "Datum završetka usluge je obavezan.")]
        public DateTime datumZavrsetkaUsluge { get; set; }

        [ForeignKey("Klijent")]
        [DisplayName("Klijent")]
        public int KlijentId { get; set; }
        [DisplayName("Klijent")]

        public Klijent klijent { get; set; }
        [DisplayName("Cijena")]

        public double cijena { get; set; }
        [DisplayName("Popust")]

        public double popust { get; set; }
        [DisplayName("Plaćeno")]

        public bool placeno { get; set; }
    }

    public class ValidDatesAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateValue)
            {
                var currentDate = DateTime.Now;

                // Pristupamo drugom svojstvu modela pomocu ValidationContext.ObjectInstance
                var endDateProperty = validationContext.ObjectType.GetProperty("datumZavrsetkaUsluge");
                if (endDateProperty == null)
                {
                    return new ValidationResult("Datum završetka usluge nije pronađen.");
                }

                var endDate = (DateTime)endDateProperty.GetValue(validationContext.ObjectInstance);

                // Vrsimo validaciju
                if (dateValue > currentDate && dateValue < endDate)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Datum izdavanja usluge mora biti veći od današnjeg i manji od datuma završetka usluge.");
                }
            }

            return new ValidationResult("Neispravan format datuma.");
        }
    }
}
