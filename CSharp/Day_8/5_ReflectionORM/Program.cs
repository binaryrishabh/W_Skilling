using System;
using _5_ReflectionORM.Models;
using _5_ReflectionORM.ORM;

namespace _5_ReflectionORM {
    class Program {
        static void Main() {
            Console.WriteLine("=== Custom ORM Using Reflection ===\n");

            var orm = new SimpleORM();
            var student = new Student
            {
                Id = 1,
                Name = "Raj",
                Age = 20,
                City = "Mumbai"
            };

            // Generate SQL queries dynamically
            string selectSql = orm.GenerateSelectQuery<Student>("Students");
            string insertSql = orm.GenerateInsertQuery(student, "Students");
            string updateSql = orm.GenerateUpdateQuery(student, "Students", 1);

            // Display results
            Console.WriteLine("[SELECT Query]");
            Console.WriteLine(selectSql + "\n");

            Console.WriteLine("[INSERT Query]");
            Console.WriteLine(insertSql + "\n");

            Console.WriteLine("[UPDATE Query]");
            Console.WriteLine(updateSql + "\n");

            Console.WriteLine("Property Inspection:");
            foreach (var prop in typeof(Student).GetProperties()) {
                Console.WriteLine($"- {prop.Name} : {prop.PropertyType.Name}");
            }
        }
    }
}