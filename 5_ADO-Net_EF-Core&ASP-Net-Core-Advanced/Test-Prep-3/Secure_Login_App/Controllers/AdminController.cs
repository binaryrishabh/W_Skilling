using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Secure_Login_App.Models;

namespace Secure_Login_App.Controllers {
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller {
        private readonly UserManager<Application_User> _userManager;

        public AdminController(UserManager<Application_User> userManager) {
            _userManager = userManager;
        }

        public async Task<IActionResult> Admin_Dashboard() {
            // Get all users to display in dashboard
            var users = _userManager.Users.ToList();
            ViewBag.AdminName = User.Identity.Name;
            return View(users);
        }
    }
}