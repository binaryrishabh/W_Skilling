using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _2_RazorPages_ItemManager.Models;
using _2_RazorPages_ItemManager.Services;

namespace _2_RazorPages_ItemManager.Pages {
    public class AddItemModel : PageModel {
        private readonly ItemService _itemService;

        [BindProperty]
        public Item NewItem { get; set; }

        public string SuccessMessage { get; set; }

        public AddItemModel(ItemService itemService) {
            _itemService = itemService;
        }

        public void OnGet() {
            NewItem = new Item();
        }

        public IActionResult OnPost() {
            if (ModelState.IsValid) {
                _itemService.Add(NewItem);
                SuccessMessage = $"Item '{NewItem.Name}' added by {NewItem.OwnerName}!";
                NewItem = new Item(); // Reset form
                return Page();
            }
            return Page();
        }
    }
}