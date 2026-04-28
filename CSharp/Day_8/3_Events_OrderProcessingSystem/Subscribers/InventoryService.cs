using _3_Events_OrderProcessingSystem.EventArgs;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Events_OrderProcessingSystem.Subscribers {
    public class InventoryService {
        /// <summary>
        /// Event handler that updates inventory stock
        /// </summary>
        public void OnOrderPlaced(object sender, OrderPlacedEventArgs e) {
            Console.WriteLine($"[InventoryService] Updating inventory for Order #{e.OrderId}...");
            Console.WriteLine($"[InventoryService] Reserved items worth ${e.TotalAmount} in stock.");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine($"[InventoryService] Inventory updated successfully!");
        }
    }
}
