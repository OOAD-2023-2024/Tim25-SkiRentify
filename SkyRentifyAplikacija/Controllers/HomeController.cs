using Microsoft.AspNetCore.Mvc;
using SkyRentifyAplikacija.Models;
using System.Diagnostics;
using System.Reflection.Emit;

namespace SkyRentifyAplikacija.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private TextFileHandler fileHandler;
        private string putanjaTipZahtjeva = "Data/UpisaniTipZahtjeva.txt";
        private string putanjaOdabirIznajmljivanje = "Data/UpisaniOdabirIznajmljivanje.txt";
        private string putanjaOpcijeServisiranja = "Data/UpisaniOpcijeServisiranja.txt";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            fileHandler = new TextFileHandler();
        }

        public ActionResult OdabraneOpcije(string[] selectedItems)
        {
            var odabrano = selectedItems[0]; // Upisivanje odabranog tipa opreme u datoteku
            fileHandler.WriteToFile(putanjaOdabirIznajmljivanje, odabrano);
            return RedirectToAction("Create", "Zahtjev");
        }

        public ActionResult postaviTipZahtjeva(string selectedItem)
        {
            fileHandler.WriteToFile(putanjaTipZahtjeva, selectedItem);// Upisivanje odabranog tipa zahtjeva u datoteku
            if (selectedItem.Equals("iznajmljivanje")) return RedirectToAction("OdabirIznajmljivanje", "Home");
            else return RedirectToAction("OdabirServisiranje", "Home");
        }

        public ActionResult postaviOpcijeServisiranja(string[] selectedItems)
        {
            var opcije = selectedItems[0];// Upisivanje odabranih servisa za zahtjev datoteku
            fileHandler.WriteToFile(putanjaOpcijeServisiranja, opcije);
            return RedirectToAction("Create", "Zahtjev");
        }

        public IActionResult OdabirIznajmljivanje()
        {
            return View();
        }

        public IActionResult OdabirServisiranje()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /*public IActionResult Iznajmljivanje()
        {
            return View();
        }*/

        public IActionResult Servisiranje()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult OtkaziZahtjev()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
