using System;
using System.Collections.Generic;
using System.Text;

namespace _6_Smart_Student_System {
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class StudentInfoAttribute : Attribute {
        public string Description { get; set; }
        public string Version { get; set; }

        public StudentInfoAttribute(string description, string version = "1.0") {
            Description = description;
            Version = version;
        }
    }
}