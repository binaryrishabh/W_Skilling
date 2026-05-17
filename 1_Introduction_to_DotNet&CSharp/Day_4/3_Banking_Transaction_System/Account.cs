using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Banking_Transaction_System {
    public class Account {
        public string AccountId { get; set; }
        public string CustomerName { get; set; }

        public Account(string accountId, string customerName) {
            AccountId = accountId;
            CustomerName = customerName;
        }

        public override string ToString() {
            return $"{CustomerName} (Account: {AccountId})";
        }
    }
}
