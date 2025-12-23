using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using TasksToGo.Context;
using TasksToGo.Models;
using TasksToGo.Models.AuthModel;

namespace TasksToGo.Controllers
{
    [Authorize] 
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<AppUser> _userManager;


        public HomeController(ApplicationDbContext db, UserManager<AppUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var tasks = _db.todoTasks
              .Include(t => t.taskCategory)
              .Where(t => t.UserId == userId)
              .ToList();
           
            return View(tasks);
        }

        public IActionResult Details(int id)
        {
            var todo = _db.todoTasks.Include(w => w.taskCategory).FirstOrDefault(t => t.Id == id);
            return View(todo);

        }
        public IActionResult Create()
        {
            var cats = new SelectList(_db.TaskCategories, "Id", "Name");
            //var cats = _db.TaskCategories.ToList();

            ViewBag.CategoriesList = cats;

            return View();
        }

        [HttpPost]
        public IActionResult Create(TodoTask obj)
        {
            if (ModelState.IsValid)
            {
                obj.UserId = _userManager.GetUserId(User);
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
            obj.UserId = _userManager.GetUserId(User);
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
