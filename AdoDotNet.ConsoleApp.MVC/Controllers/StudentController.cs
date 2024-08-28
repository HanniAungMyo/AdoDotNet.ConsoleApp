using AdoDotNet.ConsoleApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdoDotNet.ConsoleApp.MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _db;
        public StudentController()
        {
            _db = new AppDbContext();
        }
        [ActionName("Index")]
        public IActionResult StudentIndex()
        {
            List<StudentModel> lst = _db.Students.ToList();
            return View("StudentIndex", lst);
        }

        [ActionName("Edit")]
        public IActionResult StudentEdit(int id)
        {
            StudentModel? item = _db.Students.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                return Redirect("/Student");
            }
            return View("StudentEdit", item);
        }

        [ActionName("Create")]
        public IActionResult StudentCreate()
        {
            return View("studentCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult StudentSave(StudentModel student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
            return Redirect("/Student");
        }
        [HttpPost]
        [ActionName("Update")]
        public IActionResult StudentUpdate(int id, StudentModel student)
        {
            StudentModel? item = _db.Students.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                return Redirect("/Student");
            }

            item.StuName = student.StuName;
            item.FatherName = student.FatherName;
            item.StuContent = student.StuContent;
            _db.SaveChanges();
            return Redirect("/Student");
        }

        [ActionName("Delete")]
        public IActionResult StudentDelete(int id)
        {
            StudentModel? item = _db.Students.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                return Redirect("/student");
            }
            _db.Students.Remove(item);
            _db.SaveChanges();
            return Redirect("/student");
        }
    }
}

