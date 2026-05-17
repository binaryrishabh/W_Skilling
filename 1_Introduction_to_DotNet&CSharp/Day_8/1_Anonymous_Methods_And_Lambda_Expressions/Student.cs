using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Anonymous_Methods_And_Lambda_Expressions {
    public class Student {
        public string Name { get; set; }
        public int Marks { get; set; }
        public string Subject { get; set; }

        public Student(string name, int marks, string subject) {
            Name = name;
            Marks = marks;
            Subject = subject;
        }

        public override string ToString() {
            return $"Name: {Name}, Marks: {Marks}, Subject: {Subject}";
        }
    }
}
