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
    public class TipZahtjevaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipZahtjevaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipZahtjeva
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipZahtjeva.ToListAsync());
        }

        // GET: TipZahtjeva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipZahtjeva = await _context.TipZahtjeva
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipZahtjeva == null)
            {
                return NotFound();
            }

            return View(tipZahtjeva);
        }

        // GET: TipZahtjeva/Create
        [Authorize(Roles = "Vlasnik")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipZahtjeva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Create([Bind("ID,naziv,cijena")] TipZahtjeva tipZahtjeva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipZahtjeva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipZahtjeva);
        }

        // GET: TipZahtjeva/Edit/5
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipZahtjeva = await _context.TipZahtjeva.FindAsync(id);
            if (tipZahtjeva == null)
            {
                return NotFound();
            }
            return View(tipZahtjeva);
        }

        // POST: TipZahtjeva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Edit(int id, double cijena)
        {
            var tipzahtjeva=await _context.TipZahtjeva.FindAsync(id);
            if (tipzahtjeva==null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tipzahtjeva.cijena=cijena;
                    _context.Update(tipzahtjeva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipZahtjevaExists(tipzahtjeva.ID))
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
            return View(tipzahtjeva);
        }

        // GET: TipZahtjeva/Delete/5
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipZahtjeva = await _context.TipZahtjeva
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tipZahtjeva == null)
            {
                return NotFound();
            }

            return View(tipZahtjeva);
        }

        // POST: TipZahtjeva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipZahtjeva = await _context.TipZahtjeva.FindAsync(id);
            if (tipZahtjeva != null)
            {
                _context.TipZahtjeva.Remove(tipZahtjeva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipZahtjevaExists(int id)
        {
            return _context.TipZahtjeva.Any(e => e.ID == id);
        }
    }
}
