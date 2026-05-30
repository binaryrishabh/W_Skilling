using Microsoft.AspNetCore.Mvc.RazorPages;
using _2_RazorPages_WithPageModels.Models;
using _2_RazorPages_WithPageModels.Services;

namespace _2_RazorPages_WithPageModels.Pages.Items {
    public class IndexModel : PageModel {
        private readonly ItemService _itemService;
        public List<Item> Items { get; set; }

        public IndexModel(ItemService itemService) {
            _itemService = itemService;
        }

        public void OnGet() {
            Items = _itemService.GetAll();
        }
    }
}