﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SkyRentifyAplikacija.Models;

namespace SkyRentifyAplikacija.Controllers
{
    public class IznajmljivanjeController : Controller
    {
        public IActionResult OdabirIznajmljivanje()
        {
            return View();
        }

        public IActionResult OdabirServisiranje()
        {
            return View();
        }

        public IActionResult FormiranjeZahtjeva()
        {
            
            var nivoVjestineTipovi = Enum.GetValues(typeof(Vjestina)).Cast<Vjestina>().ToList();
            ViewBag.VjestinaTipovi= new SelectList(nivoVjestineTipovi.Select(v => new { Id = (int)v, Name = v.ToString() }), "Id", "Name");
            return View();
        }
    }
}
