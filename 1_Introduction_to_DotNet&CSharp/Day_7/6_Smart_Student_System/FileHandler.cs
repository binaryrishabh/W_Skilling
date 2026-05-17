using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _6_Smart_Student_System {
    public class FileHandler {
        private string filePath;

        public FileHandler(string path) {
            filePath = path;
        }

        // Create and Write
        public void CreateAndWrite(List<Student> students) {
            try {
                using (StreamWriter writer = new StreamWriter(filePath)) {
                    foreach (var student in students) {
                        writer.WriteLine($"{student.Id},{student.Name},{student.Marks}");
                    }
                }
                Console.WriteLine($"✓ File created and data written: {filePath}");
            }
            catch (Exception ex) {
                Console.WriteLine($"Error writing file: {ex.Message}");
            }
        }

        // Append data
        public void AppendData(Student student) {
            try {
                using (StreamWriter writer = new StreamWriter(filePath, true)) {
                    writer.WriteLine($"{student.Id},{student.Name},{student.Marks}");
                }
                Console.WriteLine($"✓ Student appended to file: {student.Name}");
            }
            catch (Exception ex) {
                Console.WriteLine($"Error appending: {ex.Message}");
            }
        }

        // Read data
        public List<Student> ReadData() {
            List<Student> students = new List<Student>();

            if (!File.Exists(filePath)) {
                Console.WriteLine("File does not exist!");
                return students;
            }

            try {
                using (StreamReader reader = new StreamReader(filePath)) {
                    string line;
                    while ((line = reader.ReadLine()) != null) {
                        string[] parts = line.Split(',');
                        if (parts.Length == 3) {
                            int id = int.Parse(parts[0]);
                            string name = parts[1];
                            int marks = int.Parse(parts[2]);
                            students.Add(new Student(id, name, marks));
                        }
                    }
                }
                Console.WriteLine($"✓ Data read from file: {filePath}");
            }
            catch (Exception ex) {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return students;
        }

        // Copy file
        public void CopyFile(string destinationPath) {
            try {
                File.Copy(filePath, destinationPath, true);
                Console.WriteLine($"✓ File copied to: {destinationPath}");
            }
            catch (Exception ex) {
                Console.WriteLine($"Error copying file: {ex.Message}");
            }
        }

        // Delete file
        public void DeleteFile() {
            try {
                if (File.Exists(filePath)) {
                    File.Delete(filePath);
                    Console.WriteLine($"✓ File deleted: {filePath}");
                }
                else {
                    Console.WriteLine("File does not exist!");
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Error deleting file: {ex.Message}");
            }
        }

        // Display file contents
        public void DisplayFileContents() {
            if (!File.Exists(filePath)) {
                Console.WriteLine("File does not exist!");
                return;
            }

            Console.WriteLine("\n===== File Contents =====");
            try {
                using (StreamReader reader = new StreamReader(filePath)) {
                    string line;
                    while ((line = reader.ReadLine()) != null) {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }
    }
}