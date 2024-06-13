using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkyRentifyAplikacija.Data;
using SkyRentifyAplikacija.Models;

namespace SkyRentifyAplikacija.Controllers
{
    public class KacigaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KacigaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kaciga
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kaciga.ToListAsync());
        }

        // GET: Kaciga/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kaciga = await _context.Kaciga
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kaciga == null)
            {
                return NotFound();
            }

            return View(kaciga);
        }

        // GET: Kaciga/Create
        [Authorize(Roles = "Vlasnik")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kaciga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Create([Bind("velicina,Id,cijena,marka,materijal")] Kaciga kaciga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kaciga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kaciga);
        }

        // GET: Kaciga/Edit/5
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kaciga = await _context.Kaciga.FindAsync(id);
            if (kaciga == null)
            {
                return NotFound();
            }
            return View(kaciga);
        }

        // POST: Kaciga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Edit(int id, double cijena)
        {
            var kaciga = await _context.Kaciga.FindAsync(id);
            if (kaciga==null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    kaciga.cijena=cijena;
                    _context.Update(kaciga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KacigaExists(kaciga.Id))
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
            return View(kaciga);
        }

        // GET: Kaciga/Delete/5
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kaciga = await _context.Kaciga
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kaciga == null)
            {
                return NotFound();
            }

            return View(kaciga);
        }

        // POST: Kaciga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kaciga = await _context.Kaciga.FindAsync(id);
            if (kaciga != null)
            {
                _context.Kaciga.Remove(kaciga);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KacigaExists(int id)
        {
            return _context.Kaciga.Any(e => e.Id == id);
        }
    }
}
