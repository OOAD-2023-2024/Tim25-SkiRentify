using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SkyRentifyAplikacija.Models;

namespace SkyRentifyAplikacija.Controllers
{
    public class IznajmljivanjeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FormiranjeZahtjeva()
        {
            //da preuzmem nivo vjestine
            var nivoVjestineTipovi = Enum.GetValues(typeof(Vjestina)).Cast<Vjestina>().ToList();
            ViewBag.VjestinaTipovi = new SelectList(nivoVjestineTipovi.Select(v => new { Id = (int)v, Name = v.ToString() }), "Id", "Name");
            return View();
        }
    }
}
