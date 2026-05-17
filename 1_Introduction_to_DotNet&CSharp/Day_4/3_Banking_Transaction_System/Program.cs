using _3_Banking_Transaction_System;
using System;

namespace _3_Banking_Transaction_System {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("=== BANKING TRANSACTION SYSTEM ===\n");

            TransactionProcessor processor = new TransactionProcessor();

            // Create accounts
            Console.WriteLine("--- Creating Accounts ---");
            processor.AddAccount("ACCOUNT1", "Dhoni", 1000);
            processor.AddAccount("ACCOUNT2", "Virat", 500);
            processor.AddAccount("ACCOUNT3", "Katrina", 2000);
            Console.WriteLine();

            // Show initial balances
            processor.ShowAllAccounts();
            Console.WriteLine();

            // Add pending transactions
            Console.WriteLine("--- Adding Pending Transactions ---");
            processor.AddPendingTransaction("ACCOUNT1", 500, "Deposit");
            processor.AddPendingTransaction("ACCOUNT2", 200, "Withdraw");
            processor.AddPendingTransaction("ACCOUNT1", 300, "Withdraw");
            processor.AddPendingTransaction("ACCOUNT3", 1000, "Withdraw");
            processor.AddPendingTransaction("ACCOUNT2", 100, "Deposit");
            processor.AddPendingTransaction("ACCOUNT1", 2000, "Withdraw"); // Should fail (insufficient)
            Console.WriteLine();

            // Show pending queue
            processor.ShowPendingTransactions();
            Console.WriteLine();

            // Process all pending transactions
            processor.ProcessPendingTransactions();
            Console.WriteLine();

            // Show updated balances
            processor.ShowAllAccounts();
            Console.WriteLine();

            // Show transaction history
            processor.ShowTransactionHistory();
            Console.WriteLine();

            // Test rollback functionality
            Console.WriteLine("--- Testing Rollback ---");
            processor.RollbackLastTransaction();  // Rollbacks the last processed transaction
            Console.WriteLine();

            processor.ShowAllAccounts();
            Console.WriteLine();

            processor.ShowTransactionHistory();
            Console.WriteLine();

            // Try duplicate transaction prevention (manual test)
            Console.WriteLine("--- Testing Duplicate Prevention ---");
            Console.WriteLine($"Is Transaction ID 'TEST123' unique? {processor.IsTransactionIdUnique("TEST123")}");

            Console.WriteLine("\n=== PROGRAM COMPLETED SUCCESSFULLY ===");
        }
    }
}