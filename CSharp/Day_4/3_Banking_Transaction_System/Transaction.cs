using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Banking_Transaction_System {
    public class Transaction {
        public string TransactionId { get; set; }
        public double Amount { get; set; }
        public DateTime Timestamp { get; set; }
        public string Type { get; set; } // "Deposit" or "Withdraw"
        public string AccountId { get; set; }

        public Transaction() {
            TransactionId = Guid.NewGuid().ToString().Substring(0, 8);
            Timestamp = DateTime.Now;
        }

        public Transaction(double amount, string type, string accountId) : this() {
            Amount = amount;
            Type = type;
            AccountId = accountId;
        }

        public override string ToString() {
            return $"[{Timestamp:HH:mm:ss}] {Type} of ${Amount} on Account {AccountId} | ID: {TransactionId}";
        }
    }
}
