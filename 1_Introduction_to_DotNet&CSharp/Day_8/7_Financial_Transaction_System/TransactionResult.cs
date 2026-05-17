using System;
using System.Collections.Generic;
using System.Text;

namespace _7_Financial_Transaction_System {
    // Optional helper class for cleaner output
    public class TransactionResult {
        public bool IsSuccess { get; set; }
        public string Status { get; set; }

        public TransactionResult(bool isSuccess, string status) {
            IsSuccess = isSuccess;
            Status = status;
        }

        public void Display() {
            Console.WriteLine(IsSuccess ? $"✓ {Status}" : $"✗ {Status}");
        }
    }
}