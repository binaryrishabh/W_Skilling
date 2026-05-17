using Microsoft.AspNetCore.Mvc;
using _2_AJAX_ProductPrice.Models;

namespace _2_AJAX_ProductPrice.Controllers {
    public class ProductController : Controller {
    // Dummy data (acting as database)
        private List<Product> GetProducts() {
            return new List<Product> {
                new Product { Id = 1, Name = "Mouse", Price = 1299 },
                new Product { Id = 2, Name = "Hard disk", Price = 2499 },
                new Product { Id = 3, Name = "Keyboard", Price = 899 }
            };
        }

        // Step 1: Show the page
        public IActionResult Index() {
            return View();
        }

        // Step 2: AJAX calls this
        [HttpPost]
        public IActionResult GetPrice(int id) {
            var product = GetProducts().FirstOrDefault(p => p.Id == id);

            if (product != null) {
                return Json(new { success = true, price = product.Price, name = product.Name });
            }

            return Json(new { success = false, message = "Product not found" });
        }
    }
}