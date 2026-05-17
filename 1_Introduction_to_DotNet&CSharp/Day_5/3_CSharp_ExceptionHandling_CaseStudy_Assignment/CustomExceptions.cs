using System;

namespace _3_CSharp_ExceptionHandling_CaseStudy_Assignment {
    // Custom Exception 1: InsufficientBalanceException
    public class InsufficientBalanceException : Exception {
        public InsufficientBalanceException() : base() { }

        public InsufficientBalanceException(string message) : base(message) { }

        public InsufficientBalanceException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    // Custom Exception 2: InvalidAmountException
    public class InvalidAmountException : Exception {
        public InvalidAmountException() : base() { }

        public InvalidAmountException(string message) : base(message) { }

        public InvalidAmountException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}