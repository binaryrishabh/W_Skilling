using System;
using System.Collections.Generic;
using System.Text;

using System;
using System.Collections.Generic;

namespace _6_Smart_Student_System {
    [StudentInfo("Student Collection Management System", "1.0")]
    public class StudentCollection {
        private List<Student> students;

        public StudentCollection() {
            students = new List<Student>();
        }

        // Indexer to access students by position
        public Student this[int index] {
            get {
                if (index >= 0 && index < students.Count)
                    return students[index];
                throw new IndexOutOfRangeException("Student index out of range");
            }
            set {
                if (index >= 0 && index < students.Count)
                    students[index] = value;
                else
                    throw new IndexOutOfRangeException("Student index out of range");
            }
        }

        // Indexer to find student by ID
        public Student this[string operation, int id] {
            get {
                if (operation == "ById") {
                    return students.Find(s => s.Id == id);
                }
                return null;
            }
        }

        public void AddStudent(Student student) {
            students.Add(student);
        }

        public List<Student> GetAllStudents() {
            return students;
        }

        public int Count {
            get { return students.Count; }
        }

        public void DisplayAll() {
            Console.WriteLine("\n===== All Students =====");
            foreach (var student in students) {
                Console.WriteLine(student);
            }
        }
    }
}