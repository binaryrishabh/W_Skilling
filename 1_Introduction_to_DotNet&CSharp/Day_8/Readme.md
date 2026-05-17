# Assignment 1: Anonymous Methods & Lambda Expressions
    What has been asked?

        Use a lambda expression with Predicate<Student> to check student eligibility.

    What we will do?

        Create a Student Activity Evaluation System where:

        Define a Student class with properties (e.g., Name, Marks)

        Use Predicate<Student> with a lambda expression student => student.Marks > 50

        Filter and display eligible students

# Assignment 2: Func, Action, and Predicate Delegates
    What has been asked?

        Use a Func<List<int>, int> with an anonymous method to calculate and return total marks for a student.

    What we will do?

        Create a Student Evaluation System where:

        Store marks of a student in a List<int>

        Use Func<List<int>, int> delegate with an anonymous method

        Calculate and return the total marks

# Assignment 3: Events
    What has been asked?

        Create an OrderProcessor class (publisher) that raises an OrderPlaced event when an order is confirmed, 
        with a separate subscriber class.

    What we will do?

        Build an Order Processing System where:

        OrderProcessor class publishes OrderPlaced event

        Event is raised when order is confirmed

        Separate subscriber class handles the event (e.g., send notification, update inventory)

# Assignment 4: Generics
    What has been asked?

        Build a generic Box<T> class that can store and retrieve any single data type with no boxing overhead.

    What we will do?

        Create a Reusable Data Container where:

        Define a generic Box<T> class

        Can store any type: Box<int>, Box<string>, Box<Student>, etc.

        Demonstrate no boxing/unboxing for value types

# Assignment 5: Reflection
    What has been asked?

    Use reflection to map properties of a C# class to database table columns; dynamically inspect class to get 
    property names and types to build SQL queries.
    
    What we will do?

        Build a Custom ORM Framework where:

        Define a class (e.g., Product or Student)

        Use reflection to read property names and types

        Dynamically generate SELECT, INSERT, UPDATE SQL queries based on the class structure

# Assignment 6: Threading
    What has been asked?

        Launch multiple background tasks to generate various large reports simultaneously using multiple 
        threads to reduce total generation time.
    What we will do?

        Create a Reporting Service where:

        Generate multiple reports (e.g., Sales Report, Inventory Report, User Report)

        Run each report generation on a separate thread/task

        Compare sequential vs parallel execution time

# Assignment 7: ref & out Keywords
    What has been asked?

        Write a PerformExchange method that takes ref (to update balance directly) and out (to return a 
        status message about the exchange result).
    
    What we will do?

        Build a Financial Transaction System where:

        PerformExchange method accepts ref decimal balance and out string status

        Method updates the balance directly using ref

        Returns transaction status message using out

        Demonstrate the usage in Main()

# Assignment 8: async & await
    What has been asked?

        Use await FetchDataFromAPIAsync() to load data while keeping the UI responsive during remote server wait.

    What we will do?

        Create a Data Dashboard Application where:

        Simulate an async API call with Task.Delay() (or call a real API)

        Use async and await keywords

        UI remains responsive while data is being fetched (for console apps, demonstrate non-blocking behavior) 