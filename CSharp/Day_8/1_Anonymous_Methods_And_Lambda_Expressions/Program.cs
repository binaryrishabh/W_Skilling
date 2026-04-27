using _1_Anonymous_Methods_And_Lambda_Expressions;
using System;
using System.Collections.Generic;

namespace _1_Anonymous_Methods_And_Lambda_Expressions;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("=== Student Activity Evaluation System ===\n");
        Console.WriteLine("Demonstrating BOTH Anonymous Methods AND Lambda Expressions\n");

        // Create a list of students with their marks
        List<Student> students = new List<Student>
        {
                new Student("Aarav", 85, "Mathematics"),
                new Student("Vihaan", 45, "Science"),
                new Student("Vivaan", 72, "English"),
                new Student("Ananya", 38, "History")
        };

        // Display all students
        Console.WriteLine("All Students:");
        Console.WriteLine("-------------");
        foreach (var student in students) {
            Console.WriteLine(student);
        }

        Console.WriteLine("\n" + new string('=', 60) + "\n");

        // ============================================================
        // PART 1: ANONYMOUS METHOD (older syntax using 'delegate' keyword)
        // ============================================================

        Console.WriteLine("PART 1: USING ANONYMOUS METHOD");
        Console.WriteLine("--------------------------------");

        // Anonymous Method syntax: delegate(Student student) { return student.Marks > 50; }
        Predicate<Student> anonymousMethod = delegate (Student student) {
            return student.Marks > 50;
        };

        StudentEvaluator evaluator = new StudentEvaluator();
        List<Student> eligibleByAnonymous = evaluator.GetEligibleStudents(students, anonymousMethod);

        Console.WriteLine("Eligible Students using ANONYMOUS METHOD (Marks > 50):");
        foreach (var student in eligibleByAnonymous) {
            Console.WriteLine($"  ✓ {student.Name} - {student.Marks} marks");
        }
        Console.WriteLine($"Total: {eligibleByAnonymous.Count} students\n");

        // ============================================================
        // PART 2: LAMBDA EXPRESSION (modern syntax using '=>')
        // ============================================================

        Console.WriteLine("PART 2: USING LAMBDA EXPRESSION");
        Console.WriteLine("-------------------------------");

        // Lambda Expression syntax: student => student.Marks > 50
        Predicate<Student> lambdaExpression = student => student.Marks > 50;

        List<Student> eligibleByLambda = evaluator.GetEligibleStudents(students, lambdaExpression);

        Console.WriteLine("Eligible Students using LAMBDA EXPRESSION (Marks > 50):");
        foreach (var student in eligibleByLambda) {
            Console.WriteLine($"  ✓ {student.Name} - {student.Marks} marks");
        }
        Console.WriteLine($"Total: {eligibleByLambda.Count} students\n");

        Console.WriteLine(new string('=', 60) + "\n");

        // ============================================================
        // SIDE-BY-SIDE COMPARISON
        // ============================================================

        Console.WriteLine("SIDE-BY-SIDE COMPARISON:");
        Console.WriteLine("-----------------------");

        // Anonymous Method (verbose)
        Predicate<Student> isPassing_Anonymous = delegate (Student s) {
            return s.Marks >= 40;
        };

        // Lambda Expression (concise)
        Predicate<Student> isPassing_Lambda = s => s.Marks >= 40;

        Console.WriteLine("Checking if student is passing (marks >= 40):");
        Console.WriteLine($"Anonymous Method: {isPassing_Anonymous(students[1])} for Bob (45 marks)");
        Console.WriteLine($"Lambda Expression: {isPassing_Lambda(students[1])} for Bob (45 marks)");
        Console.WriteLine($"Anonymous Method: {isPassing_Anonymous(students[3])} for Diana (38 marks)");
        Console.WriteLine($"Lambda Expression: {isPassing_Lambda(students[3])} for Diana (38 marks)");

        Console.WriteLine("\n" + new string('=', 60) + "\n");

        // ============================================================
        // ADDITIONAL DEMONSTRATIONS (Using Lambda - modern preferred way)
        // ============================================================

        Console.WriteLine("ADDITIONAL DEMONSTRATIONS (Using Lambda Expressions):");
        Console.WriteLine("---------------------------------------------------");

        // Lambda 1: Students with marks >= 70 (Distinction)
        Console.WriteLine("\n1. Students with Distinction (Marks >= 70):");
        var distinctionStudents = students.FindAll(s => s.Marks >= 70);
        foreach (var student in distinctionStudents) {
            Console.WriteLine($"  ★ {student.Name} - {student.Marks} marks");
        }

        // Lambda 2: Students with marks < 40 (Failed)
        Console.WriteLine("\n2. Students who Failed (Marks < 40):");
        var failedStudents = students.FindAll(s => s.Marks < 40);
        foreach (var student in failedStudents) {
            Console.WriteLine($"  ✗ {student.Name} - {student.Marks} marks");
        }

        // Lambda 3: Students with marks between 50 and 75
        Console.WriteLine("\n3. Students with Marks between 50 and 75:");
        var rangeStudents = students.FindAll(s => s.Marks > 50 && s.Marks <= 75);
        foreach (var student in rangeStudents) {
            Console.WriteLine($"  → {student.Name} - {student.Marks} marks");
        }

        // Lambda 4: Students with specific subject
        Console.WriteLine("\n4. Students taking Physics:");
        var physicsStudents = students.FindAll(s => s.Subject == "Physics");
        foreach (var student in physicsStudents) {
            Console.WriteLine($"  ⚛ {student.Name} - {student.Subject}");
        }

        Console.WriteLine("\n" + new string('=', 60));
        Console.WriteLine("\nSUMMARY:");
        Console.WriteLine("-------");
        Console.WriteLine("✓ Anonymous Method: Uses 'delegate' keyword - Older syntax (C# 2.0)");
        Console.WriteLine("✓ Lambda Expression: Uses '=>' operator - Modern syntax (C# 3.0+)");
        Console.WriteLine("✓ Both achieve the same result, but Lambda is preferred for cleaner code");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}