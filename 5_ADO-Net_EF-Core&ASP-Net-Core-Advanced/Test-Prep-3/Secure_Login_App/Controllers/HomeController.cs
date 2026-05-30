using Microsoft.AspNetCore.Mvc;

namespace Secure_Login_App.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            if (User.Identity.IsAuthenticated) {
                if (User.IsInRole("Admin"))
                    return RedirectToAction("Admin_Dashboard", "Admin");
                else if (User.IsInRole("User"))
                    return RedirectToAction("User_Profile", "User");
            }
            return RedirectToAction("Login", "Account");
        }
    }
}