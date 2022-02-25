using EvidenceSkladu.Data;
using EvidenceSkladu.Models;
using Microsoft.AspNetCore.Mvc;

namespace EvidenceSkladu.Controllers
{
    public class ProduktController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProduktController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Produkt> objProduktList = _db.Produkty;
            return View(objProduktList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produkt obj)
        {
            if (obj.Nazev == obj.PocetProduktu.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Produkty.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Produkt byl úspěšně vytvořen";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var produktFromDb = _db.Produkty.Find(id);
 

            if (produktFromDb == null)
            {
                return NotFound();
            }

            return View(produktFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Produkt obj)
        {
            if (obj.Nazev == obj.PocetProduktu.ToString())
            {
                ModelState.AddModelError("nazev", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Produkty.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Produkt byl úspěšně editován";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var produktFromDb = _db.Produkty.Find(id);
           

            if (produktFromDb == null)
            {
                return NotFound();
            }

            return View(produktFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Produkty.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Produkty.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Produkt byl smazán.";
            return RedirectToAction("Index");

        }
    }
}



