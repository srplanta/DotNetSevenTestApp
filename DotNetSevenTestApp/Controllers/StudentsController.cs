using DotNetSevenTestApp.Models;
using DotNetSevenTestApp.Models.StudentDbModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetSevenTestApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentDbContext _context;

        public StudentsController(StudentDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Students.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_context.Students.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            //Student dbStudent = _context.Students.Where(x => x.StdId == student.StdId).FirstOrDefault();
            //dbStudent = student;
            _context.Students.Update(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(_context.Students.Find(id));
        }

        public IActionResult Delete(int id)
        {
            _context.Students.Remove(_context.Students.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
