using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Banking_Transaction_System {
    public class TransactionProcessor {
        // List<Transaction> for transaction history
        private List<Transaction> _transactionHistory;

        // Dictionary<string, double> for account balances
        private Dictionary<string, double> _accountBalances;

        // Queue<Transaction> for pending transactions
        private Queue<Transaction> _pendingTransactions;

        // Stack<Transaction> for rollback operations
        private Stack<Transaction> _rollbackStack;

        // HashSet<string> to ensure unique transaction IDs
        private HashSet<string> _uniqueTransactionIds;

        public TransactionProcessor() {
            _transactionHistory = new List<Transaction>();
            _accountBalances = new Dictionary<string, double>();
            _pendingTransactions = new Queue<Transaction>();
            _rollbackStack = new Stack<Transaction>();
            _uniqueTransactionIds = new HashSet<string>();
        }

        // Add a new account
        public void AddAccount(string accountId, string customerName, double initialBalance = 0) {
            if (_accountBalances.ContainsKey(accountId)) {
                Console.WriteLine($"❌ Account {accountId} already exists!");
                return;
            }

            _accountBalances[accountId] = initialBalance;
            Console.WriteLine($"✅ Account created: {customerName} ({accountId}) with balance ${initialBalance}");
        }

        // Create and add a pending transaction
        public void AddPendingTransaction(string accountId, double amount, string type) {
            if (!_accountBalances.ContainsKey(accountId)) {
                Console.WriteLine($"❌ Account {accountId} does not exist!");
                return;
            }

            if (type != "Deposit" && type != "Withdraw") {
                Console.WriteLine($"❌ Invalid transaction type! Use 'Deposit' or 'Withdraw'");
                return;
            }

            if (type == "Withdraw" && _accountBalances[accountId] < amount) {
                Console.WriteLine($"❌ Insufficient balance in account {accountId}!");
                return;
            }

            Transaction transaction = new Transaction(amount, type, accountId);

            // Ensure unique transaction ID
            if (_uniqueTransactionIds.Contains(transaction.TransactionId)) {
                Console.WriteLine($"❌ Duplicate transaction ID detected!");
                return;
            }

            _uniqueTransactionIds.Add(transaction.TransactionId);
            _pendingTransactions.Enqueue(transaction);
            Console.WriteLine($"📝 Pending {type} of ${amount} added for account {accountId}");
        }

        // Process all pending transactions (FIFO)
        public void ProcessPendingTransactions() {
            Console.WriteLine("\n--- Processing Pending Transactions ---");

            if (_pendingTransactions.Count == 0) {
                Console.WriteLine("No pending transactions to process.");
                return;
            }

            while (_pendingTransactions.Count > 0) {
                Transaction transaction = _pendingTransactions.Dequeue();
                ProcessTransaction(transaction);
            }
        }

        // Process a single transaction
        private void ProcessTransaction(Transaction transaction) {
            double currentBalance = _accountBalances[transaction.AccountId];

            if (transaction.Type == "Deposit") {
                _accountBalances[transaction.AccountId] += transaction.Amount;
                _transactionHistory.Add(transaction);
                _rollbackStack.Push(transaction);
                Console.WriteLine($"✅ Processed: {transaction}");
                Console.WriteLine($"   New balance: ${_accountBalances[transaction.AccountId]}");
            }
            else if (transaction.Type == "Withdraw") {
                if (currentBalance >= transaction.Amount) {
                    _accountBalances[transaction.AccountId] -= transaction.Amount;
                    _transactionHistory.Add(transaction);
                    _rollbackStack.Push(transaction);
                    Console.WriteLine($"✅ Processed: {transaction}");
                    Console.WriteLine($"   New balance: ${_accountBalances[transaction.AccountId]}");
                }
                else {
                    Console.WriteLine($"❌ Failed: Insufficient funds for {transaction}");
                }
            }
        }

        // Rollback last transaction (LIFO)
        public void RollbackLastTransaction() {
            Console.WriteLine("\n--- Rolling Back Last Transaction ---");

            if (_rollbackStack.Count == 0) {
                Console.WriteLine("No transactions to rollback.");
                return;
            }

            Transaction lastTransaction = _rollbackStack.Pop();

            if (lastTransaction.Type == "Deposit") {
                _accountBalances[lastTransaction.AccountId] -= lastTransaction.Amount;
                Console.WriteLine($"↩️ Rollback: Reversed {lastTransaction}");
                Console.WriteLine($"   New balance: ${_accountBalances[lastTransaction.AccountId]}");
            }
            else if (lastTransaction.Type == "Withdraw") {
                _accountBalances[lastTransaction.AccountId] += lastTransaction.Amount;
                Console.WriteLine($"↩️ Rollback: Reversed {lastTransaction}");
                Console.WriteLine($"   New balance: ${_accountBalances[lastTransaction.AccountId]}");
            }

            // Remove from history (optional - keeping for audit trail is better)
            _transactionHistory.Remove(lastTransaction);
        }

        // Show account balance
        public void ShowBalance(string accountId) {
            if (_accountBalances.ContainsKey(accountId)) {
                Console.WriteLine($"💰 Balance for account {accountId}: ${_accountBalances[accountId]}");
            }
            else {
                Console.WriteLine($"❌ Account {accountId} not found!");
            }
        }

        // Show transaction history
        public void ShowTransactionHistory() {
            Console.WriteLine("\n--- Transaction History ---");
            if (_transactionHistory.Count == 0) {
                Console.WriteLine("No transactions yet.");
                return;
            }

            foreach (var transaction in _transactionHistory) {
                Console.WriteLine(transaction);
            }
        }

        // Show all accounts
        public void ShowAllAccounts() {
            Console.WriteLine("\n--- All Accounts ---");
            if (_accountBalances.Count == 0) {
                Console.WriteLine("No accounts found.");
                return;
            }

            foreach (var account in _accountBalances) {
                Console.WriteLine($"Account: {account.Key} | Balance: ${account.Value}");
            }
        }

        // Show pending transactions
        public void ShowPendingTransactions() {
            Console.WriteLine("\n--- Pending Transactions ---");
            if (_pendingTransactions.Count == 0) {
                Console.WriteLine("No pending transactions.");
                return;
            }

            foreach (var transaction in _pendingTransactions) {
                Console.WriteLine(transaction);
            }
        }

        // Check if transaction ID is unique
        public bool IsTransactionIdUnique(string transactionId) {
            return !_uniqueTransactionIds.Contains(transactionId);
        }
    }
}