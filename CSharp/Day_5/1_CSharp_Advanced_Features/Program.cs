using System.Reflection.Metadata;

Console.WriteLine("Hello, World!");
Console.WriteLine("Hello, World!");

// C#Features in 7 and 8 versions.

// 1. tuples and out variables:
// C# have tubles for returning multiple values from a method without needing to create a seperate class or struct.
// For example:
// If I am having a method that calculates the area and parameter of a rectangle and I want to return both the area and parameter in a tuple.

(double area, double perimeter) CalculateRectangle(double length, double width) {
    double area = length * width;
    double perimeter = 2 * (length + width);

    return (area, perimeter);
}

// in contrast to a single return statement, I can return multiple values in a tuple.
// The benefit is that it simplifies the code and makes it more readable, as don't need to create a separate class or struct.
CalculateRectangle(10, 5); // This will return a tuple containing the area and perimeter of the rectangle
CalculateRectangle(10, 10);

Console.WriteLine($"Output of the tuple implementation: {CalculateRectangle(10, 5)}");

// --------------------------------------------------------------------------------------------------------------------

// 2. Pattern matching:
// Pattern matching allows us to check an object against a pattern and extract values from it.
// Step 1: We can use the "is" keyword to check if an object is of a certain type, and if it is then we can extract values from it.
// Step 2: We can use the "as" keyword to cast an object to a specific type.
// Step 3: We can use the "switch" keyword to check if an object is of a certain type.
// Step 4: We can use the "when" keyword to check if an object is of a certain type.

Console.WriteLine("Enter a value:");
string input = Console.ReadLine();
switch (input) {
    case int i:
        Console.WriteLine($"The input is an integer: {i}");
        break;
    case double d:
        Console.WriteLine($"The input is a double: {d}");
        break;
    case string s:
        Console.WriteLine($"The input is a string: {s}");
        break;
    default:
        Console.WriteLine("The input is of an unknown type.");
        break;
}


//Scenario for implemeting Pattern matching with Switch statement:
//Step 1: We will take input from the user and check if it is an integer, a double, or a string.
//Step 2: We will use a switch statement to match the input against different patterns and execute
//different code based on the pattern that matches.
//Step 3: We will also use pattern matching with tuples to deconstruct them and extract values.
//Step 4: Showing output of pattern matching with properties to check if an object has certain

// --------------------------------------------------------------------------------------------------------------------

// Questions to do.
//We have to create Program covering top 10 C# 7 & 8 features 
//We have to explore Exception and File handling in C#
//We will have demo based on delegates and events in C#
//Refelection and Attributes in C#

//Solid principles and Design patterns in C#

//You can create a table with features and their descriptions for better understanding.

// --------------------------------------------------------------------------------------------------------------------

// 3. Local functions:
// 4. Async streams:
// 5. Nullable Reference Types:


// C#Features in 9 and 10 versions.
// 1. Records:
// 2. Init-only properties:
// 3. Top-level statements:
// 4. Target-typed new expression:
// 5. Pattern Matching Enhancements: