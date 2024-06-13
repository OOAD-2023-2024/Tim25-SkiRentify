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
    public class PancericeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PancericeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pancerice
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pancerice.ToListAsync());
        }

        // GET: Pancerice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pancerice = await _context.Pancerice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pancerice == null)
            {
                return NotFound();
            }

            return View(pancerice);
        }

        // GET: Pancerice/Create
        [Authorize(Roles = "Vlasnik")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pancerice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Create([Bind("velicina,Id,cijena,marka,materijal")] Pancerice pancerice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pancerice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pancerice);
        }

        // GET: Pancerice/Edit/5
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pancerice = await _context.Pancerice.FindAsync(id);
            if (pancerice == null)
            {
                return NotFound();
            }
            return View(pancerice);
        }

        // POST: Pancerice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Edit(int id,double cijena)
        {
            var pancerice = await _context.Pancerice.FindAsync(id);
            if (pancerice==null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    pancerice.cijena = cijena;
                    _context.Update(pancerice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PancericeExists(pancerice.Id))
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
            return View(pancerice);
        }

        // GET: Pancerice/Delete/5
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pancerice = await _context.Pancerice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pancerice == null)
            {
                return NotFound();
            }

            return View(pancerice);
        }

        // POST: Pancerice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pancerice = await _context.Pancerice.FindAsync(id);
            if (pancerice != null)
            {
                _context.Pancerice.Remove(pancerice);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PancericeExists(int id)
        {
            return _context.Pancerice.Any(e => e.Id == id);
        }
    }
}
