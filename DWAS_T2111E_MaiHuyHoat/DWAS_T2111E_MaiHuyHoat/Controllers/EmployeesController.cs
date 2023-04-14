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
    [Route("api/[controller]")]
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
            var data = from e in _context.Employees
                       join pe in _context.ProjectEmployees on e.EmployeeId equals pe.EmployeeId
                       join p in _context.Projects on pe.ProjectId equals p.ProjectId
                       where e.EmployeeId == id
                       select ((e,p) => new EP
                       {
                           EP.EmployeeId = e.EmployeeId,
                           EP.EmployeeName = e.EmployeeName,
                           EP.EmployeeDOB = e.EmployeeDOB,
                           EP.EmployeeDepartment = e.EmployeeDepartment,
                           EP.Projects = p.ToList()

                       }) ;
            return data==null? NotFound("No Data"): Ok(data);
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
