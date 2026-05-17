using _2_Student_Evaluation_System.Models;
using _2_Student_Evaluation_System.Services;

namespace _2_Student_Evaluation_System;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("=".PadRight(60, '='));
        Console.WriteLine("    STUDENT EVALUATION SYSTEM");
        Console.WriteLine("    Using Func, Action, Predicate Delegates");
        Console.WriteLine("=".PadRight(60, '='));

        // Create sample students (UPDATED)
        Student student1 = new Student
        {
            StudentId = 2024001,
            Name = "Arjun",
            Class = "12th Grade - Science"
        };

        Student student2 = new Student
        {
            StudentId = 2024002,
            Name = "Neha",
            Class = "12th Grade - Commerce"
        };

        Student student3 = new Student
        {
            StudentId = 2024003,
            Name = "Vikram",
            Class = "12th Grade - Arts"
        };

        // Create marks for each student (UPDATED - different subject patterns)
        // Subjects: Mathematics, Physics, Chemistry, English, Computer Science
        List<int> marksStudent1 = new List<int> { 92, 88, 95, 78, 96 };  // Arjun - Excellent in Science
        List<int> marksStudent2 = new List<int> { 85, 90, 87, 92, 89 };  // Neha - Good in Commerce
        List<int> marksStudent3 = new List<int> { 45, 38, 52, 41, 35 };   // Vikram - Needs improvement

        // Initialize the calculator with anonymous methods (as requested)
        MarksCalculator calculator = new MarksCalculator();

        // Demonstrating Func, Action, Predicate usage

        Console.WriteLine("\n" + "─".PadRight(60, '─'));
        Console.WriteLine("DEMONSTRATION 1: Func Delegate (Calculates Total Marks)");
        Console.WriteLine("─".PadRight(60, '─'));

        int total1 = calculator.GetStudentTotalMarks(student1, marksStudent1);
        int total2 = calculator.GetStudentTotalMarks(student2, marksStudent2);
        int total3 = calculator.GetStudentTotalMarks(student3, marksStudent3);

        Console.WriteLine("\n" + "─".PadRight(60, '─'));
        Console.WriteLine("DEMONSTRATION 2: Predicate Delegate (Pass/Fail Check)");
        Console.WriteLine("─".PadRight(60, '─'));

        bool passed1 = calculator.HasStudentPassedAllSubjects(marksStudent1);
        bool passed2 = calculator.HasStudentPassedAllSubjects(marksStudent2);
        bool passed3 = calculator.HasStudentPassedAllSubjects(marksStudent3);

        Console.WriteLine($"{student1.Name} ({student1.Class}): {(passed1 ? "✓ PASSED" : "✗ FAILED")}");
        Console.WriteLine($"{student2.Name} ({student2.Class}): {(passed2 ? "✓ PASSED" : "✗ FAILED")}");
        Console.WriteLine($"{student3.Name} ({student3.Class}): {(passed3 ? "✓ PASSED" : "✗ FAILED")}");

        Console.WriteLine("\n" + "─".PadRight(60, '─'));
        Console.WriteLine("DEMONSTRATION 3: Using Func as Method Parameter");
        Console.WriteLine("─".PadRight(60, '─'));

        // Func can also be passed as a parameter to methods
        ProcessStudentMarks(student1, marksStudent1, calculator.CalculateTotalMarks);
        ProcessStudentMarks(student2, marksStudent2, calculator.CalculateTotalMarks);
        ProcessStudentMarks(student3, marksStudent3, calculator.CalculateTotalMarks);

        Console.WriteLine("\n" + "─".PadRight(60, '─'));
        Console.WriteLine("DEMONSTRATION 4: Direct Anonymous Method Usage");
        Console.WriteLine("─".PadRight(60, '─'));

        // Using Func directly without the calculator class
        Func<List<int>, int> directFunc = delegate (List<int> marks) {
            Console.WriteLine("Calculating directly with anonymous method...");
            int sum = 0;
            foreach (int m in marks) {
                sum += m;
            }
            return sum;
        };

        int directTotal = directFunc(marksStudent1);
        Console.WriteLine($"Direct calculation total for {student1.Name}: {directTotal}");

        Console.WriteLine("\n" + "=".PadRight(60, '='));
        Console.WriteLine("               PROGRAM COMPLETED");
        Console.WriteLine("=".PadRight(60, '='));
    }

    // Method demonstrating Func as a parameter
    static void ProcessStudentMarks(Student student, List<int> marks, Func<List<int>, int> totalCalculator) {
        int total = totalCalculator(marks);
        double average = total / (double)marks.Count;
        Console.WriteLine($"{student.Name,-15} | {student.Class,-20} | Total: {total,3} | Average: {average:F2}");
    }
}