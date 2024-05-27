using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkyRentifyAplikacija.Data;

namespace SkyRentifyAplikacija.Controllers
{
    public class OpremaController : Controller
    {

        //dodani dio za dohvacanje iz baze 
        private readonly ApplicationDbContext _context;

        public OpremaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OpremaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OpremaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OpremaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OpremaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OpremaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OpremaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OpremaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OpremaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
