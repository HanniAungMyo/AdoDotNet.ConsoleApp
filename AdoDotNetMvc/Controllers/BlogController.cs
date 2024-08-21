using AdoDotNetMvc.EFCoreExample;
using AdoDotNetMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdoDotNetMvc.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController()
        {
            _context = new AppDbContext();
        }

        [ActionName("Index")]
        public IActionResult BlogIndex()
        {
            List<StudentModel> lst=_context.Students.ToList();
            return View("BlogIndex",lst);
        }
    }
}
