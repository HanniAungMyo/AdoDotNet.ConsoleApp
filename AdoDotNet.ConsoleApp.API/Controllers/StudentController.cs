using AdoDotNet.ConsoleApp.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdoDotNet.ConsoleApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _db;

        public StudentController()
        {
            _db = new AppDbContext();
        }
        [HttpGet]
        public IActionResult GetStudent()
        {
            List<StudentModel> lst = _db.Students.ToList();
            return Ok(lst);
        }

        [HttpGet ("{id}")]

        public IActionResult GetStudentById(int id)
        {
            StudentModel? item = _db.Students.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(StudentModel student)
        {
            _db.Students.Add(student);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Create Successful" : "Failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, StudentModel student)
        {
            StudentModel? item = _db.Students.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            item.StuName = student.StuName;
            item.FatherName = student.FatherName;
            item.StuContent = student.StuContent;
            int result = _db.SaveChanges();
            string message = result > 0 ? "Update Successful" : "Failed";
            return Ok(message);
        }

        [HttpDelete ("{id}")]
        public IActionResult Delete(int id)
        {
            StudentModel? item = _db.Students.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }
            _db.Students.Remove(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Delete Successful" : "Failed";
            return Ok(message);
        }
    }
}

