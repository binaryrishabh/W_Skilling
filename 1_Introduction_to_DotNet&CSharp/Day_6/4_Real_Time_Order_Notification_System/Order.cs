using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Real_Time_Order_Notification_System {
    public class Order {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public double Amount { get; set; }

        public override string ToString() {
            return $"Order #{OrderId} | Customer: {CustomerName} | Amount: ${Amount:F2}";
        }
    }
}