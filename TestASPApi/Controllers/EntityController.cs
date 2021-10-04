using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestASPApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TestASPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        EntityContext _context;
        public EntityController(EntityContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<Employee>> SetEntity(Employee employee, int idDepartment)
        {
            Employee newEmployee = await _context.Employees.FirstOrDefaultAsync(p => p.Id == employee.Id);
            newEmployee.Email = employee.Email;

            if (idDepartment != 0)
            {
                employee.Departments.Clear();
                employee.Departments.Add(_context.Departments.FirstOrDefault(p => p.Id == idDepartment));
                _context.Entry(newEmployee).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(employee);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
