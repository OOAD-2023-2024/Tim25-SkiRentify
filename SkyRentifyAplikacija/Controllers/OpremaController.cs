using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyRentifyAplikacija.Data;
using SkyRentifyAplikacija.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SkyRentifyAplikacija.Controllers
{
    public class OpremaController : Controller
    {

        //dodani dio za dohvacanje iz baze 
        private readonly ApplicationDbContext _context;
        private string listaSaZarezom;
        private string[] lista;
        private TextFileHandler fileHandler;
        private string putanjaOdabirIznajmljivanje = "Data/UpisaniOdabirIznajmljivanje.txt";

        public OpremaController(ApplicationDbContext context)
        {
            _context = context;
            fileHandler = new TextFileHandler();
        }

        public ActionResult OdabraneOpcije(string[] selectedItems)
        {
            var odabrano= selectedItems[0]; // Upisivanje odabranog tipa opreme u datoteku
            fileHandler.WriteToFile(putanjaOdabirIznajmljivanje, odabrano);
            return RedirectToAction("FormiranjeZahtjeva", "Iznajmljivanje");
        }

        [HttpGet]
        public async Task<IActionResult> PrikazOpremeAsync(string[] selectedItems)
        {
            List<Oprema> oprema = new List<Oprema>();
            listaSaZarezom = fileHandler.ReadFromFile(putanjaOdabirIznajmljivanje);
            lista = listaSaZarezom.Split(",");

            foreach (var item in lista)
            {
                Type tipOpreme = Type.GetType("SkyRentifyAplikacija.Models." + item);

                if (tipOpreme != null)
                {               
                    if (item == "Skije")
                    {
                        var skije = await _context.Skije.ToListAsync();
                        oprema.AddRange(skije);
                    }
                    else if (item == "Pancerice")
                    {
                        var pancerice = await _context.Pancerice.ToListAsync();
                        oprema.AddRange(pancerice);
                    }else if(item== "Kaciga")
                    {
                        var kacige = await _context.Kaciga.ToListAsync();
                        oprema.AddRange(kacige);
                    }else if (item == "Stapovi")
                    {
                        var stapovi = await _context.Stapovi.ToListAsync();
                        oprema.AddRange(stapovi);
                    }else if(item=="Snowboard")
                    {
                        var snowboard = await _context.Snowboard.ToListAsync();
                        oprema.AddRange(snowboard);
                    }else if(item=="SnowboardCipele")
                    {
                        var snowboardCipele = await _context.SnowboardCipele.ToListAsync();
                        oprema.AddRange(snowboardCipele);
                    }
                }
            }        
            return View("PrikazOpreme",oprema); //ovdje treba u zavisnosti od toga je li servisiranje ili iznajmljivanje
                                                //da vrati ili prikazopreme za iznajmlj ili prikaz za placanje
        }

        // GET: OpremaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OpremaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OpremaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OpremaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OpremaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OpremaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OpremaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OpremaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
