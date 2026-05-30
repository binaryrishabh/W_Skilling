using Microsoft.AspNetCore.Mvc.RazorPages;
using _2_RazorPages_ItemManager.Models;
using _2_RazorPages_ItemManager.Services;
using System.Collections.Generic;

namespace _2_RazorPages_ItemManager.Pages {
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