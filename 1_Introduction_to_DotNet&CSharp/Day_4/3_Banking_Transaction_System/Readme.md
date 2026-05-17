# Banking Transaction System

## Scenario 3: Banking Transaction System

### User Story
As a banking application developer, I want to manage transactions and account operations so that users can perform secure 
and traceable financial activities.

Develop a transaction processing system.

### Requirements:-

Use the following collection types:

    List<Transaction> – for transaction history

    Dictionary<string, double> – for account balances

    Queue<Transaction> – for pending transactions

    Stack<Transaction> – for rollback operations

    HashSet<string> – to ensure unique transaction IDs

### Custom Object Example

    class Transaction
        public string TransactionId;
        public double Amount;
    }

### Expected Outcome

    Process transactions securely

    Prevent duplicate transactions

    Support rollback functionality


### Requirements Implemented

| Collection Type              |      Purpose                |    Implementation       |
|------------------------------|-----------------------------|-------------------------|
| `List<Transaction>`          | Transaction history         | `_transactionHistory`   |
| `Dictionary<string, double>` | Account balances            | `_accountBalances`      |
| `Queue<Transaction>`         | Pending transactions (FIFO) | `_pendingTransactions`  |
| `Stack<Transaction>`         | Rollback operations (LIFO)  | `_rollbackStack`        |
| `HashSet<string>`            | Unique transaction IDs      | `_uniqueTransactionIds` |

### Features

✅ Process transactions securely - Validates account existence and sufficient balance  
✅ Prevent duplicate transactions - Uses HashSet to track unique transaction IDs  
✅ Support rollback functionality - Stack-based LIFO rollback of last transaction  
✅ Pending transactions queue - FIFO processing of all pending transactions  
✅ Transaction history - Complete audit trail of all processed transactions  