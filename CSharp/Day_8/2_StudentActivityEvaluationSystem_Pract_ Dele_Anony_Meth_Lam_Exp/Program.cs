using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_StudentActivityEvaluationSystem_Pract__Dele_Anony_Meth_Lam_Exp {
    // Student class to hold student data
    public class Student {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AssignmentScore { get; set; }
        public double ExamScore { get; set; }
        public double AttendancePercentage { get; set; }
        public double ParticipationScore { get; set; }

        public double TotalMarks =>
            (AssignmentScore * 0.3) + (ExamScore * 0.4) +
            (AttendancePercentage * 0.15) + (ParticipationScore * 0.15);
    }

    // Delegate declaration for student evaluation logic
    public delegate void StudentEvaluationHandler(Student student);

    class Program {
        static void Main() {
            Console.WriteLine("=== Student Activity Evaluation System ===\n");

            // Sample data
            List<Student> students = new List<Student>
            {
                new Student { Id = 101, Name = "Alice Johnson", AssignmentScore = 85, ExamScore = 78, AttendancePercentage = 92, ParticipationScore = 88 },
                new Student { Id = 102, Name = "Bob Smith", AssignmentScore = 45, ExamScore = 52, AttendancePercentage = 60, ParticipationScore = 40 },
                new Student { Id = 103, Name = "Charlie Brown", AssignmentScore = 92, ExamScore = 88, AttendancePercentage = 95, ParticipationScore = 90 },
                new Student { Id = 104, Name = "Diana Prince", AssignmentScore = 76, ExamScore = 82, AttendancePercentage = 88, ParticipationScore = 79 },
                new Student { Id = 105, Name = "Ethan Hunt", AssignmentScore = 35, ExamScore = 42, AttendancePercentage = 55, ParticipationScore = 38 }
            };

            // ========== US1: Calculate Total Marks using Func + Anonymous Method ==========
            Console.WriteLine("--- US1: Calculate Total Marks (Func + Anonymous Method) ---");

            Func<Student, double> calculateTotalMarks = delegate (Student s) {
                double total = (s.AssignmentScore * 0.3) + (s.ExamScore * 0.4) +
                              (s.AttendancePercentage * 0.15) + (s.ParticipationScore * 0.15);
                return total;
            };

            double aliceTotal = calculateTotalMarks(students[0]);
            Console.WriteLine($"Alice's Calculated Total using Anonymous Method: {aliceTotal:F1}%");
            Console.WriteLine($"Alice's Property Total: {students[0].TotalMarks:F1}% (Verification)\n");

            // ========== US2: Display Student Details using Action + Lambda ==========
            Console.WriteLine("--- US2: Display Student Details (Action<T> + Lambda) ---");

            Action<Student> displayStudent = s =>
                Console.WriteLine($"  {s.Id,-5} {s.Name,-15} | Assign: {s.AssignmentScore,3}% | Exam: {s.ExamScore,3}% | Attend: {s.AttendancePercentage,3}% | Part: {s.ParticipationScore,3}% | Total: {s.TotalMarks,5:F1}%");

            Console.WriteLine("  ID    Name            | Assign | Exam | Attend | Part | Total");
            Console.WriteLine("  ---------------------------------------------------------------");
            foreach (var student in students) {
                displayStudent(student);
            }

            // ========== US3: Check Eligibility using Predicate + Lambda ==========
            Console.WriteLine("\n--- US3: Check Eligibility - Marks > 50 (Predicate + Lambda) ---");

            Predicate<Student> isEligible = s => s.TotalMarks > 50;

            Console.WriteLine("Eligibility Status (Total Marks > 50):");
            foreach (var student in students) {
                string status = isEligible(student) ? "ELIGIBLE" : "NOT ELIGIBLE";
                Console.WriteLine($"  {student.Name,-15} - Total: {student.TotalMarks,5:F1}% - {status}");
            }

            // ========== US4: Filter Top Performers using Predicate + List.FindAll() ==========
            Console.WriteLine("\n--- US4: Filter Top Performers - Score > 75 (Predicate + List.FindAll) ---");

            Predicate<Student> isTopPerformer = s => s.TotalMarks > 75;
            List<Student> topPerformers = students.FindAll(isTopPerformer);

            Console.WriteLine("Top Performers (Total Marks > 75%):");
            if (topPerformers.Count > 0) {
                foreach (var student in topPerformers) {
                    Console.WriteLine($"  {student.Name,-15} - Total: {student.TotalMarks:F1}%");
                }
            }
            else {
                Console.WriteLine("  No top performers found.");
            }

            // ========== US5: Anonymous Method (Delegate keyword for inline logic) ==========
            Console.WriteLine("\n--- US5: Anonymous Method using 'delegate' keyword ---");

            StudentEvaluationHandler evaluateStudent = delegate (Student s) {
                string grade;
                if (s.TotalMarks >= 85)
                    grade = "A (Excellent)";
                else if (s.TotalMarks >= 70)
                    grade = "B (Good)";
                else if (s.TotalMarks >= 55)
                    grade = "C (Average)";
                else if (s.TotalMarks >= 40)
                    grade = "D (Below Average)";
                else
                    grade = "F (Fail)";

                Console.WriteLine($"  {s.Name}: {s.TotalMarks:F1}% -> Grade: {grade}");
            };

            Console.WriteLine("Student Evaluation (Anonymous Method):");
            foreach (var student in students) {
                evaluateStudent(student);
            }

            // ========== US6: Lambda Expression for Cleaner Code ==========
            Console.WriteLine("\n--- US6: Lambda Expression replacing Anonymous Method (=> syntax) ---");

            StudentEvaluationHandler evaluateStudentLambda = s =>
            {
                string grade;
                if (s.TotalMarks >= 85)
                    grade = "A (Excellent)";
                else if (s.TotalMarks >= 70)
                    grade = "B (Good)";
                else if (s.TotalMarks >= 55)
                    grade = "C (Average)";
                else if (s.TotalMarks >= 40)
                    grade = "D (Below Average)";
                else
                    grade = "F (Fail)";

                Console.WriteLine($"  {s.Name}: {s.TotalMarks:F1}% -> Grade: {grade}");
            };

            Console.WriteLine("Student Evaluation (Lambda Expression):");
            foreach (var student in students) {
                evaluateStudentLambda(student);
            }

            // ========== Summary Table ==========
            Console.WriteLine("\n=== Summary of Concepts Demonstrated ===");
            Console.WriteLine("US1: Func<T, TResult> with Anonymous Method - Calculate Total Marks");
            Console.WriteLine("US2: Action<T> with Lambda Expression - Display Student Details");
            Console.WriteLine("US3: Predicate<T> with Lambda - Check Eligibility (Marks > 50)");
            Console.WriteLine("US4: Predicate<T> with List.FindAll() - Filter Top Performers (>75%)");
            Console.WriteLine("US5: Anonymous Method using 'delegate' keyword - Student Evaluation");
            Console.WriteLine("US6: Lambda Expression (=>) - Cleaner Code for Student Evaluation");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
