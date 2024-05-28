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

        public IActionResult FormiranjeZahtjeva()//string checkedItems)
        {
            //da preuzmem nivo vjestine
            var nivoVjestineTipovi = Enum.GetValues(typeof(Vjestina)).Cast<Vjestina>().ToList();
            ViewBag.VjestinaTipovi = new SelectList(nivoVjestineTipovi.Select(v => new { Id = (int)v, Name = v.ToString() }), "Id", "Name");
            /*if (string.IsNullOrEmpty(checkedItems))
            {
                return BadRequest("Nije odabrana nijedna stavka opreme.");
            }
            var selectedItems = checkedItems.Split(',');
            TempData["SelectedItems"] = selectedItems;*/
            return View();
        }
    }
}
