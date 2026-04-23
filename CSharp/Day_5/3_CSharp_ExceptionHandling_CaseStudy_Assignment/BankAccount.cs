using System;

namespace _3_CSharp_ExceptionHandling_CaseStudy_Assignment {
    public class BankAccount {
        // Properties
        public string AccountHolderName { get; set; }
        private double _balance;

        // Minimum balance requirement as per business rule
        private const double MINIMUM_BALANCE = 1000;

        // Balance property with validation
        public double Balance {
            get { return _balance; }
            private set { _balance = value; }
        }

        // Constructor
        public BankAccount(string accountHolderName, double initialBalance) {
            AccountHolderName = accountHolderName;

            if (initialBalance < MINIMUM_BALANCE) {
                throw new InsufficientBalanceException(
                    $"Initial balance must be at least {MINIMUM_BALANCE}. Provided: {initialBalance}");
            }

            _balance = initialBalance;
        }

        // Deposit Method
        public void Deposit(double amount) {
            // Check if amount is valid
            if (amount <= 0) {
                throw new InvalidAmountException(
                    $"Deposit amount must be greater than 0. Provided: {amount}");
            }

            // Perform deposit
            _balance += amount;
            Console.WriteLine($"Successfully deposited: ${amount}");
            Console.WriteLine($"New balance: ${_balance}");
        }

        // Withdraw Method
        public void Withdraw(double amount) {
            // Check if amount is valid
            if (amount <= 0) {
                throw new InvalidAmountException(
                    $"Withdrawal amount must be greater than 0. Provided: {amount}");
            }

            // Check if sufficient balance is available
            if (amount > _balance) {
                throw new InsufficientBalanceException(
                    $"Insufficient balance! Available: ${_balance}, Requested: ${amount}");
            }

            // Check if minimum balance will be maintained after withdrawal
            double balanceAfterWithdrawal = _balance - amount;
            if (balanceAfterWithdrawal < MINIMUM_BALANCE) {
                throw new InsufficientBalanceException(
                    $"Cannot withdraw! Minimum balance of ${MINIMUM_BALANCE} must be maintained.\n" +
                    $"Current balance: ${_balance}, After withdrawal: ${balanceAfterWithdrawal}");
            }

            // Perform withdrawal
            _balance -= amount;
            Console.WriteLine($"Successfully withdrew: ${amount}");
            Console.WriteLine($"New balance: ${_balance}");
        }

        // Check Balance Method
        public void CheckBalance() {
            Console.WriteLine($"\n--- Account Details ---");
            Console.WriteLine($"Account Holder: {AccountHolderName}");
            Console.WriteLine($"Current Balance: ${_balance}");
            Console.WriteLine($"Minimum Required Balance: ${MINIMUM_BALANCE}");
            Console.WriteLine($"Status: {(_balance >= MINIMUM_BALANCE ? "Good Standing" : "Below Minimum")}");
        }
    }
}