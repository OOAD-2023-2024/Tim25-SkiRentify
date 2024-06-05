﻿using Microsoft.AspNetCore.Http;
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

        public OpremaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult OdabraneOpcije(string[] selectedItems)
        {
            var odabrano= selectedItems[0];
            string putanja = "Data/UpisaniOdabirIznajmljivanje.txt";
            // Upisivanje odabranog tipa zahtjeva u datoteku
            System.IO.File.WriteAllText(putanja, string.Empty);

            using (StreamWriter writer = System.IO.File.AppendText(putanja))
            {
                writer.WriteLine(odabrano);
            }
            return RedirectToAction("FormiranjeZahtjeva", "Iznajmljivanje");
        }

        public void procitajFile()
        {
            string putanja = "Data/UpisaniOdabirIznajmljivanje.txt";
            if (System.IO.File.Exists(putanja))
            {
                // Čitanje sadržaja datoteke
                listaSaZarezom = System.IO.File.ReadAllText(putanja);
            }
            listaSaZarezom = listaSaZarezom.Substring(0, listaSaZarezom.Length - 2);
            lista=listaSaZarezom.Split(",");
        }

        [HttpGet]
        public async Task<IActionResult> PrikazOpremeAsync(string[] selectedItems)
        {
            List<Oprema> oprema = new List<Oprema>();
            procitajFile();

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
            return View("PrikazOpreme",oprema);
            /*zelim da mi unutar formiranjezahtjeva viewu budu dva partial viewa ovaj prikaz opreme
             i zahtjev create i da u prikazopreme bude dohvacena oprema iz baze na osnovu onog sto je odabrano
            unutar iznajmljivanje/index*/
            //return RedirectToAction("FormiranjeZahtjeva", "Iznajmljivanje");          
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
