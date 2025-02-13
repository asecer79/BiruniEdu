using Microsoft.AspNetCore.Mvc;
using Week1_2.Models;

namespace Week1_2.Controllers
{
    public class StudentsController : Controller
    {

        //Actions

        public ActionResult Sum()
        {
            ViewBag.sumResult = 5 + 6;
            ViewBag.name = "Aydın";

          

            return View();
        }

        public ActionResult StudentList(int id,string name)
        {

            name = name ?? "";



            var student1 = new Student()
            {
                Id = 1,
                Name = "Ayşe",
                StudentId = "125345113",
                Description = "sadasd"
            };

            var student2 = new Student()
            {
                Id = 2,
                Name = "Mahmut",
                StudentId = "12534511w3",
                Description = "sadasd"
            };
            var student3 = new Student()
            {
                Id = 3,
                Name = "Neşecan",
                StudentId = "125s345w113",
                Description = "sadasd"
            };

            var students = new List<Student>()
            {
                student1,
                student2,
                student3
            };

            students = students.Where(
                p => 
                    p.Id == id &&
                    p.Name.Contains(name)
                    
                    
                    ).ToList();

            //students.Add(student1);
            //students.Add(student2);
            //students.Add(student3);

            return View(students);
        }

     
    }
}
