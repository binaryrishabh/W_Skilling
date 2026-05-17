using _8_Async_Await_Data_Dashboard;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _8_Async_Await_Data_Dashboard {
    class Program {
        static async Task Main(string[] args) {
            Console.WriteLine("=== ASYNC/AWAIT DASHBOARD DEMO ===\n");

            // Take Indian first names as input
            Console.WriteLine("Enter Indian first names (comma-separated):");
            Console.Write("Example: Raj, Priya, Amit, Neha, Vikram\n\n➜ ");

            string input = Console.ReadLine();
            List<string> names = new List<string>();

            if (!string.IsNullOrWhiteSpace(input)) {
                string[] nameArray = input.Split(',');
                foreach (string name in nameArray) {
                    names.Add(name.Trim());
                }
            }

            // Default names if user enters nothing
            if (names.Count == 0) {
                names = new List<string> { "Arjun", "Kavya", "Rohan", "Sneha", "Dhruv" };
                Console.WriteLine($"\n⚠️ No input. Using defaults: {string.Join(", ", names)}");
            }

            Console.WriteLine($"\n✅ Names to process: {string.Join(", ", names)}");

            var dashboard = new Dashboard();
            dashboard.ShowResponsiveUI();

            Console.WriteLine("⏰ Starting API call at: " + DateTime.Now.ToString("HH:mm:ss"));

            Task loadTask = dashboard.LoadAndDisplayDataAsync(names);

            // Simulate UI doing other work while waiting
            for (int i = 1; i <= 3; i++) {
                await Task.Delay(500);
                Console.WriteLine($"🔄 Background Task {i} - Dashboard still interactive...");
            }

            await loadTask;

            Console.WriteLine("\n⏰ Completed at: " + DateTime.Now.ToString("HH:mm:ss"));
            Console.WriteLine("\n✨ Dashboard ready! (Non-blocking demo successful)");
        }
    }
}