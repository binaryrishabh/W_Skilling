using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5_ReflectionORM.ORM {
    public class SimpleORM {
        public string GenerateSelectQuery<T>(string tableName) {
            var props = typeof(T).GetProperties();
            string cols = string.Join(", ", props.Select(p => p.Name));
            return $"SELECT {cols} FROM {tableName};";
        }

        public string GenerateInsertQuery<T>(T entity, string tableName) {
            var props = typeof(T).GetProperties();
            var cols = string.Join(", ", props.Select(p => p.Name));
            var vals = string.Join(", ", props.Select(p => $"@{p.Name}"));
            return $"INSERT INTO {tableName} ({cols}) VALUES ({vals});";
        }

        public string GenerateUpdateQuery<T>(T entity, string tableName, int id) {
            var props = typeof(T).GetProperties().Where(p => p.Name != "Id");
            var set = string.Join(", ", props.Select(p => $"{p.Name} = @{p.Name}"));
            return $"UPDATE {tableName} SET {set} WHERE Id = {id};";
        }
    }
}