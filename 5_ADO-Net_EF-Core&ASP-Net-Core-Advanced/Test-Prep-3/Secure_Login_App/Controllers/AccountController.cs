using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Secure_Login_App.Models;
using Secure_Login_App.ViewModels;

namespace Secure_Login_App.Controllers {
    public class AccountController : Controller {
        private readonly UserManager<Application_User> _userManager;
        private readonly SignInManager<Application_User> _signInManager;

        public AccountController(
            UserManager<Application_User> userManager,
            SignInManager<Application_User> signInManager) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login() {
            if (User.Identity.IsAuthenticated) {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login_ViewModel model) {
            if (ModelState.IsValid) {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null) {
                    var result = await _signInManager.PasswordSignInAsync(
                        model.Username,
                        model.Password,
                        model.Remember_Me,
                        lockoutOnFailure: false);

                    if (result.Succeeded) {
                        var roles = await _userManager.GetRolesAsync(user);

                        if (roles.Contains("Admin")) {
                            return RedirectToAction("Admin_Dashboard", "Admin");
                        }
                        else if (roles.Contains("User")) {
                            return RedirectToAction("User_Profile", "User");
                        }
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout() {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Access_Denied() {
            return View();
        }
    }
}