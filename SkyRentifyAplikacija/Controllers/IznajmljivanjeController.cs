using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SkyRentifyAplikacija.Models;

namespace SkyRentifyAplikacija.Controllers
{
    public class IznajmljivanjeController : Controller
    {
        private TextFileHandler fileHandler;
        private string parcijalniPogled;
        public IznajmljivanjeController()
        {
            fileHandler = new TextFileHandler();
        }
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
            parcijalniPogled=fileHandler.ReadFromFile("Data/UpisaniTipZahtjeva.txt");
            ViewBag.Content = parcijalniPogled;
            var nivoVjestineTipovi = Enum.GetValues(typeof(Vjestina)).Cast<Vjestina>().ToList();
            ViewBag.VjestinaTipovi= new SelectList(nivoVjestineTipovi.Select(v => new { Id = (int)v, Name = v.ToString() }), "Id", "Name");
            return View();
            //return View();
        }
    }
}
