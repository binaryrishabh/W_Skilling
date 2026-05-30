using _2_RazorPages_ItemManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace _2_RazorPages_ItemManager.Services {
    public class ItemService {
        private static List<Item> _items = new List<Item>
        {
            new Item { Id = 1, Name = "Laptop", OwnerName = "Rishabh" },
            new Item { Id = 2, Name = "Phone", OwnerName = "Rishu" },
            new Item { Id = 3, Name = "Tablet", OwnerName = "Cotton" }
        };
        private static int _nextId = 4;

        public List<Item> GetAll() => _items;

        public void Add(Item item) {
            item.Id = _nextId++;
            _items.Add(item);
        }
    }
}