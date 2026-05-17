using System;
using _4_Real_Time_Order_Notification_System.Services;

namespace _4_Real_Time_Order_Notification_System {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("===============================================");
            Console.WriteLine("  REAL-TIME ORDER NOTIFICATION SYSTEM");
            Console.WriteLine("===============================================");

            // Create processor and services
            OrderProcessor processor = new OrderProcessor();
            EmailService emailService = new EmailService();
            SMSService smsService = new SMSService();
            LoggerService loggerService = new LoggerService();

            // ========== DEMONSTRATION 1: Subscribing all services ==========
            Console.WriteLine("\n\n--- PART 1: All Services Subscribed ---");

            // Subscribe to event (Multicast Delegate)
            processor.OnOrderPlaced += emailService.SendEmail;
            processor.OnOrderPlaced += smsService.SendSMS;
            processor.OnOrderPlaced += loggerService.LogOrder;

            Console.WriteLine($"Active subscribers: {processor.GetSubscriberCount()}");

            // Process first order
            Order order1 = new Order
            {
                OrderId = 101,
                CustomerName = "Ritik",
                Amount = 250.75
            };
            processor.ProcessOrder(order1);

            // ========== DEMONSTRATION 2: Dynamic Unsubscription ==========
            Console.WriteLine("\n\n--- PART 2: After Removing SMS Service ---");

            // Unsubscribe SMS service dynamically
            processor.OnOrderPlaced -= smsService.SendSMS;
            Console.WriteLine($"Active subscribers: {processor.GetSubscriberCount()}");

            // Process second order
            Order order2 = new Order
            {
                OrderId = 102,
                CustomerName = "Rinki",
                Amount = 499.99
            };
            processor.ProcessOrder(order2);

            // ========== DEMONSTRATION 3: Using Action<> Delegate (Bonus) ==========
            Console.WriteLine("\n\n--- PART 3: Using Action<> Delegate (Bonus Feature) ---");

            // Alternative way using built-in Action delegate
            Action<Order> actionNotification = null;
            actionNotification += emailService.SendEmail;
            actionNotification += loggerService.LogOrder;

            Console.WriteLine("Using Action<> delegate to send notifications:");
            Order order3 = new Order
            {
                OrderId = 103,
                CustomerName = "Rahul",
                Amount = 899.99
            };
            actionNotification?.Invoke(order3);

            // ========== DEMONSTRATION 4: Resubscribing ==========
            Console.WriteLine("\n\n--- PART 4: Resubscribed SMS Service ---");

            // Resubscribe SMS
            processor.OnOrderPlaced += smsService.SendSMS;
            Console.WriteLine($"Active subscribers: {processor.GetSubscriberCount()}");

            Order order4 = new Order
            {
                OrderId = 104,
                CustomerName = "Alish",
                Amount = 150.00
            };
            processor.ProcessOrder(order4);

            // ========== DEMONSTRATION 5: Null-safe invocation test ==========
            Console.WriteLine("\n\n--- PART 5: New Processor with No Subscribers ---");

            OrderProcessor emptyProcessor = new OrderProcessor();
            Console.WriteLine($"Active subscribers: {emptyProcessor.GetSubscriberCount()}");

            Order order5 = new Order
            {
                OrderId = 105,
                CustomerName = "Ronty",
                Amount = 1.00
            };
            emptyProcessor.ProcessOrder(order5); // Will show warning, not crash

            Console.WriteLine("\n===============================================");
            Console.WriteLine("  PRESS ANY KEY TO EXIT");
            Console.WriteLine("===============================================");
            Console.ReadKey();
        }
    }
}