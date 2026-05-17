using System;
using System.Collections.Generic;

namespace _1_E_Commerce_Order_Management_System {

    // Order Class
    public class Order {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }

        private Stack<string> StatusHistory = new Stack<string>();

        public Order(int orderId, int customerId, string productName, double price, string category) {
            OrderId = orderId;
            CustomerId = customerId;
            ProductName = productName;
            Price = price;
            Category = category;
            StatusHistory = new Stack<string>();
            StatusHistory.Push("Created");
        }

        public void UpdateStatus(string status) {
            StatusHistory.Push(status);
        }

        public string GetCurrentStatus() {
            return StatusHistory.Count > 0 ? StatusHistory.Peek() : "Unknown";
        }

        public void ShowFullStatusHistory() {
            Console.WriteLine($"\nStatus history for Order {OrderId}:");
            foreach (var status in StatusHistory) {
                Console.WriteLine($"  ← {status}");
            }
        }
    }
}