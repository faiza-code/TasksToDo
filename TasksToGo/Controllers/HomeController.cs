using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TasksToGo.Context;
using TasksToGo.Models;

namespace TasksToGo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
           
        }

        public IActionResult Index()
        {
            // Eager Loading
            var tasks = _db.todoTasks.Include(w=>w.taskCategory).ToList();  

            return View(tasks);
        }
        public IActionResult Details(int id)
        {
            var todo = _db.todoTasks.Include(w => w.taskCategory).FirstOrDefault(t => t.Id == id);
            return View(todo);

        }
        public IActionResult Create()
        {
            var cats = new  SelectList(_db.TaskCategories, "Id" , "Name");
            //var cats = _db.TaskCategories.ToList();

            ViewBag.CategoriesList = cats;

            return View();
        }

        [HttpPost]
        public IActionResult Create(TodoTask obj)
        {
            if (ModelState.IsValid)
            {
                _db.todoTasks.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            var cats = new SelectList(_db.TaskCategories, "Id", "Name");
            ViewBag.CategoriesList = cats;

            return View(obj);
        }
       
        public IActionResult Update(int id )
        {
            var todo = _db.todoTasks.Include(w => w.taskCategory).FirstOrDefault(t => t.Id == id);
            var cats = new SelectList(_db.TaskCategories, "Id", "Name");
            //var cats = _db.TaskCategories.ToList();

            ViewBag.CategoriesList = cats;  
            return View(todo);
        }
        [HttpPost]
        public IActionResult Update(TodoTask obj)
        {
            if (ModelState.IsValid)
            {
                _db.todoTasks.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            var cats = new SelectList(_db.TaskCategories, "Id", "Name");
            ViewBag.CategoriesList = cats;

            return View(obj);
        }
    }
}
