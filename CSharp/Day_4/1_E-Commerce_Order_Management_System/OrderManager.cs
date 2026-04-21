using System;
using System.Collections.Generic;
using System.Text;

namespace _1_E_Commerce_Order_Management_System {

    // Order Manager Class
    public class OrderManager {
        private List<Order> orders = new List<Order>();
        private Dictionary<int, Customer> customers = new Dictionary<int, Customer>();
        private HashSet<string> categories = new HashSet<string>();
        private Queue<Order> orderQueue = new Queue<Order>();

        // Add Customer
        public void AddCustomer(Customer customer) {
            customers[customer.CustomerId] = customer;
        }

        // Add Order
        public void AddOrder(Order order) {
            orders.Add(order);
            orderQueue.Enqueue(order);
            categories.Add(order.Category);

            Console.WriteLine($"Order {order.OrderId} added.");
        }

        // Update Order Status
        public void UpdateOrder(int orderId, string newStatus) {
            Order order = orders.Find(o => o.OrderId == orderId);

            if (order != null) {
                order.UpdateStatus(newStatus);
                Console.WriteLine($"Order {orderId} updated to {newStatus}");
            }
        }

        // Remove Order
        public void RemoveOrder(int orderId) {
            Order order = orders.Find(o => o.OrderId == orderId);

            if (order != null) {
                orders.Remove(order);
                Console.WriteLine($"Order {orderId} removed.");
            }
        }

        // Process Orders (FIFO)
        public void ProcessOrders() {
            Console.WriteLine("\nProcessing Orders:");

            while (orderQueue.Count > 0) {
                Order order = orderQueue.Dequeue();
                Console.WriteLine($"Processing Order {order.OrderId}");
                order.UpdateStatus("Processed");
            }
        }

        // Display Orders
        public void DisplayOrders() {
            Console.WriteLine("\nAll Orders:");

            foreach (var order in orders) {
                Console.WriteLine($"OrderID: {order.OrderId}, CustomerID: {order.CustomerId}, Category: {order.Category}, Current Status: {order.GetCurrentStatus()}");
            }

            Console.WriteLine("\nUnique Categories:");
            foreach (var cat in categories) {
                Console.WriteLine(cat);
            }
        }
    }
}
