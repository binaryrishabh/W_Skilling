using System;
using System.Collections.Generic;
using System.Linq;

namespace _1_E_Commerce_Order_Management_System {

    // Order Manager Class
    public class OrderManager {
        private Stack<string> globalStatusHistory = new Stack<string>();
        private List<Order> orders = new List<Order>();
        private Dictionary<int, Customer> customers = new Dictionary<int, Customer>();
        private HashSet<string> categories = new HashSet<string>();
        private Queue<Order> orderQueue = new Queue<Order>();

        // Add Customer
        public void AddCustomer(Customer customer) {
            if (customers.ContainsKey(customer.CustomerId)) {
                Console.WriteLine($"Customer {customer.CustomerId} already exists. Updating name.");
                customers[customer.CustomerId] = customer;
            }
            else {
                customers[customer.CustomerId] = customer;
                Console.WriteLine($"Customer {customer.CustomerId} ({customer.Name}) added.");
            }
        }

        // Add Order
        public void AddOrder(Order order) {
            // Check if customer exists
            if (!customers.ContainsKey(order.CustomerId)) {
                Console.WriteLine($"Error: Customer ID {order.CustomerId} not found. Order {order.OrderId} not added.");
                return;
            }

            // Check for duplicate OrderId
            if (orders.Any(o => o.OrderId == order.OrderId)) {
                Console.WriteLine($"Error: Order ID {order.OrderId} already exists. Order not added.");
                return;
            }

            orders.Add(order);
            orderQueue.Enqueue(order);
            categories.Add(order.Category);
            Console.WriteLine($"Order {order.OrderId} added successfully for customer {customers[order.CustomerId].Name}.");
        }

        // Update Order Status
        public void UpdateOrder(int orderId, string newStatus) {
            Order order = orders.Find(o => o.OrderId == orderId);

            if (order != null) {
                string oldStatus = order.GetCurrentStatus();
                order.UpdateStatus(newStatus);
                string historyEntry = $"Order {orderId}: {oldStatus} → {newStatus} at {DateTime.Now:HH:mm:ss}";
                globalStatusHistory.Push(historyEntry);
                Console.WriteLine($"✓ Order {orderId} updated: {oldStatus} → {newStatus}");
            }
            else {
                Console.WriteLine($"Error: Order {orderId} not found.");
            }
        }

        // Remove Order
        public void RemoveOrder(int orderId) {
            Order order = orders.Find(o => o.OrderId == orderId);

            if (order != null) {
                orders.Remove(order);

                // Also remove from queue if present (optional but cleaner)
                orderQueue = new Queue<Order>(orderQueue.Where(o => o.OrderId != orderId));

                Console.WriteLine($"✓ Order {orderId} removed from system.");

                // Note: Order remains in queue if not processed yet
                // In a real system, you might want to handle this differently
            }
            else {
                Console.WriteLine($"Error: Order {orderId} not found.");
            }
        }

        // Process Orders (FIFO)
        public void ProcessOrders() {
            Console.WriteLine("\n--- Processing Orders (FIFO) ---");

            if (orderQueue.Count == 0) {
                Console.WriteLine("No pending orders to process.");
                return;
            }

            while (orderQueue.Count > 0) {
                Order order = orderQueue.Dequeue();
                Console.WriteLine($"Processing Order {order.OrderId} (Product: {order.ProductName}, Customer ID: {order.CustomerId})");
                order.UpdateStatus("Processed");
                globalStatusHistory.Push($"Order {order.OrderId}: Processed at {DateTime.Now:HH:mm:ss}");
            }
            Console.WriteLine("All pending orders processed.\n");
        }

        // Show pending orders in queue
        public void ShowPendingOrders() {
            Console.WriteLine("\n--- Pending Orders in Queue ---");
            if (orderQueue.Count == 0) {
                Console.WriteLine("No pending orders.");
            }
            else {
                Console.WriteLine($"Total pending orders: {orderQueue.Count}");
                foreach (Order order in orderQueue) {
                    Console.WriteLine($"  Order {order.OrderId}: {order.ProductName} (Status: {order.GetCurrentStatus()})");
                }
            }
            Console.WriteLine();
        }

        // Display Orders
        public void DisplayOrders() {
            Console.WriteLine("\n--- All Orders ---");
            if (orders.Count == 0) {
                Console.WriteLine("No orders found.");
            }
            else {
                foreach (var order in orders) {
                    if (customers.ContainsKey(order.CustomerId)) {
                        var customer = customers[order.CustomerId];
                        Console.WriteLine($"OrderID: {order.OrderId}, Customer: {customer.Name}, Product: {order.ProductName}, Price: ₹{order.Price}, Status: {order.GetCurrentStatus()}, Category: {order.Category}");
                    }
                    else {
                        Console.WriteLine($"OrderID: {order.OrderId}, Customer ID: {order.CustomerId} (NOT FOUND), Product: {order.ProductName}, Price: ₹{order.Price}, Status: {order.GetCurrentStatus()}, Category: {order.Category}");
                    }
                }
            }

            Console.WriteLine("\n--- Unique Product Categories ({0} total) ---", categories.Count);
            if (categories.Count == 0) {
                Console.WriteLine("No categories found.");
            }
            else {
                foreach (var cat in categories) {
                    Console.WriteLine($"  • {cat}");
                }
            }
            Console.WriteLine();
        }

        // Show global status history (LIFO)
        public void ShowGlobalHistory() {
            Console.WriteLine("\n--- Global Order Status History (Latest First) ---");
            if (globalStatusHistory.Count == 0) {
                Console.WriteLine("No status changes recorded.");
            }
            else {
                int count = 1;
                foreach (var entry in globalStatusHistory) {
                    Console.WriteLine($"{count}. {entry}");
                    count++;
                }
            }
            Console.WriteLine();
        }

        // Optional: Get order by ID
        public Order GetOrderById(int orderId) {
            return orders.Find(o => o.OrderId == orderId);
        }

        // Optional: Get customer by ID
        public Customer GetCustomerById(int customerId) {
            return customers.ContainsKey(customerId) ? customers[customerId] : null;
        }
    }
}