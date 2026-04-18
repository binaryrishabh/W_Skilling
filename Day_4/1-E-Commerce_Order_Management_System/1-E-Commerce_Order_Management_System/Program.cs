using System;
using System.Collections.Generic;

namespace EcommerceOrderManagement {
    class Program {
        static void Main(string[] args) {
            OrderManager manager = new OrderManager();

            // Adding Customers
            manager.AddCustomer(new Customer(1, "Rishabh"));
            manager.AddCustomer(new Customer(2, "Glory"));

            // Adding Orders
            manager.AddOrder(new Order(101, 1, "Electronics"));
            manager.AddOrder(new Order(102, 2, "Clothing"));
            manager.AddOrder(new Order(103, 1, "Electronics")); // duplicate category (handled by HashSet)

            // Update Order
            manager.UpdateOrder(101, "Shipped");

            // Process Orders
            manager.ProcessOrders();

            // Remove Order
            manager.RemoveOrder(102);

            // Show All Orders
            manager.DisplayOrders();
        }
    }

    // Customer Class
    class Customer {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public Customer(int id, string name) {
            CustomerId = id;
            Name = name;
        }
    }

    // Order Class
    class Order {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string Category { get; set; }

        public Stack<string> StatusHistory { get; set; }

        public Order(int orderId, int customerId, string category) {
            OrderId = orderId;
            CustomerId = customerId;
            Category = category;
            StatusHistory = new Stack<string>();
            StatusHistory.Push("Created");
        }

        public void UpdateStatus(string status) {
            StatusHistory.Push(status);
        }

        public string GetCurrentStatus() {
            return StatusHistory.Peek();
        }
    }

    // Order Manager Class
    class OrderManager {
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