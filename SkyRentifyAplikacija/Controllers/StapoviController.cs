using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkyRentifyAplikacija.Data;
using SkyRentifyAplikacija.Models;

namespace SkyRentifyAplikacija.Controllers
{
    public class StapoviController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StapoviController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stapovi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stapovi.ToListAsync());
        }

        // GET: Stapovi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stapovi = await _context.Stapovi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stapovi == null)
            {
                return NotFound();
            }

            return View(stapovi);
        }

        // GET: Stapovi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stapovi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("duzina,Id,cijena,marka,materijal")] Stapovi stapovi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stapovi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stapovi);
        }

        // GET: Stapovi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stapovi = await _context.Stapovi.FindAsync(id);
            if (stapovi == null)
            {
                return NotFound();
            }
            return View(stapovi);
        }

        // POST: Stapovi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("duzina,Id,cijena,marka,materijal")] Stapovi stapovi)
        {
            if (id != stapovi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stapovi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StapoviExists(stapovi.Id))
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
            return View(stapovi);
        }

        // GET: Stapovi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stapovi = await _context.Stapovi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stapovi == null)
            {
                return NotFound();
            }

            return View(stapovi);
        }

        // POST: Stapovi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stapovi = await _context.Stapovi.FindAsync(id);
            if (stapovi != null)
            {
                _context.Stapovi.Remove(stapovi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StapoviExists(int id)
        {
            return _context.Stapovi.Any(e => e.Id == id);
        }
    }
}
