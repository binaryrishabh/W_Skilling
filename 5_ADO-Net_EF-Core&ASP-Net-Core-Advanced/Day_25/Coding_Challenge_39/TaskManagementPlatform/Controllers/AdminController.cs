using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementPlatform.Data;
using TaskManagementPlatform.Models;

namespace TaskManagementPlatform.Controllers {
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context) => _context = context;

        public IActionResult ManageTasks() => View(_context.Tasks.ToList());
    }
}