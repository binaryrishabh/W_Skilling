using Microsoft.AspNetCore.Mvc;

namespace _3_RoutingDemo.Controllers;

public class RestaurantController : Controller {
    // URL: /Restaurant/Menu or /
    public IActionResult Menu() {
        return Content("Menu Page - Rishabh");
    }

    // URL: /Restaurant/Details/5
    [Route("Restaurant/Details/{id:int}")]
    public IActionResult Details(int id) {
        return Content($"Restaurant ID: {id} - Rahul");
    }

    // URL: /Restaurant/Search/Amit
    [Route("Restaurant/Search/{name}")]
    public IActionResult Search(string name) {
        return Content($"Searching: {name} - Rohan");
    }
}