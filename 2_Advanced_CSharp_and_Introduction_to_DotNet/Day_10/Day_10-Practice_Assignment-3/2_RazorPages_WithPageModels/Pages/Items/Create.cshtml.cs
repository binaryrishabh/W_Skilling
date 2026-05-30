using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _2_RazorPages_WithPageModels.Models;
using _2_RazorPages_WithPageModels.Services;

namespace _2_RazorPages_WithPageModels.Pages.Items {
    public class CreateModel : PageModel {
        private readonly ItemService _itemService;
        [BindProperty]
        public Item NewItem { get; set; }

        public CreateModel(ItemService itemService) {
            _itemService = itemService;
        }

        public void OnGet() {
            NewItem = new Item();
        }

        public IActionResult OnPost() {
            if (ModelState.IsValid) {
                _itemService.Add(NewItem);
                return RedirectToPage("/Items/Index");
            }
            return Page();
        }
    }
}