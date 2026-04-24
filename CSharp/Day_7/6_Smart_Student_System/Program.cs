using System;
using System.Collections.Generic;

namespace _6_Smart_Student_System {
    class Program {
        static StudentCollection studentCollection;
        static FileHandler fileHandler;
        static string filePath = "students.txt";
        static string backupPath = "students_backup.txt";

        static void Main(string[] args) {
            studentCollection = new StudentCollection();
            fileHandler = new FileHandler(filePath);

            // Adding sample data
            AddSampleData();

            bool exit = false;
            while (!exit) {
                DisplayMenu();
                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine();

                switch (choice) {
                    case "1":
                        PerformSearch();
                        break;
                    case "2":
                        PerformSorting();
                        break;
                    case "3":
                        AlgorithmComparer.DisplayComparison();
                        break;
                    case "4":
                        FileOperations();
                        break;
                    case "5":
                        DemonstrateOOP();
                        break;
                    case "6":
                        studentCollection.DisplayAll();
                        break;
                    case "7":
                        exit = true;
                        Console.WriteLine("Thank you for using Smart Student System!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }
        }

        static void DisplayMenu() {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║   SMART STUDENT DATA PROCESSING SYSTEM ║");
            Console.WriteLine("╠════════════════════════════════════════╣");
            Console.WriteLine("║  1. Search Student                     ║");
            Console.WriteLine("║  2. Sort Students by Marks             ║");
            Console.WriteLine("║  3. Compare Algorithms                 ║");
            Console.WriteLine("║  4. File Handling Operations           ║");
            Console.WriteLine("║  5. OOP Concepts Demo                  ║");
            Console.WriteLine("║  6. Display All Students               ║");
            Console.WriteLine("║  7. Exit                               ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
        }

        static void AddSampleData() {
            studentCollection.AddStudent(new Student(1007, "Vikram Singh", 73));
            studentCollection.AddStudent(new Student(1008, "Neha Desai", 91));
            studentCollection.AddStudent(new Student(1009, "Rahul Verma", 59));
            studentCollection.AddStudent(new Student(1010, "Sneha Joshi", 84));
            studentCollection.AddStudent(new Student(1011, "Aditya Kumar", 76));
        }

        static void PerformSearch() {
            Console.Clear();
            Console.WriteLine("===== Search Student =====");
            Console.WriteLine("1. Linear Search");
            Console.WriteLine("2. Binary Search");
            Console.Write("Choose search method: ");
            string choice = Console.ReadLine();

            Console.Write("Enter Student ID to search: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) {
                Console.WriteLine("Invalid ID!");
                Console.ReadKey();
                return;
            }

            var students = studentCollection.GetAllStudents();
            (int index, Student student) result;

            if (choice == "1") {
                result = SearchAlgorithms.LinearSearch(students, id);
                Console.WriteLine("\nUsing Linear Search (O(n))");
            }
            else {
                result = SearchAlgorithms.BinarySearch(students, id);
                Console.WriteLine("\nUsing Binary Search (O(log n))");
            }

            if (result.index != -1) {
                Console.WriteLine($"✓ Student Found at index {result.index}:");
                Console.WriteLine(result.student);
            }
            else {
                Console.WriteLine("✗ Student Not Found!");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void PerformSorting() {
            Console.Clear();
            Console.WriteLine("===== Sort Students by Marks =====");
            Console.WriteLine("1. Bubble Sort (O(n²))");
            Console.WriteLine("2. Quick Sort (O(n log n))");
            Console.WriteLine("3. Insertion Sort (O(n²))");
            Console.Write("Choose sorting method: ");
            string choice = Console.ReadLine();

            var students = studentCollection.GetAllStudents();
            List<Student> sortedStudents = null;

            switch (choice) {
                case "1":
                    sortedStudents = SortAlgorithms.BubbleSort(students);
                    Console.WriteLine("\nSorted using Bubble Sort:");
                    break;
                case "2":
                    sortedStudents = SortAlgorithms.QuickSort(students);
                    Console.WriteLine("\nSorted using Quick Sort:");
                    break;
                case "3":
                    sortedStudents = SortAlgorithms.InsertionSort(students);
                    Console.WriteLine("\nSorted using Insertion Sort:");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    Console.ReadKey();
                    return;
            }

            Console.WriteLine("\nRank  ID   Name      Marks");
            Console.WriteLine("--------------------------");
            for (int i = 0; i < sortedStudents.Count; i++) {
                Console.WriteLine($"{i + 1,4}. {sortedStudents[i].Id,-4} {sortedStudents[i].Name,-9} {sortedStudents[i].Marks}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void FileOperations() {
            bool back = false;
            while (!back) {
                Console.Clear();
                Console.WriteLine("===== File Handling Operations =====");
                Console.WriteLine("1. Create and Write File");
                Console.WriteLine("2. Read File");
                Console.WriteLine("3. Append Student");
                Console.WriteLine("4. Copy File");
                Console.WriteLine("5. Delete File");
                Console.WriteLine("6. Display File Contents");
                Console.WriteLine("7. Back to Main Menu");
                Console.Write("Choose operation: ");
                string choice = Console.ReadLine();

                switch (choice) {
                    case "1":
                        fileHandler.CreateAndWrite(studentCollection.GetAllStudents());
                        break;
                    case "2":
                        var data = fileHandler.ReadData();
                        Console.WriteLine($"\nRead {data.Count} students from file.");
                        foreach (var student in data) {
                            Console.WriteLine(student);
                        }
                        break;
                    case "3":
                        Console.Write("Enter ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Marks: ");
                        int marks = int.Parse(Console.ReadLine());
                        fileHandler.AppendData(new Student(id, name, marks));
                        break;
                    case "4":
                        fileHandler.CopyFile(backupPath);
                        break;
                    case "5":
                        Console.Write("Are you sure? (y/n): ");
                        if (Console.ReadLine().ToLower() == "y")
                            fileHandler.DeleteFile();
                        break;
                    case "6":
                        fileHandler.DisplayFileContents();
                        break;
                    case "7":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                if (!back) {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static void DemonstrateOOP() {
            Console.Clear();
            Console.WriteLine("===== OOP Concepts Demonstration =====");

            // Properties Demo
            Console.WriteLine("\n1. PROPERTIES DEMO");
            Console.WriteLine("Student class uses auto-properties:");
            Console.WriteLine("  - public int Id {{ get; set; }}");
            Console.WriteLine("  - public string Name {{ get; set; }}");
            Console.WriteLine("  - public int Marks {{ get; set; }}");

            // Indexer Demo
            Console.WriteLine("\n2. INDEXER DEMO");
            Console.WriteLine("Accessing students by index:");
            for (int i = 0; i < Math.Min(3, studentCollection.Count); i++) {
                Console.WriteLine($"  studentCollection[{i}]: {studentCollection[i]}");
            }

            Console.WriteLine("\nAccessing student by ID (using overloaded indexer):");
            var student = studentCollection["ById", 102];
            if (student != null)
                Console.WriteLine($"  studentCollection[\"ById\", 102]: {student}");
            else
                Console.WriteLine("  Student not found");

            // Custom Attribute Demo
            Console.WriteLine("\n3. CUSTOM ATTRIBUTE DEMO");
            var attributes = typeof(StudentCollection).GetCustomAttributes(false);
            foreach (var attr in attributes) {
                if (attr is StudentInfoAttribute studentAttr) {
                    Console.WriteLine($"  Class: StudentCollection");
                    Console.WriteLine($"  Description: {studentAttr.Description}");
                    Console.WriteLine($"  Version: {studentAttr.Version}");
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}