using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Real_Time_Order_Notification_System.Services {
    public class LoggerService {
        public void LogOrder(Order order) {
            string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Order Processed - ID: {order.OrderId}, Customer: {order.CustomerName}, Amount: ${order.Amount:F2}";
            Console.WriteLine($"[LoggerService] 📝 {logMessage}");

            // Simulate writing to log file
            System.IO.File.AppendAllText("order_log.txt", logMessage + Environment.NewLine);
        }
    }
}