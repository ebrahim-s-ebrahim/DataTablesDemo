using DataTablesDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;

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
            var pageSize = int.Parse(Request.Form["length"]);
            var skip = int.Parse(Request.Form["start"]);

            var searchValue = Request.Form["search[value]"];

            var colToOrder = Request.Form["order[0][column]"];
            var sortColumn = Request.Form[("columns[" + colToOrder + "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];


            IQueryable<Student> students = _context.Students.Where(s => string.IsNullOrEmpty(searchValue)
                ? true
                : (s.FirstName.Contains(searchValue) || s.LastName.Contains(searchValue) || s.Email.Contains(searchValue)));


            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                students = students.OrderBy(sortColumn+" "+sortColumnDirection);
            }
                

            var data = students.Skip(skip).Take(pageSize).ToList();

            var recordsTotal = students.Count();

            var jsonData = new { recordsFilter = recordsTotal, recordsTotal, data };

            return Ok(jsonData);
        }
    }
}
