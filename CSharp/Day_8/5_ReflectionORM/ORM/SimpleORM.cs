using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5_ReflectionORM.ORM {
    public class SimpleORM {
        public string GenerateSelectQuery<T>(string tableName) {
            var properties = typeof(T).GetProperties();
            string columns = string.Join(", ", properties.Select(p => p.Name));
            return $"SELECT {columns} FROM {tableName};";
        }

        public string GenerateInsertQuery<T>(T entity, string tableName) {
            var properties = typeof(T).GetProperties();
            var columnNames = new List<string>();
            var valuePlaceholders = new List<string>();

            foreach (var prop in properties) {
                columnNames.Add(prop.Name);
                valuePlaceholders.Add($"@{prop.Name}");
            }

            string columns = string.Join(", ", columnNames);
            string values = string.Join(", ", valuePlaceholders);
            return $"INSERT INTO {tableName} ({columns}) VALUES ({values});";
        }

        public string GenerateUpdateQuery<T>(T entity, string tableName, int id) {
            var properties = typeof(T).GetProperties()
                .Where(p => p.Name != "Id");

            var setClauses = new List<string>();
            foreach (var prop in properties) {
                setClauses.Add($"{prop.Name} = @{prop.Name}");
            }

            string set = string.Join(", ", setClauses);
            return $"UPDATE {tableName} SET {set} WHERE Id = {id};";
        }
    }
}
