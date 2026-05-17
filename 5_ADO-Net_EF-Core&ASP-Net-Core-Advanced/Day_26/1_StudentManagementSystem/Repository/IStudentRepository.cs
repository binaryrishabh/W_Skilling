using _1_StudentManagementSystem.Models;

namespace _1_StudentManagementSystem.Repository {
    public interface IStudentRepository {
        IEnumerable<Student> GetAll();
        Student? GetById(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);
        void Save();
    }
}