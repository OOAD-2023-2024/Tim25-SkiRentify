using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkyRentifyAplikacija.Data;
using SkyRentifyAplikacija.Models;
using System.IO;

namespace SkyRentifyAplikacija.Controllers
{
    public class ZahtjevController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string tipZahtjeva; //da li je iznajmljivanje ili servisiranje
        private string opcije; //poliranje ili popravak vezova il skupa 
        private TextFileHandler fileHandler;
        private string putanjaOpcijeServisiranja = "Data/UpisaniOpcijeServisiranja.txt";
        private string putanjaTipZahtjeva = "Data/UpisaniTipZahtjeva.txt";

        public ZahtjevController(ApplicationDbContext context)
        {
            _context = context;
            fileHandler = new TextFileHandler();
        }

        public ActionResult postaviOpcijeServisiranja(string[] selectedItems)
        {
            opcije = selectedItems[0];// Upisivanje odabranih servisa za zahtjev datoteku
            fileHandler.WriteToFile(putanjaOpcijeServisiranja, opcije);
            return RedirectToAction("FormiranjeZahtjeva", "Iznajmljivanje");
        }

        public ActionResult postaviTipZahtjeva(string selectedItem)
        {          
            fileHandler.WriteToFile(putanjaTipZahtjeva, selectedItem);// Upisivanje odabranog tipa zahtjeva u datoteku
            if (selectedItem.Equals("iznajmljivanje")) return RedirectToAction("OdabirIznajmljivanje", "Iznajmljivanje");
            else return RedirectToAction("OdabirServisiranje", "Iznajmljivanje");
        }

        // GET: Zahtjev
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Zahtjev.Include(z => z.klijent);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Zahtjev/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjev = await _context.Zahtjev
                .Include(z => z.klijent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zahtjev == null)
            {
                return NotFound();
            }

            return View(zahtjev);
        }

            // GET: Zahtjev/Create
            /*public IActionResult Create()
            {
                ViewData["KlijentId"] = new SelectList(_context.Klijent, "Id", "Id");
                return View();
            }*/

            // POST: Zahtjev/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,datumPodnosenjaZahtjeva,datumIzdavanjaUsluge,datumZavrsetkaUsluge,KlijentId,klijent,cijena,popust,placeno")] Zahtjev zahtjev)
        {
            tipZahtjeva= fileHandler.ReadFromFile(putanjaTipZahtjeva);
            opcije=fileHandler.ReadFromFile(putanjaOpcijeServisiranja);
            if (ModelState.IsValid)
            {
                _context.Add(zahtjev.klijent);
                await _context.SaveChangesAsync();

                int noviKlijentId = zahtjev.klijent.Id;
                zahtjev.KlijentId = noviKlijentId;
                zahtjev.datumPodnosenjaZahtjeva = DateTime.Today;

                _context.Add(zahtjev);
                await _context.SaveChangesAsync();

                List<TipZahtjeva> sviTipoviZahtjeva = await _context.TipZahtjeva.ToListAsync();

                if (tipZahtjeva.Contains("iznajmljivanje"))
                {
                    //treba povezat zahtjev sa tipom zahtjeva u medjutabeli
                    TipZahtjeva tip = sviTipoviZahtjeva.Find(t => t.naziv == Tip.IZNAJMLJIVANJE);
                    TipoviZahtjeva noviZahtjevTip = new TipoviZahtjeva
                    {
                        ZahtjevId = zahtjev.Id,
                        TipZahtjevaId = tip.ID
                    };
                    _context.Add(noviZahtjevTip);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    //sad provjera je li poliranje ili popravak vezova ili oboje
                    //naci u bazi to sto treba azurirati cijenu zahtjeva onda napravit ono za medjutabelu i povezat ih
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlijentId"] = new SelectList(_context.Klijent, "Id", "Id", zahtjev.KlijentId);
            return View(zahtjev);
        }

        // GET: Zahtjev/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjev = await _context.Zahtjev.FindAsync(id);
            if (zahtjev == null)
            {
                return NotFound();
            }
            ViewData["KlijentId"] = new SelectList(_context.Klijent, "Id", "Id", zahtjev.KlijentId);
            return View(zahtjev);
        }

        // POST: Zahtjev/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,datumPodnosenjaZahtjeva,datumIzdavanjaUsluje,datumZavrsetkaUsluge,KlijentId,cijena,popust,placeno")] Zahtjev zahtjev)
        {
            if (id != zahtjev.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zahtjev);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZahtjevExists(zahtjev.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlijentId"] = new SelectList(_context.Klijent, "Id", "Id", zahtjev.KlijentId);
            return View(zahtjev);
        }

        // GET: Zahtjev/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahtjev = await _context.Zahtjev
                .Include(z => z.klijent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zahtjev == null)
            {
                return NotFound();
            }

            return View(zahtjev);
        }

        // POST: Zahtjev/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zahtjev = await _context.Zahtjev.FindAsync(id);
            if (zahtjev != null)
            {
                _context.Zahtjev.Remove(zahtjev);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZahtjevExists(int id)
        {
            return _context.Zahtjev.Any(e => e.Id == id);
        }
    }
}
