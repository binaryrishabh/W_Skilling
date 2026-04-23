using System;

namespace _1_E_Commerce_Order_Management_System {
    class Program {
        static void Main(string[] args) {
            OrderManager manager = new OrderManager();

            // Adding Customers
            manager.AddCustomer(new Customer(1, "Rishabh"));
            manager.AddCustomer(new Customer(2, "Glory"));

            // Adding Orders (will fail if customer doesn't exist)
            manager.AddOrder(new Order(101, 1, "Laptop", 75000, "Electronics"));
            manager.AddOrder(new Order(102, 2, "T-Shirt", 999, "Clothing"));
            manager.AddOrder(new Order(103, 1, "Mouse", 1500, "Electronics")); // duplicate category "Electronics" (handled by HashSet)
            manager.AddOrder(new Order(104, 99, "Test", 100, "Test")); // This will fail - customer not found

            // Show pending orders in queue
            manager.ShowPendingOrders();

            // Update Order Status
            manager.UpdateOrder(101, "Shipped");
            manager.UpdateOrder(102, "Packed");

            // Process Orders (FIFO)
            manager.ProcessOrders();

            // Try to process again (queue should be empty)
            manager.ProcessOrders();

            // Remove Order
            manager.RemoveOrder(103);

            // Show All Orders & Unique Categories
            manager.DisplayOrders();

            // Show global status history
            manager.ShowGlobalHistory();
        }
    }
}