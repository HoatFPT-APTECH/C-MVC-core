using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DWAS_T2111E_MaiHuyHoat.Models;

namespace DWAS_T2111E_MaiHuyHoat.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly PracDBContext _context;

        public EmployeesController(PracDBContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees([FromQuery] Employee model)
        {
            var data = _context.Employees.Where(m =>
            (m.EmployeeName.ToLower().Contains(model.EmployeeName.ToLower()) || model.EmployeeName == "")
            && (m.EmployeeDOB == model.EmployeeDOB || model.EmployeeDOB == DateTime.Now));
            return data==null? NotFound("No Data") : Ok(data);

        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            var listProducts = from p in _context.Projects
                               join pe in _context.ProjectEmployees on p.ProjectId equals pe.ProjectId
                               where pe.EmployeeId == id
                               select p;
            if (employee == null) return NotFound("No Data");
            var data = new EP
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                EmployeeDOB = employee.EmployeeDOB,
                EmployeeDepartment = employee.EmployeeDepartment,
                projects = listProducts.ToList(),
            };
            return  Ok(data);
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
          if (_context.Employees == null)
          {
              return Problem("Entity set 'PracDBContext.Employees'  is null.");
          }
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
