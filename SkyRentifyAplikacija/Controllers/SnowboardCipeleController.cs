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
    public class SnowboardCipeleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SnowboardCipeleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SnowboardCipele
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.SnowboardCipele.ToListAsync());
        }

        // GET: SnowboardCipele/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snowboardCipele = await _context.SnowboardCipele
                .FirstOrDefaultAsync(m => m.Id == id);
            if (snowboardCipele == null)
            {
                return NotFound();
            }

            return View(snowboardCipele);
        }

        // GET: SnowboardCipele/Create
        [Authorize(Roles = "Vlasnik")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: SnowboardCipele/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Create([Bind("velicina,Id,cijena,marka,materijal")] SnowboardCipele snowboardCipele)
        {
            if (ModelState.IsValid)
            {
                _context.Add(snowboardCipele);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(snowboardCipele);
        }

        // GET: SnowboardCipele/Edit/5
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snowboardCipele = await _context.SnowboardCipele.FindAsync(id);
            if (snowboardCipele == null)
            {
                return NotFound();
            }
            return View(snowboardCipele);
        }

        // POST: SnowboardCipele/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Edit(int id, double cijena)
        {
            var snowboardCipele=await _context.SnowboardCipele.FindAsync(id);
            if (snowboardCipele==null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    snowboardCipele.cijena = cijena;
                    _context.Update(snowboardCipele);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnowboardCipeleExists(snowboardCipele.Id))
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
            return View(snowboardCipele);
        }

        // GET: SnowboardCipele/Delete/5
        [Authorize(Roles = "Vlasnik")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snowboardCipele = await _context.SnowboardCipele
                .FirstOrDefaultAsync(m => m.Id == id);
            if (snowboardCipele == null)
            {
                return NotFound();
            }

            return View(snowboardCipele);
        }

        // POST: SnowboardCipele/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Vlasnik")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var snowboardCipele = await _context.SnowboardCipele.FindAsync(id);
            if (snowboardCipele != null)
            {
                _context.SnowboardCipele.Remove(snowboardCipele);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SnowboardCipeleExists(int id)
        {
            return _context.SnowboardCipele.Any(e => e.Id == id);
        }
    }
}
