using _2_Student_Evaluation_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Student_Evaluation_System.Services {
    public class MarksCalculator {
        // Using Func delegate to calculate total marks
        // Func<List<int>, int> - Takes List<int> as input, returns int
        public Func<List<int>, int> CalculateTotalMarks { get; set; }

        // Using Action delegate to display marks (no return value)
        // Action<List<int>> - Takes List<int> as input, returns void
        public Action<List<int>> DisplayMarks { get; set; }

        // Using Predicate delegate to check if student passed
        // Predicate<int> - Takes int as input, returns bool
        public Predicate<int> IsPassingMark { get; set; }

        public MarksCalculator() {
            // Initialize Func with anonymous method
            CalculateTotalMarks = delegate (List<int> marks) {
                int total = 0;
                foreach (int mark in marks) {
                    total += mark;
                }
                return total;
            };

            // Initialize Action with anonymous method
            DisplayMarks = delegate (List<int> marks) {
                Console.WriteLine("Marks: " + string.Join(", ", marks));
            };

            // Initialize Predicate with anonymous method (passing mark >= 40)
            IsPassingMark = delegate (int mark) {
                return mark >= 40;
            };
        }

        // Alternative: Using lambda expressions (more concise)
        // This shows the modern approach alongside the anonymous method requirement
        public MarksCalculator(bool useLambda) {
            if (useLambda) {
                CalculateTotalMarks = marks => marks.Sum();
                DisplayMarks = marks => Console.WriteLine("Marks: " + string.Join(", ", marks));
                IsPassingMark = mark => mark >= 40;
            }
            else {
                // Same as above constructor
                CalculateTotalMarks = delegate (List<int> marks) {
                    int total = 0;
                    foreach (int mark in marks) {
                        total += mark;
                    }
                    return total;
                };

                DisplayMarks = delegate (List<int> marks) {
                    Console.WriteLine("Marks: " + string.Join(", ", marks));
                };

                IsPassingMark = delegate (int mark) {
                    return mark >= 40;
                };
            }
        }

        // Method that uses the Func delegate to get student's total marks
        public int GetStudentTotalMarks(Student student, List<int> marks) {
            Console.WriteLine($"\n--- Calculating total marks for {student.Name} ---");
            DisplayMarks(marks);
            int total = CalculateTotalMarks(marks);
            Console.WriteLine($"Total Marks: {total}");
            return total;
        }

        // Method to check if student passed all subjects
        public bool HasStudentPassedAllSubjects(List<int> marks) {
            foreach (int mark in marks) {
                if (!IsPassingMark(mark)) {
                    return false;
                }
            }
            return true;
        }
    }
}