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
    public class VlasnikController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VlasnikController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vlasnik
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vlasnik.ToListAsync());
        }

        // GET: Vlasnik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vlasnik = await _context.Vlasnik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vlasnik == null)
            {
                return NotFound();
            }

            return View(vlasnik);
        }

        // GET: Vlasnik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vlasnik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ime,prezime,korisnickoIme,sifra")] Vlasnik vlasnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vlasnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vlasnik);
        }

        // GET: Vlasnik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vlasnik = await _context.Vlasnik.FindAsync(id);
            if (vlasnik == null)
            {
                return NotFound();
            }
            return View(vlasnik);
        }

        // POST: Vlasnik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ime,prezime,korisnickoIme,sifra")] Vlasnik vlasnik)
        {
            if (id != vlasnik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vlasnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VlasnikExists(vlasnik.Id))
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
            return View(vlasnik);
        }

        // GET: Vlasnik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vlasnik = await _context.Vlasnik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vlasnik == null)
            {
                return NotFound();
            }

            return View(vlasnik);
        }

        // POST: Vlasnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vlasnik = await _context.Vlasnik.FindAsync(id);
            if (vlasnik != null)
            {
                _context.Vlasnik.Remove(vlasnik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VlasnikExists(int id)
        {
            return _context.Vlasnik.Any(e => e.Id == id);
        }
    }
}
