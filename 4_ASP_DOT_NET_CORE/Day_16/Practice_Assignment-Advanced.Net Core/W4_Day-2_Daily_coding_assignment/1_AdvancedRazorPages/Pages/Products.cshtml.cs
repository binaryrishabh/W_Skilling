using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using _1_AdvancedRazorPages.Models;

namespace _1_AdvancedRazorPages.Pages {
    public class ProductsModel : PageModel {
        public static List<Product> _products = new List<Product>();

        public List<Product> Products { get; set; } = new List<Product>();

        [BindProperty]
        public Product NewProduct { get; set; } = new Product();

        [BindProperty]
        public string CategoriesInput { get; set; } = string.Empty;

        public void OnGet() {
            Products = _products;
        }

        public IActionResult OnPost() {
            var categoryNames = CategoriesInput.Split(',', StringSplitOptions.RemoveEmptyEntries);
            int catId = 1;
            foreach (var name in categoryNames) {
                NewProduct.Categories.Add(new Category
                {
                    CategoryId = catId++,
                    Name = name.Trim()
                });
            }
            _products.Add(NewProduct);
            Products = _products;
            return RedirectToPage();
        }
    }
}