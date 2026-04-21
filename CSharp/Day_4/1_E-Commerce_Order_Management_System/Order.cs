using System;
using System.Collections.Generic;
using System.Text;

namespace _1_E_Commerce_Order_Management_System {

    // Order Class
    public class Order {
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
}
