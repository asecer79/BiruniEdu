using Microsoft.AspNetCore.Mvc;
using Week3.Models;

namespace Week3.Controllers
{
    public class StudentsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var data = SchoolDb.StudentsTable;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var student = new Student();

            return View(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {

            if (ModelState.IsValid)
            {
                SchoolDb.StudentsTable.Add(student);

                return RedirectToAction("Index");
            }
            else
            {
                return View(student);
            }
         
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var student = SchoolDb.StudentsTable.FirstOrDefault(p=>p.Id==id);

            return View(student);
        }

        [HttpPost]
        public IActionResult Update(Student student)
        {
           var updated= SchoolDb.StudentsTable.FirstOrDefault(p=>p.Id== student.Id);
           updated.Description=student.Description;
           updated.Name=student.Name;
           updated.StudentId=student.StudentId;

            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var remove = SchoolDb.StudentsTable.FirstOrDefault(p => p.Id == id);

            SchoolDb.StudentsTable.Remove(remove);

            return RedirectToAction("Index");
        }
    }
}
