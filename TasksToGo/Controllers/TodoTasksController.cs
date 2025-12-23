using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TasksToGo.Context;
using TasksToGo.Models;
using TasksToGo.Models.AuthModel;

namespace TasksToGo.Controllers
{
    [Authorize] 
    public class TodoTasksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public TodoTasksController(ApplicationDbContext context,UserManager<AppUser> userManager) 
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            
            var userId = _userManager.GetUserId(User);
            
            var userTodos = await _context.todoTasks
            //.Include(t => t.Category)
            .Where(t => t.UserId == userId) 
            .ToListAsync();
            return View(userTodos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoTask todoTask)
        {
            if (ModelState.IsValid)
            {
                
                todoTask.UserId = _userManager.GetUserId(User);
                _context.Add(todoTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todoTask);
        }














    }
}
