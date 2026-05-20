using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagementPlatform.Controllers {
    [Authorize]
    public class HomeController : Controller {
        public IActionResult Dashboard() => View();
    }
}