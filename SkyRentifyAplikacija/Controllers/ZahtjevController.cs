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
        private string putanjaOdabirIznajmljivanje = "Data/UpisaniOdabirIznajmljivanje.txt";

        public ZahtjevController(ApplicationDbContext context)
        {
            _context = context;
            fileHandler = new TextFileHandler();
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
            public IActionResult Create()
            {
              string tipZahtjeva = fileHandler.ReadFromFile(putanjaTipZahtjeva);

              if (tipZahtjeva == "servisiranje")
               {
                // Show the CreateServisiranje view for service requests
                return View("CreateServisiranje");
               }
              else
               {
                // Show the regular Create view for other requests (presumably rentals)
                var nivoVjestineTipovi = Enum.GetValues(typeof(Vjestina)).Cast<Vjestina>().ToList();
                ViewBag.VjestinaTipovi = new SelectList(nivoVjestineTipovi.Select(v => new { Id = (int)v, Name = v.ToString() }), "Id", "Name");
                return View("Create");
               }
            }

        // POST: Zahtjev/Create
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
                    return RedirectToAction("PrikazOpreme", new { zahtjevId = zahtjev.Id });
                }
                else
                {
                    TipZahtjeva tipPoliranje = sviTipoviZahtjeva.Find(t => t.naziv == Tip.POLIRANJE);
                    TipZahtjeva tipPopravakVezova = sviTipoviZahtjeva.Find(t => t.naziv == Tip.POPRAVAK_VEZOVA);
                    var cijena1 = tipPoliranje.cijena;
                    var cijena2 = tipPopravakVezova.cijena;
                    TipoviZahtjeva noviZahtjevTip1 = new TipoviZahtjeva
                    {
                        ZahtjevId = zahtjev.Id,
                        TipZahtjevaId = tipPoliranje.ID
                    };

                    TipoviZahtjeva noviZahtjevTip2 = new TipoviZahtjeva
                    {
                        ZahtjevId = zahtjev.Id,
                        TipZahtjevaId = tipPopravakVezova.ID
                    };
                    if (opcije.Contains("Poliranje skija") && opcije.Contains("Popravak vezova"))
                    {                 
                        _context.Add(noviZahtjevTip1);
                        await _context.SaveChangesAsync();
                        _context.Add(noviZahtjevTip2);
                        await _context.SaveChangesAsync();
                        zahtjev.cijena= cijena1 + cijena2;
                    }
                    else if (opcije.Contains("Poliranje skija"))
                    {
                        _context.Add(noviZahtjevTip1);
                        await _context.SaveChangesAsync();
                        zahtjev.cijena= cijena1;
                    }
                    else if (opcije.Contains("Popravak vezova"))
                    {
                        _context.Add(noviZahtjevTip2);
                        await _context.SaveChangesAsync();
                        zahtjev.cijena= cijena2;
                    }
                    _context.Update(zahtjev);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ProcesPlacanja", new { zahtjevId = zahtjev.Id });
                    //poziv koji ce odnijeti tamo prema placanju
                }
            }
            //ViewData["KlijentId"] = new SelectList(_context.Klijent, "Id", "Id", zahtjev.KlijentId);
            return View(zahtjev);
        }

        public async Task<IActionResult> PrikazOpreme(int zahtjevId)
        {
            //prikaz opreme za iznajmljivanje koja je na pocetku odabrana
            //uzmes zahtjev preko zahtjevid iz baze
            var zahtjev = await _context.Zahtjev.FindAsync(zahtjevId);

            //uzmes klijent id preko tog zahtjeva
            var klijent = await _context.Klijent.FindAsync(zahtjev.KlijentId);

            //uzmes visinu i nivo vjestine od klijenta 
            double visina = klijent.visina;
            var vjestina = klijent.nivoVjestine;
            //i na osnovu toga vracat odg listu za opremu

            // U kontroleru
            var vjestineList = Enum.GetValues(typeof(Vjestina))
                                   .Cast<Vjestina>()
                                   .Select(v => new SelectListItem
                                   {
                                       Text = v.ToString(),
                                       Value = v.ToString()
                                   }).ToList();
            ViewData["KlijentNivoVjestine"] = vjestineList;

            var odabranestavke =fileHandler.ReadFromFile(putanjaOdabirIznajmljivanje);
            var odabranaLista= odabranestavke.Split(',').ToList();
            var skije = new List<Skije>();
            var kacige= new List<Kaciga>();
            var pancerice = new List<Pancerice>();
            var snowboard = new List<Snowboard>();
            var snowboardCipele = new List<SnowboardCipele>();
            var stapovi = new List<Stapovi>();
            if (odabranaLista.Contains("Skije"))
            {
                skije= await _context.Skije.ToListAsync();
                if(vjestina.ToString() == Vjestina.POCETNIK.ToString()) //pocetnik 180
                {
                    skije.RemoveAll(s => s.duzina < visina - 30 || s.duzina > visina - 25);
                }
                else
                {
                    skije.RemoveAll(s => s.duzina < visina - 20 || s.duzina > visina - 15);
                }

            }
            if (odabranaLista.Contains("Pancerice"))
            {
                pancerice = await _context.Pancerice.ToListAsync();
            }
            if(odabranaLista.Contains("Kaciga"))
            {
                kacige = await _context.Kaciga.ToListAsync();
            }
            if(odabranaLista.Contains("Stapovi"))
            {
                stapovi = await _context.Stapovi.ToListAsync();
            }
            if(odabranaLista.Contains("Snowboard"))
            {
                snowboard = await _context.Snowboard.ToListAsync();
            }
            if(odabranaLista.Contains("SnowboardCipele"))
            {
                snowboardCipele = await _context.SnowboardCipele.ToListAsync();
            }
            var viewModel = new OpremaPrikazViewModel
            {
                Skije = skije,
                Pancerice = pancerice,
                Snowboard = snowboard,
                SnowboardCipele = snowboardCipele,
                Stapovi = stapovi,
                Kacige = kacige,
                ZahtjevId = zahtjevId
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> OdaberiOpremu(int zahtjevId, string selectedItems)
        {
            double cijena = 0.0;
            var opremaIds = selectedItems.Split(',').Select(int.Parse).ToList();

            foreach (var opremaId in opremaIds)
            {
                var skije = await _context.Skije.FindAsync(opremaId);
                var pancerice = await _context.Pancerice.FindAsync(opremaId);
                var kacige = await _context.Kaciga.FindAsync(opremaId);
                var stapovi = await _context.Stapovi.FindAsync(opremaId);
                var snowboard = await _context.Snowboard.FindAsync(opremaId);
                var snowboardCipele = await _context.SnowboardCipele.FindAsync(opremaId);

                // Provjeravamo postoji li stavka opreme s tim ID-om i dodjeljujemo cijenu
                if (skije != null)
                {
                    cijena += skije.cijena;
                }
                else if (pancerice != null)
                {
                    cijena += pancerice.cijena;
                }
                else if (kacige != null)
                {
                    cijena += kacige.cijena;
                }
                else if (stapovi != null)
                {
                    cijena += stapovi.cijena;
                }
                else if (snowboard != null)
                {
                    cijena += snowboard.cijena;
                }
                else if (snowboardCipele != null)
                {
                    cijena += snowboardCipele.cijena;
                }
            }

            var zahtjev = await _context.Zahtjev.FindAsync(zahtjevId);
            if (zahtjev != null)
            {
                zahtjev.cijena += cijena;
                _context.Update(zahtjev);
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }

            // Spremamo sve stavke u bazi podataka
            foreach (var opremaId in opremaIds)
            {
                var stavkaZahtjeva = new StavkaZahtjeva
                {
                    ZahtjevId = zahtjevId,
                    OpremaId = opremaId,
                };
                _context.Add(stavkaZahtjeva);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("ProcesPlacanja", new { zahtjevId = zahtjev.Id });
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

        //rukovanje sa placanjem

        // Metoda za prikaz forme za plaćanje
        public IActionResult ProcesPlacanja(int zahtjevId)
        {
            var zahtjev = _context.Zahtjev.Find(zahtjevId);
            if (zahtjev == null)
            {
                return NotFound();
            }

            var model = new ProcesPlacanjaModel
            {
                ZahtjevId = zahtjevId,
                UkupnaCijena = zahtjev.cijena
            };

            return View(model);
        }

        // Metoda za rukovanje POST zahtjevom za plaćanje
        [HttpPost]
        public async Task<IActionResult> ProcesPlacanja(ProcesPlacanjaModel model)
        {
            if (ModelState.IsValid)
            {
                //ovdje na osnovu broja dana izracunati popust i primijeniti na cijenu
                var zahtjev = _context.Zahtjev.Find(model.ZahtjevId);
                if (zahtjev == null)
                {
                    return NotFound();
                }
                zahtjev.placeno = true;
                _context.Update(zahtjev);
                await _context.SaveChangesAsync();
                return RedirectToAction("UspjesnoPlacanje", new { zahtjevId = model.ZahtjevId });
            }

            // Ako postoji greška u validaciji, ponovo prikazati formu
            return View(model);
        }

        public IActionResult UspjesnoPlacanje(int zahtjevId)
        {
            var zahtjev = _context.Zahtjev.Find(zahtjevId);
            if (zahtjev == null)
            {
                return NotFound();
            }

            return View(zahtjev);
        }
    }
}
