using _7_Financial_Transaction_System;
using System;

namespace _7_Financial_Transaction_System {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("=== Financial Transaction System ===\n");

            // Take customer name as input
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();

            // Take initial balance as input
            Console.Write("Enter initial balance (₹): ");
            decimal balance = decimal.Parse(Console.ReadLine());

            Console.WriteLine($"\nWelcome, {customerName}!");
            Console.WriteLine($"Initial balance: ₹{balance}\n");

            TransactionProcessor processor = new TransactionProcessor();

            // Multiple transactions
            for (int i = 1; i <= 3; i++) {
                Console.WriteLine($"--- Transaction {i} ---");

                Console.Write($"Enter amount to withdraw (₹): ");
                decimal amount = decimal.Parse(Console.ReadLine());

                string status;
                bool success = processor.PerformExchange(ref balance, amount, out status);

                Console.WriteLine($"Result: {status}");
                Console.WriteLine($"Current balance: ₹{balance}\n");
            }

            // Final transaction using helper class
            Console.WriteLine("--- Final Transaction ---");
            Console.Write("Enter final withdrawal amount (₹): ");
            decimal finalAmount = decimal.Parse(Console.ReadLine());

            string finalStatus;
            bool finalSuccess = processor.PerformExchange(ref balance, finalAmount, out finalStatus);
            TransactionResult result = new TransactionResult(finalSuccess, finalStatus);
            result.Display();
            Console.WriteLine($"Final balance: ₹{balance}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}