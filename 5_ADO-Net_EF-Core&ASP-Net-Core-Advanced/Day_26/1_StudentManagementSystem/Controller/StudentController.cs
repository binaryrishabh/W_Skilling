using Microsoft.AspNetCore.Mvc;
using _1_StudentManagementSystem.Models;
using _1_StudentManagementSystem.Data;

namespace _1_StudentManagementSystem.Controllers {
    public class StudentController : Controller {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context) {
            _context = context;
        }

        public IActionResult Index() {
            return View(_context.Students.ToList());
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Name, string Course, int Age) {
            var student = new Student
            {
                Name = Name,
                Course = Course,
                Age = Age
            };
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id) {
            var student = _context.Students.Find(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int Id, string Name, string Course, int Age) {
            var student = _context.Students.Find(Id);
            if (student != null) {
                student.Name = Name;
                student.Course = Course;
                student.Age = Age;
                _context.Students.Update(student);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            var student = _context.Students.Find(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id) {
            var student = _context.Students.Find(id);
            if (student != null) {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}