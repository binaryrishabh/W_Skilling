using _3_Events_OrderProcessingSystem.EventArgs;

namespace _3_Events_OrderProcessingSystem.Subscribers {
    public class NotificationService {
        /// <summary>
        /// Event handler that sends SMS/Email notification to customer (Indian format)
        /// </summary>
        public void OnOrderPlaced(object sender, OrderPlacedEventArgs e) {
            Console.WriteLine($"[NotificationService] 📱 Sending SMS to {e.CustomerName}...");
            Console.WriteLine($"[NotificationService] SMS: Dear {e.CustomerName}, your order #{e.OrderId} of ₹{e.TotalAmount:N2} has been confirmed. Thank you for shopping with us!");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine($"[NotificationService] ✅ SMS sent successfully to +91-XXXXXXXX{e.OrderId % 100}");
        }
    }
}