using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Student_Evaluation_System.Models {
    public class Student {
        public int StudentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;

        public override string ToString() {
            return $"StudentId: {StudentId}, Name: {Name}, Class: {Class}";
        }
    }
}
