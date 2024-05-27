using System.ComponentModel.DataAnnotations;

namespace SkyRentifyAplikacija.Models
{
    public enum Vjestina
    {
        [Display(Name = "Početnik")]
        POCETNIK,
        [Display(Name = "Srednji")]
        SREDNJI,
        [Display(Name = "Napredni")]
        NAPREDNI
    }
}
