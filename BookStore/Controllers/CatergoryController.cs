using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class CatergoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CatergoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category>ObjectCategory = _db.Categories.ToList();
          return View(ObjectCategory);
        }
        public IActionResult CreateNew()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNew(Category obj)
        {
          if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The name and display order can't be the same");
            }
            if (obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "test is invalid value");
            }


            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();  
            
           
        }
        public IActionResult DeleteP()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult DeleteP(Category id)
        {
            _db.Categories.Remove(id);
            return RedirectToAction("Index");
        }

       
        public IActionResult Edit(int ? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFrommDb = _db.Categories.Find(id);
            if(categoryFrommDb == null) { return NotFound(); }
            return View(categoryFrommDb);
        }
    }
}
