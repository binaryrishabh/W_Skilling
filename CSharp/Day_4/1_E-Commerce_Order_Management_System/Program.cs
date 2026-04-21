using System;
using System.Collections.Generic;

namespace _1_E_Commerce_Order_Management_System {
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
}