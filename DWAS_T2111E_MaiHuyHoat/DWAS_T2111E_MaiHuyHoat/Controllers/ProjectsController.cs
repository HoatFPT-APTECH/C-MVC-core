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
    public class ProjectsController : ControllerBase
    {
        private readonly PracDBContext _context;

        public ProjectsController(PracDBContext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<IActionResult> GetProjectsAll([FromQuery] Project model)
        {
            var data = _context.Projects.Where(m =>
            
                (m.ProjectName.ToLower().Contains(model.ProjectName.ToLower()) || model.ProjectName == "")
                && (m.ProjectStartDate == model.ProjectStartDate || m.ProjectEndDate == null || m.ProjectEndDate > DateTime.Now)
                && (m.ProjectEndDate == model.ProjectEndDate || m.ProjectEndDate == null || m.ProjectEndDate > DateTime.Now)
            ).ToList();
            return data == null ? NotFound("No Data") : Ok(data);
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProject(int id)
        {
            var project = _context.Projects.Find(id);
            if(project == null) { return NotFound("No Data"); }
            var listEmployee=from e in _context.Employees
                             join pe in _context.ProjectEmployees on e.EmployeeId equals pe.ProjectId
                             where pe.ProjectId == id
                             select e;

            var data = new PE
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName,
                ProjectStartDate = project.ProjectStartDate,
                ProjectEndDate = project.ProjectEndDate,
                Employees = listEmployee.ToList(),
            };
            return Ok(data);
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project project)
        {
            if (id != project.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
          if (_context.Projects == null)
          {
              return Problem("Entity set 'PracDBContext.Projects'  is null.");
          }
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = project.ProjectId }, project);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            if (_context.Projects == null)
            {
                return NotFound();
            }
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return (_context.Projects?.Any(e => e.ProjectId == id)).GetValueOrDefault();
        }
    }
}
