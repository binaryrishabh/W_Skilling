There are 5 Scenarios in Day_4

Scenario 1: E-Commerce Order Management System

What to do:

    Use List<Order> to store all orders

    Use Dictionary<int, Customer> to map customer ID → customer details

    Use HashSet<string> for unique product categories

    Use Queue<Order> for FIFO order processing

    Use Stack<string> for LIFO order status history

    Implement: add/update/remove orders, process in sequence, track status changes, ensure unique categories

Scenario 2: Social Media Platform (User Engagement System)

What to do:

    Use List<string> to store posts

    Use Dictionary<string, int> to track likes per post

    Use HashSet<int> for unique user IDs

    Use Stack<string> for recent actions (undo)

    Use Queue<string> to process notifications

    Implement: unique users, efficient likes tracking, undo feature, sequential notifications

Scenario 3: Banking Transaction System

What to do:

    Use List<Transaction> for transaction history

    Use Dictionary<string, double> for account balances

    Use Queue<Transaction> for pending transactions

    Use Stack<Transaction> for rollback operations

    Use HashSet<string> for unique transaction IDs

    Implement: secure processing, prevent duplicate transactions, rollback support

Scenario 4: Music Playlist Manager (Advanced Collections)

What to do:

    Use LinkedList<string> to manage playlist songs (easy insert/remove)

    Use SortedList<int, string> to store songs sorted by rating

    Use SortedDictionary<string, string> to map artist → song (sorted by artist name)

    Implement: add/remove songs efficiently, maintain sorted playlist by rating, retrieve songs by artist in sorted order

Scenario 5: Task Scheduler System

What to do:

    Use Queue<string> for task execution order

    Use Stack<string> for undoing last executed task

    Use List<string> for all tasks

    Use SortedDictionary<int, string> for priority-based tasks

    Use HashSet<string> to ensure no duplicate tasks

    Implement: execute tasks in order, undo last operation, maintain priority-based scheduling