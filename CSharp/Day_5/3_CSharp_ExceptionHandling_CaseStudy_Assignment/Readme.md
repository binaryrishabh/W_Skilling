### Problem Statement

    Develop a Banking Transaction System where users can:

        1. Deposit money

        2. Withdraw money

        3. Check balance

    The system must handle invalid scenarios using exception handling in C#.

### Business Rules Enforced

    1. Minimum balance should be 1000

    2. Withdrawal amount cannot exceed balance

    3. Deposit amount must be greater than 0

    4. Invalid inputs should throw appropriate exceptions

### Exception Types Used

    1. Built-in Exceptions

        i. ArgumentException – for invalid deposit/withdrawal amounts

        ii. InvalidOperationException – for illegal operations

    2. Custom Exceptions (User-defined)

        i. InsufficientBalanceException – thrown when withdrawal causes balance below minimum (1000) or withdrawal exceeds 
           balance.

        ii. InvalidAmountException – thrown when deposit amount is ≤ 0

### What We Did (Implementation Summary)
Task	          What Was Implemented
----------------------------------------------------------------------------------------------------------------------------
Task 1	    |      Created BankAccount class with properties (AccountHolderName, Balance) + two custom exception classes
Task 2	    |      Implemented Deposit() method (adds amount if > 0, else throws InvalidAmountException) and Withdraw() 
            |      method (checks balance & minimum balance, else throws InsufficientBalanceException)
Task 3	    |      Used try-catch-finally in Main() to handle exceptions gracefully without crashing the program
Task 4	    |      Tested with invalid inputs (withdrawal > balance, deposit ≤ 0, withdrawal below 1000)
Task 5	    |      Displayed proper exception messages with clean console output

### Sample Scenarios Handled
# Scenario	                                      Exception Thrown
---------------------------------------------------------------------------
Withdraw > balance	                 |        InsufficientBalanceException
Deposit ≤ 0	                         |        InvalidAmountException
Withdraw causing balance < 1000	     |        InsufficientBalanceException


# Sample Output (Expected)

Enter account holder name: Sabrena
Initial balance: 5000

    1. Deposit
    2. Withdraw
    3. Check Balance
    Choose option: 2
    Enter amount to withdraw: 6000
    Error: Insufficient balance! Current balance: 5000

    Choose option: 1
    Enter amount to deposit: -500
    Error: Invalid amount! Deposit amount must be greater than 0.

    Program completed. (Finally block executed)