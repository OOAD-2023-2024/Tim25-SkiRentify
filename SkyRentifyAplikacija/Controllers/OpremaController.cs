using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyRentifyAplikacija.Data;
using SkyRentifyAplikacija.Models;

namespace SkyRentifyAplikacija.Controllers
{
    public class OpremaController : Controller
    {

        //dodani dio za dohvacanje iz baze 
        private readonly ApplicationDbContext _context;

        public OpremaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PrikazOpreme(string[] selectedItems)
        {
            var oprema = new List<Oprema>();

            foreach (var item in selectedItems)
            {
                // Dohvatite tip opreme na temelju naziva
                Type tipOpreme = Type.GetType("SkyRentifyAplikacija.Models." + item);

                if (tipOpreme != null)
                {
                    // Dohvatite podatke iz baze koristeći naziv tabele
                    if (item == "Skije")
                    {
                        var skije = _context.Skije.ToList();
                        oprema.AddRange(skije);
                        Console.WriteLine(skije[0].duzina.ToString());
                    }
                    else if (item == "Pancerice")
                    {
                        var pancerice = _context.Pancerice.ToList();
                        oprema.AddRange(pancerice);
                    }else if(item== "Kaciga")
                    {
                        var kacige = _context.Kaciga.ToList();
                        oprema.AddRange(kacige);
                    }else if (item == "Stapovi")
                    {
                        var stapovi = _context.Stapovi.ToList();
                        oprema.AddRange(stapovi);
                    }else if(item=="Snowboard")
                    {
                        var snowboard = _context.Snowboard.ToList();
                        oprema.AddRange(snowboard);
                    }else if(item=="SnowboardCipele")
                    {
                        var snowboardCipele = _context.SnowboardCipele.ToList();
                        oprema.AddRange(snowboardCipele);
                    }
                }
            }
            // Ovdje generirajte partial view i proslijedite mu podatke
            return PartialView("PrikazOpreme",oprema);
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
