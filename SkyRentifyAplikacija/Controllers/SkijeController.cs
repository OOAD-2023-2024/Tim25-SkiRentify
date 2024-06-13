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
    public class SkijeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkijeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Skije
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Skije.ToListAsync());
        }

        // GET: Skije/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skije = await _context.Skije
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skije == null)
            {
                return NotFound();
            }

            return View(skije);
        }

        // GET: Skije/Create
        [Authorize(Roles = "Vlasnik")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skije/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Create([Bind("duzina,sirina,Id,cijena,marka,materijal")] Skije skije)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skije);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skije);
        }

        // GET: Skije/Edit/5
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skije = await _context.Skije.FindAsync(id);
            if (skije == null)
            {
                return NotFound();
            }
            return View(skije);
        }

        // POST: Skije/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Edit(int id, double cijena)
        {
            //za azuriranje cijene
            var skije=await _context.Skije.FindAsync(id);
            if (skije == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    skije.cijena = cijena;
                    _context.Update(skije);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkijeExists(skije.Id))
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
            return View(skije);
        }

        // GET: Skije/Delete/5
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skije = await _context.Skije
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skije == null)
            {
                return NotFound();
            }

            return View(skije);
        }

        // POST: Skije/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skije = await _context.Skije.FindAsync(id);
            if (skije != null)
            {
                _context.Skije.Remove(skije);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkijeExists(int id)
        {
            return _context.Skije.Any(e => e.Id == id);
        }
    }
}
