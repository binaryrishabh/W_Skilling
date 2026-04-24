using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Real_Time_Order_Notification_System {
    // Delegate declaration for order processing
    public delegate void OrderPlacedHandler(Order order);

    public class OrderProcessor {
        // Event declaration using the delegate
        public event OrderPlacedHandler OnOrderPlaced;

        // Method to process an order and trigger the event
        public void ProcessOrder(Order order) {
            if (order == null) {
                throw new ArgumentNullException(nameof(order), "Order cannot be null");
            }

            Console.WriteLine($"\n[OrderProcessor] Processing {order}");

            // Trigger the event (null-safe invocation with exception handling)
            if (OnOrderPlaced != null) {
                foreach (OrderPlacedHandler handler in OnOrderPlaced.GetInvocationList()) {
                    try {
                        handler.Invoke(order);
                    }
                    catch (Exception ex) {
                        Console.WriteLine($"[ERROR] Handler failed: {ex.Message}");
                    }
                }
            }
            else {
                Console.WriteLine("[WARNING] No subscribers attached to OnOrderPlaced event");
            }
        }

        // Method to get current subscriber count (for demo purposes)
        public int GetSubscriberCount() {
            return OnOrderPlaced?.GetInvocationList().Length ?? 0;
        }
    }
}