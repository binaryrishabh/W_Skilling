using System;
using System.Collections.Generic;
using System.Text;

namespace _7_Financial_Transaction_System {
    public class TransactionProcessor {
        /// <summary>
        /// Performs exchange/transaction on balance
        /// </summary>
        /// <param name="balance">Current balance (passed by ref)</param>
        /// <param name="amount">Amount to deduct</param>
        /// <param name="status">Transaction status (returned via out)</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool PerformExchange(ref decimal balance, decimal amount, out string status) {
            // Validate amount
            if (amount <= 0) {
                status = "Failed: Amount must be greater than zero";
                return false;
            }

            // Check sufficient balance
            if (balance < amount) {
                status = $"Failed: Insufficient balance. Available: ₹{balance}, Required: ₹{amount}";
                return false;
            }

            // Update balance directly using ref
            balance -= amount;

            // Set success status using out
            status = $"Success: ₹{amount} deducted. New balance: ₹{balance}";
            return true;
        }
    }
}