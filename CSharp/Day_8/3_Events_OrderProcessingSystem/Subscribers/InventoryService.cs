using _3_Events_OrderProcessingSystem.EventArgs;

namespace _3_Events_OrderProcessingSystem.Subscribers {
    public class InventoryService {
        public void OnOrderPlaced(object sender, OrderPlacedEventArgs e) {
            Console.WriteLine($"  📦 Inventory updated for Order #{e.OrderId}");
        }
    }
}