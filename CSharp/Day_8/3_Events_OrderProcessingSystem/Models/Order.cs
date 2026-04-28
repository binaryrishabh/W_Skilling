using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Events_OrderProcessingSystem.Models {
    public class Order {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsConfirmed { get; set; }

        public Order(int orderId, string customerName, decimal totalAmount) {
            OrderId = orderId;
            CustomerName = customerName;
            TotalAmount = totalAmount;
            OrderDate = DateTime.Now;
            IsConfirmed = false;
        }

        public override string ToString() {
            return $"Order ID: {OrderId}, Customer: {CustomerName}, Amount: ${TotalAmount}";
        }
    }
}
