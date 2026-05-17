using _1_StudentManagementSystem.Data;
using _1_StudentManagementSystem.Models;

namespace _1_StudentManagementSystem.Repository {
    public class StudentRepository : IStudentRepository {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context) => _context = context;

        public IEnumerable<Student> GetAll() => _context.Students.ToList();
        public Student? GetById(int id) => _context.Students.Find(id);
        public void Add(Student student) => _context.Students.Add(student);
        public void Update(Student student) => _context.Students.Update(student);
        public void Delete(int id) {
            var student = _context.Students.Find(id);
            if (student != null) _context.Students.Remove(student);
        }
        public void Save() => _context.SaveChanges();
    }
}