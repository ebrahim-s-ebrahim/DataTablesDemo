using DataTablesDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataTablesDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context) 
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult GetStudents()
        {
            var students = _context.Students.ToList();

            var recordsTotal = students.Count;

            var jsonData = new { recordsFilter = recordsTotal, recordsTotal, data = students };

            return Ok(jsonData);
        }
    }
}
