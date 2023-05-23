using FullStack.API.Controllers.Models;
using FullStack.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly FullStackDBContext _fullstackdbcontext;

        public EmployeesController(FullStackDBContext fullstackdbcontext)
        {
            _fullstackdbcontext = fullstackdbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _fullstackdbcontext.Employees.ToListAsync();
            return Ok(employees);
        }


        [HttpPost]

        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.id = Guid.NewGuid();
            await _fullstackdbcontext.Employees.AddAsync(employeeRequest);
            await _fullstackdbcontext.SaveChangesAsync();

            return Ok(employeeRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employeeRequest = await _fullstackdbcontext.Employees.FirstOrDefaultAsync(x => x.id == id);

            if (employeeRequest == null)
            {
                return NotFound();
            }

            return Ok(employeeRequest);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employee updateEmployeeReq)
        {
            var employeeRequest = await _fullstackdbcontext.Employees.FindAsync(id);

            if (employeeRequest == null)
            {
                return NotFound();
            }

            employeeRequest.name = updateEmployeeReq.name;
            employeeRequest.email = updateEmployeeReq.email;
            employeeRequest.phone = updateEmployeeReq.phone;
            employeeRequest.salary = updateEmployeeReq.salary;
            employeeRequest.department = updateEmployeeReq.department;

            await _fullstackdbcontext.SaveChangesAsync();

            return Ok(employeeRequest);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employeeRequest = await _fullstackdbcontext.Employees.FindAsync(id);

            if (employeeRequest == null)
            {
                return NotFound();
            }

            _fullstackdbcontext.Employees.Remove(employeeRequest);
            await _fullstackdbcontext.SaveChangesAsync();
            return Ok(employeeRequest);
        }
    }
}
