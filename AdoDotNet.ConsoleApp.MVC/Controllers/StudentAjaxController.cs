using AdoDotNet.ConsoleApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdoDotNet.ConsoleApp.MVC.Controllers
{
    public class StudentAjaxController : Controller
    {
        private readonly AppDbContext _db;
        public StudentAjaxController()
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
        public IActionResult StudentAjaxCreate()
        {
            return View("StudentAjaxCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult StudentSave(StudentModel student)
        {
            _db.Students.Add(student);
          int result=  _db.SaveChanges();
            string message = result > 0 ? "Successful Save" : "Fail";
            studentResMessageModel res = new studentResMessageModel()
            {
             IsSuccess=result > 0,
             Message = message
            };

            return Json(res);
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

