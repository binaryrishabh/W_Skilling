using _3_Events_OrderProcessingSystem.EventArgs;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Events_OrderProcessingSystem.Subscribers {
    public class LoggingService {
        private readonly string logFilePath = "order_log.txt";

        /// <summary>
        /// Event handler that logs the order to a file
        /// </summary>
        public void OnOrderPlaced(object sender, OrderPlacedEventArgs e) {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Order Placed - {e}";

            Console.WriteLine($"[LoggingService] Writing to log file...");

            // Write to console
            Console.WriteLine($"[LoggingService] {logEntry}");

            // Write to file
            File.AppendAllText(logFilePath, logEntry + System.Environment.NewLine);

            Console.WriteLine($"[LoggingService] Log entry saved to {logFilePath}");
        }
    }
}
