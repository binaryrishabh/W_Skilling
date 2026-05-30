using Microsoft.AspNetCore.Mvc.RazorPages;
using _1_AdvancedRazorPages.Models;

namespace _1_AdvancedRazorPages.Pages {
    public class ProductDetailsModel : PageModel {
        public Product? Product { get; set; }

        public void OnGet(int id) {
            Product = ProductsModel._products.FirstOrDefault(p => p.ProductID == id);
        }
    }
}