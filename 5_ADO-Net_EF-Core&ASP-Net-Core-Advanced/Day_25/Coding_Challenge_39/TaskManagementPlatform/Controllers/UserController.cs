using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManagementPlatform.Data;
using TaskManagementPlatform.Models;

namespace TaskManagementPlatform.Controllers {
    [Authorize(Roles = "User")]
    public class UserController : Controller {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context) => _context = context;

        public IActionResult TaskList() {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tasks = _context.Tasks.Where(t => t.AssignedUserId == userId).ToList();
            return View(tasks);
        }

        [Authorize(Policy = "CanEditTask")]
        public IActionResult EditTask(int id) {
            var task = _context.Tasks.Find(id);
            return View(task);
        }
    }
}