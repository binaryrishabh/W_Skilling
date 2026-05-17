using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Real_Time_Order_Notification_System.Services {
    public class EmailService {
        public void SendEmail(Order order) {
            Console.WriteLine($"[EmailService] 📧 Email sent to {order.CustomerName}@example.com");
            Console.WriteLine($"              Subject: Order Confirmation - #{order.OrderId}");
            Console.WriteLine($"              Body: Thank you for your order of ${order.Amount:F2}");
        }
    }
}
