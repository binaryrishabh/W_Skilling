using Microsoft.AspNetCore.Mvc;
using _2_ClientServerValidation.Models;

namespace _2_ClientServerValidation.Controllers {
    public class UserController : Controller {
        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user) {
            if (ModelState.IsValid) {
                return Content($"Welcome {user.Name} - Server validation passed!");
            }
            return View(user);
        }
    }
}