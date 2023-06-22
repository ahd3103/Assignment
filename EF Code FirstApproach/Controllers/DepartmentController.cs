using Employee_management_system.Context;
using Employee_management_system.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        // POST api/departments
        [HttpPost]
        public IActionResult CreateDepartment([FromBody] Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();

            return Ok(department);
        }

        // PUT api/departments/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(int id, [FromBody] Department department)
        {
            var existingDepartment = _context.Departments.Find(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }

            existingDepartment.DepartmentName = department.DepartmentName;
            _context.SaveChanges();

            return Ok(existingDepartment);
        }

        // DELETE api/departments/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            _context.SaveChanges();

            return Ok();
        }

        // GET api/departments
        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = _context.Departments.ToList();
            return Ok(departments);
        }

    }
}
