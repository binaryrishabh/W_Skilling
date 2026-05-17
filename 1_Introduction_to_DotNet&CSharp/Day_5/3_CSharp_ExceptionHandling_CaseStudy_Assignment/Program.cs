using _3_CSharp_ExceptionHandling_CaseStudy_Assignment;
using System;

namespace _3_CSharp_ExceptionHandling_CaseStudy_Assignment {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("=".PadRight(50, '='));
            Console.WriteLine("  BANKING TRANSACTION SYSTEM");
            Console.WriteLine("  with Exception Handling");
            Console.WriteLine("=".PadRight(50, '='));
            Console.WriteLine();

            BankAccount account = null;

            try {
                // Get account holder name
                Console.Write("Enter Account Holder Name: ");
                string name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name)) {
                    throw new ArgumentException("Account holder name cannot be empty!");
                }

                // Get initial balance
                Console.Write("Enter Initial Balance (Minimum $1000): $");
                if (!double.TryParse(Console.ReadLine(), out double initialBalance)) {
                    throw new ArgumentException("Invalid amount format! Please enter a valid number.");
                }

                // Create bank account
                account = new BankAccount(name, initialBalance);
                Console.WriteLine($"\n✓ Account created successfully for {name}!");
                account.CheckBalance();

                // Menu driven program
                bool exit = false;
                while (!exit) {
                    Console.WriteLine("\n" + "-".PadRight(40, '-'));
                    Console.WriteLine("MENU:");
                    Console.WriteLine("1. Deposit Money");
                    Console.WriteLine("2. Withdraw Money");
                    Console.WriteLine("3. Check Balance");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter your choice (1-4): ");

                    string choice = Console.ReadLine();

                    switch (choice) {
                        case "1":
                            PerformDeposit(account);
                            break;
                        case "2":
                            PerformWithdrawal(account);
                            break;
                        case "3":
                            account.CheckBalance();
                            break;
                        case "4":
                            exit = true;
                            Console.WriteLine("\nThank you for using our banking system!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice! Please enter 1, 2, 3, or 4.");
                            break;
                    }
                }
            }
            catch (ArgumentException ex) {
                Console.WriteLine($"\n[INPUT ERROR] {ex.Message}");
            }
            catch (InsufficientBalanceException ex) {
                Console.WriteLine($"\n[BALANCE ERROR] {ex.Message}");
            }
            catch (InvalidAmountException ex) {
                Console.WriteLine($"\n[AMOUNT ERROR] {ex.Message}");
            }
            catch (Exception ex) {
                Console.WriteLine($"\n[UNEXPECTED ERROR] {ex.Message}");
                Console.WriteLine("Please contact support.");
            }
            finally {
                Console.WriteLine("\n" + "=".PadRight(50, '='));
                Console.WriteLine("Transaction session ended.");
                Console.WriteLine("Finally block executed - Cleanup completed.");
                Console.WriteLine("=".PadRight(50, '='));
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void PerformDeposit(BankAccount account) {
            try {
                Console.Write("Enter amount to deposit: $");
                if (!double.TryParse(Console.ReadLine(), out double amount)) {
                    throw new ArgumentException("Invalid amount format!");
                }
                account.Deposit(amount);
            }
            catch (InvalidAmountException ex) {
                Console.WriteLine($"\n[ERROR] {ex.Message}");
            }
            catch (ArgumentException ex) {
                Console.WriteLine($"\n[ERROR] {ex.Message}");
            }
            finally {
                Console.WriteLine("Deposit operation completed.");
            }
        }

        static void PerformWithdrawal(BankAccount account) {
            try {
                Console.Write("Enter amount to withdraw: $");
                if (!double.TryParse(Console.ReadLine(), out double amount)) {
                    throw new ArgumentException("Invalid amount format!");
                }
                account.Withdraw(amount);
            }
            catch (InvalidAmountException ex) {
                Console.WriteLine($"\n[ERROR] {ex.Message}");
            }
            catch (InsufficientBalanceException ex) {
                Console.WriteLine($"\n[ERROR] {ex.Message}");
            }
            catch (ArgumentException ex) {
                Console.WriteLine($"\n[ERROR] {ex.Message}");
            }
            finally {
                Console.WriteLine("Withdrawal operation completed.");
            }
        }
    }
}