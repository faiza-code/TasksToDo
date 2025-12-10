using Microsoft.AspNetCore.Mvc;
using TasksToGo.Context;
using TasksToGo.Models;

namespace TasksToGo.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db; 
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        //action ==> view 
        public IActionResult Index()
        {
            var cats = _db.TaskCategories.ToList();
            return View(cats);
        }
        public IActionResult Detail(int Id)
        {
           var cat= _db.TaskCategories.Find(Id);
                return View(cat);
            
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskCategory cat)
        {
            if(ModelState.IsValid)
            {
                _db.TaskCategories.Add(cat);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cat);

        }

        public IActionResult Update(int Id)
        {
            var cat = _db.TaskCategories.Find(Id);

            return View(cat);
        }
        [HttpPost]
        public IActionResult Update(TaskCategory cat)
        {
            //var ca = _db.TaskCategories.Find(cat.Id);
            _db.TaskCategories.Update(cat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var cat = _db.TaskCategories.Find(Id);
            _db.TaskCategories.Remove(cat);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
