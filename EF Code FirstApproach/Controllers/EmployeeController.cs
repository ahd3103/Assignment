using Employee_management_system.Context;
using Employee_management_system.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // POST api/employees
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();

                return Ok(employee);
            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
                // Log or handle the exception as needed

                return BadRequest("An error occurred while saving the entity changes.");
            }
        }

        // PUT api/employees/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            var existingEmployee = _context.Employees.Find(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.Name = employee.Name;
            existingEmployee.Age = employee.Age;
            existingEmployee.Salary = employee.Salary;
            existingEmployee.DepartmentId = employee.DepartmentId;
            _context.SaveChanges();

            return Ok(existingEmployee);
        }

        // DELETE api/employees/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return Ok();
        }

        // GET api/employees
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _context.Employees.Include(e => e.Department).ToList();
            return Ok(employees);
        }

        // GET api/employees/{id}
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _context.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

    }
}
