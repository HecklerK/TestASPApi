using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestASPApi.Models;

namespace TestASPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EntityContext _context;

        public EmployeesController(EntityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get(int id)
        {
            if (id == 0)
            {
                return await _context.Employees.ToListAsync();
            }
            else
            {
                Employee employee = await _context.Employees.SingleOrDefaultAsync(p => p.Id == id);
                if (employee == null)
                    return NotFound();
                return new ObjectResult(new {id = employee.Id, email = employee.Email, gender = employee.Gender, department = _context.Departments.FirstOrDefault(p => p.Employees.Contains(employee))});
            }
        }
    }
}
