using _2_RazorPages_WithPageModels.Models;
using System.Collections.Generic;
using System.Linq;

namespace _2_RazorPages_WithPageModels.Services {
    public class ItemService {
        private static List<Item> _items = new List<Item>
        {
            new Item { Id = 1, Name = "Laptop", AddedBy = "Rishabh" },
            new Item { Id = 2, Name = "Mouse", AddedBy = "Rishu" }
        };

        public List<Item> GetAll() => _items;

        public void Add(Item item) {
            item.Id = _items.Any() ? _items.Max(i => i.Id) + 1 : 1;
            _items.Add(item);
        }
    }
}