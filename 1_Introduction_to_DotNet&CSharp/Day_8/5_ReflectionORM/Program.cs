using System;
using _5_ReflectionORM.Models;
using _5_ReflectionORM.ORM;

namespace _5_ReflectionORM {
    class Program {
        static void Main() {
            var orm = new SimpleORM();

            // Indian first names only
            var s1 = new Student { Id = 1, Name = "Aarav", Age = 20, City = "Mumbai" };
            var s2 = new Student { Id = 2, Name = "Diya", Age = 21, City = "Delhi" };
            var s3 = new Student { Id = 3, Name = "Rohan", Age = 19, City = "Pune" };

            Console.WriteLine("=== ORM Demo ===\n");

            // SELECT
            Console.WriteLine($"SELECT: {orm.GenerateSelectQuery<Student>("Students")}\n");

            // INSERT
            Console.WriteLine($"INSERT ({s1.Name}): {orm.GenerateInsertQuery(s1, "Students")}\n");
            Console.WriteLine($"INSERT ({s2.Name}): {orm.GenerateInsertQuery(s2, "Students")}\n");

            // UPDATE
            Console.WriteLine($"UPDATE ({s3.Name}): {orm.GenerateUpdateQuery(s3, "Students", 3)}\n");

            // Property inspection
            Console.WriteLine("Properties:");
            foreach (var p in typeof(Student).GetProperties())
                Console.Write($"{p.Name} ");
        }
    }
}
