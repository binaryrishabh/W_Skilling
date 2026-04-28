
using _3_Events_OrderProcessingSystem.EventArgs;
using _3_Events_OrderProcessingSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Events_OrderProcessingSystem.Publisher {
    // Define the delegate for the event
    public delegate void OrderPlacedEventHandler(object sender, OrderPlacedEventArgs e);

    public class OrderProcessor {
        // Declare the event using the delegate
        public event OrderPlacedEventHandler OrderPlaced;

        // Alternative: Use the built-in EventHandler<T> (simpler)
        // public event EventHandler<OrderPlacedEventArgs> OrderPlaced;

        /// <summary>
        /// Method to process and confirm an order
        /// </summary>
        public void ProcessOrder(Order order) {
            Console.WriteLine($"\n[OrderProcessor] Processing {order}...");

            // Simulate some processing logic
            System.Threading.Thread.Sleep(1000);

            // Confirm the order
            order.IsConfirmed = true;

            Console.WriteLine($"[OrderProcessor] Order #{order.OrderId} confirmed successfully!");

            // Raise the event
            OnOrderPlaced(new OrderPlacedEventArgs(order.OrderId, order.CustomerName, order.TotalAmount));
        }

        /// <summary>
        /// Protected method to raise the event (standard pattern)
        /// </summary>
        protected virtual void OnOrderPlaced(OrderPlacedEventArgs e) {
            // Make a temporary copy of the event to avoid race condition
            OrderPlacedEventHandler handler = OrderPlaced;

            if (handler != null) {
                Console.WriteLine($"\n[OrderProcessor] Raising OrderPlaced event...");
                handler(this, e);
            }
        }
    }
}