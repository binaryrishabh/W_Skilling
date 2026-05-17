using Microsoft.AspNetCore.Mvc;
using _1_ValidationDemo.Models;

namespace _1_ValidationDemo.Controllers {
    public class UserController : Controller {
    [HttpGet]
    public IActionResult Register() {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user) {
        if (ModelState.IsValid)
            return Content("✅ Validation passed for: " + user.Name);
        return View(user);
    }

    [HttpGet]
    public IActionResult Student() {
        return View();
    }

    [HttpPost]
    public IActionResult Student(Student student) {
        if (ModelState.IsValid)
            return Content("✅ Student valid: " + student.Name);
        return View(student);
    }

    public IActionResult IsUsernameAvailable(string username) {
        var taken = new[] { "raj", "amit", "priya" };
        return Json(!taken.Contains(username.ToLower()));
    }
}
}