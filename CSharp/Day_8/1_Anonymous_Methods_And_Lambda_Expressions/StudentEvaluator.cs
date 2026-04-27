using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Anonymous_Methods_And_Lambda_Expressions {
    public class StudentEvaluator {
        // Method that uses Predicate delegate (can accept both Anonymous Method and Lambda)
        public List<Student> GetEligibleStudents(List<Student> students, Predicate<Student> eligibilityCriteria) {
            List<Student> eligibleStudents = new List<Student>();

            foreach (Student student in students) {
                if (eligibilityCriteria(student)) {
                    eligibleStudents.Add(student);
                }
            }

            return eligibleStudents;
        }

        // Alternative using LINQ FindAll
        public List<Student> GetEligibleStudentsLinq(List<Student> students, Predicate<Student> eligibilityCriteria) {
            return students.FindAll(eligibilityCriteria);
        }
    }
}