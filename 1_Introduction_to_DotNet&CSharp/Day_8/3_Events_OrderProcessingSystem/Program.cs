using _3_Events_OrderProcessingSystem.Models;
using _3_Events_OrderProcessingSystem.Publisher;
using _3_Events_OrderProcessingSystem.Subscribers;
using _3_Events_OrderProcessingSystem.EventArgs;

namespace _3_Events_OrderProcessingSystem {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("=".PadRight(60, '='));
            Console.WriteLine("   ORDER PROCESSING SYSTEM - EVENT DEMONSTRATION");
            Console.WriteLine("=".PadRight(60, '='));

            // Step 1: Create the publisher (OrderProcessor)
            OrderProcessor orderProcessor = new OrderProcessor();

            // Step 2: Create subscribers
            NotificationService notificationService = new NotificationService();
            InventoryService inventoryService = new InventoryService();
            LoggingService loggingService = new LoggingService();

            // Step 3: Subscribe to the event
            // Each subscriber registers its handler method to the publisher's event
            orderProcessor.OrderPlaced += notificationService.OnOrderPlaced;
            orderProcessor.OrderPlaced += inventoryService.OnOrderPlaced;
            orderProcessor.OrderPlaced += loggingService.OnOrderPlaced;

            // Step 4: Create and process multiple orders with Indian names
            Console.WriteLine("\n📦 Creating orders...\n");

            Order order1 = new Order(1001, "Rajesh", 1250.50m);      // ₹1250.50
            Order order2 = new Order(1002, "Priya", 899.99m);       // ₹899.99
            Order order3 = new Order(1003, "Amit", 2500.00m);       // ₹2500.00
            Order order4 = new Order(1004, "Neha", 450.75m);        // ₹450.75
            Order order5 = new Order(1005, "Suresh", 3200.00m);     // ₹3200.00

            // Process Order 1 - Rajesh
            Console.WriteLine("\n🔹 Processing Order #1");
            orderProcessor.ProcessOrder(order1);

            // Process Order 2 - Priya
            Console.WriteLine("\n🔹 Processing Order #2");
            orderProcessor.ProcessOrder(order2);

            // Process Order 3 - Amit
            Console.WriteLine("\n🔹 Processing Order #3");
            orderProcessor.ProcessOrder(order3);

            // Process Order 4 - Neha
            Console.WriteLine("\n🔹 Processing Order #4");
            orderProcessor.ProcessOrder(order4);

            // Step 5: Demonstrate unsubscribing from events
            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine("   DEMONSTRATING UNSUBSCRIBE");
            Console.WriteLine("=".PadRight(60, '='));

            // Unsubscribe LoggingService
            Console.WriteLine("\n⚠️  Unsubscribing LoggingService from future events...\n");
            orderProcessor.OrderPlaced -= loggingService.OnOrderPlaced;

            // Process Order 5 - Suresh (LoggingService will NOT be notified)
            Console.WriteLine("\n🔹 Processing Order #5 (LoggingService unsubscribed)");
            orderProcessor.ProcessOrder(order5);

            // Step 6: Show summary
            Console.WriteLine("\n" + "=".PadRight(60, '='));
            Console.WriteLine("   EXECUTION SUMMARY");
            Console.WriteLine("=".PadRight(60, '='));
            Console.WriteLine("✅ All orders processed successfully!");
            Console.WriteLine("📧 NotificationService: Sends email/SMS to customers");
            Console.WriteLine("📦 InventoryService: Updates stock inventory");
            Console.WriteLine("📝 LoggingService: Writes to console and log file (unsubscribed after Order #4)");
            Console.WriteLine("\n📄 Check 'order_log.txt' for persisted log entries (Orders #1-#4 only).");

            Console.WriteLine("\n📊 Orders Processed Summary:");
            Console.WriteLine("   • Order #1001 - Rajesh    - ₹1,250.50");
            Console.WriteLine("   • Order #1002 - Priya     - ₹899.99");
            Console.WriteLine("   • Order #1003 - Amit      - ₹2,500.00");
            Console.WriteLine("   • Order #1004 - Neha      - ₹450.75");
            Console.WriteLine("   • Order #1005 - Suresh    - ₹3,200.00 (LoggingService unsubscribed)");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}