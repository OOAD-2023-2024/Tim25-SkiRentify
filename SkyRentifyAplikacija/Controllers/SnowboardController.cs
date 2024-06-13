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
    public class SnowboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SnowboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Snowboard
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Snowboard.ToListAsync());
        }

        // GET: Snowboard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snowboard = await _context.Snowboard
                .FirstOrDefaultAsync(m => m.Id == id);
            if (snowboard == null)
            {
                return NotFound();
            }

            return View(snowboard);
        }

        // GET: Snowboard/Create
        [Authorize(Roles = "Vlasnik")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Snowboard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Create([Bind("duzina,Id,cijena,marka,materijal")] Snowboard snowboard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(snowboard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(snowboard);
        }

        // GET: Snowboard/Edit/5
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snowboard = await _context.Snowboard.FindAsync(id);
            if (snowboard == null)
            {
                return NotFound();
            }
            return View(snowboard);
        }

        // POST: Snowboard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Edit(int id, double cijena)
        {
            var snowboard=await _context.Snowboard.FindAsync(id);
            if (snowboard==null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    snowboard.cijena=cijena;
                    _context.Update(snowboard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnowboardExists(snowboard.Id))
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
            return View(snowboard);
        }

        // GET: Snowboard/Delete/5
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snowboard = await _context.Snowboard
                .FirstOrDefaultAsync(m => m.Id == id);
            if (snowboard == null)
            {
                return NotFound();
            }

            return View(snowboard);
        }

        // POST: Snowboard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var snowboard = await _context.Snowboard.FindAsync(id);
            if (snowboard != null)
            {
                _context.Snowboard.Remove(snowboard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SnowboardExists(int id)
        {
            return _context.Snowboard.Any(e => e.Id == id);
        }
    }
}
