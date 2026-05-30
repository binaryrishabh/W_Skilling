using Microsoft.AspNetCore.Mvc;
using _2_MvcModelBinding.Models;

namespace _2_MvcModelBinding.Controllers {
    public class UserController : Controller {
        // GET: Show form
        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        // POST: Handle form submission - Model binding works here
        [HttpPost]
        public IActionResult Create(User user) {
            if (ModelState.IsValid) {
                return View("Result", user);  // Show submitted data
            }
            return View(user);
        }
    }
}