using System;

Console.WriteLine("Top 10 Features of C# 7 & 8");
Console.WriteLine("--------------------------------------------------\n");

// 1. Tuples
Console.WriteLine("1. Tuples");

(double area, double perimeter) CalculateArea(double length, double width) {
    double area = length * width;
    double perimeter = 2 * (length + width);
    return (area, perimeter);
}

var result = CalculateArea(10, 20);

Console.WriteLine($"Area: {result.area}");
Console.WriteLine($"Perimeter: {result.perimeter}");

Console.WriteLine("\n--------------------------------------------------");

// 2. Out Variables
Console.WriteLine("2. Out Variables");

bool TryParseNumber(string input, out int number) {
    return int.TryParse(input, out number);
}

if (TryParseNumber("123", out int parsedValue)) {
    Console.WriteLine($"Parsed Value: {parsedValue}");
}

Console.WriteLine("\n--------------------------------------------------");

// 3. Pattern Matching
Console.WriteLine("3. Pattern Matching");

object obj = "Hello C#";

if (obj is string message) {
    Console.WriteLine($"String detected: {message}");
}

Console.WriteLine("\n--------------------------------------------------");

// 4. Local Functions (C# 7)
Console.WriteLine("4. Local Functions");

int Add(int a, int b) {
    return MultiplyByTwo(a + b);

    int MultiplyByTwo(int value) {
        return value * 2;
    }
}

Console.WriteLine($"Result: {Add(5, 10)}");

Console.WriteLine("\n--------------------------------------------------");

// 5. Ref Returns (C# 7)
Console.WriteLine("5. Ref Returns");

int[] numbers = { 10, 20, 30, 40 };

ref int GetElement(int index) {
    return ref numbers[index];
}

ref int element = ref GetElement(2);
element = 999;

Console.WriteLine($"Updated array value: {numbers[2]}");

Console.WriteLine("\n--------------------------------------------------");

// 6. Expression-bodied members (C# 7)
Console.WriteLine("6. Expression-bodied members");

int Square(int x) => x * x;

Console.WriteLine($"Square of 5: {Square(5)}");

Console.WriteLine("\n--------------------------------------------------");

// 7. Switch Expressions (C# 8)
Console.WriteLine("7. Switch Expressions");

string GetDayType(int day) => day switch
{
    1 => "Monday",
    2 => "Tuesday",
    3 => "Wednesday",
    4 => "Thursday",
    5 => "Friday",
    6 or 7 => "Weekend",
    _ => "Invalid"
};

Console.WriteLine(GetDayType(6));

Console.WriteLine("\n--------------------------------------------------");

// 8. Using Declarations (C# 8)
Console.WriteLine("8. Using Declarations");

using var file = new System.IO.MemoryStream();
Console.WriteLine("Resource will be disposed automatically.");

Console.WriteLine("\n--------------------------------------------------");

// 9. Nullable Reference Types (C# 8)
Console.WriteLine("9. Nullable Reference Types");

string? name = null;
Console.WriteLine(name ?? "Name is null");

Console.WriteLine("\n--------------------------------------------------");

// 10. Static Local Functions (C# 8)
Console.WriteLine("10. Static Local Functions");

int Multiply(int a, int b) {
    return MultiplyInner(a, b);

    static int MultiplyInner(int x, int y) {
        return x * y;
    }
}

Console.WriteLine($"Multiply: {Multiply(4, 5)}");

Console.WriteLine("\n--------------------------------------------------");

Console.WriteLine("End of Demo");