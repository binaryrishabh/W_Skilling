using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Secure_Login_App.Models;

namespace Secure_Login_App.Controllers {
    [Authorize(Roles = "User")]
    public class UserController : Controller {
        private readonly UserManager<Application_User> _userManager;

        public UserController(UserManager<Application_User> userManager) {
            _userManager = userManager;
        }

        public async Task<IActionResult> User_Profile() {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }
    }
}