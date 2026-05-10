using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.DTOs;
using Project.Models;

namespace Project.Controllers
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
        [HttpGet]
        public ActionResult<IEnumerable<DepartmentResponseDTO>> GetAll()
        {
            var deparments = _context.Departments.Include(d => d.Students).ToList();

            var response = deparments.Select(d => new DepartmentResponseDTO
            {
                Id = d.Id,
                DepartmentName = d.Name,
                ListOfStudentsNames = d.Students.Select(s => s.Name).ToList(),
                StudentsCount = d.Students.Count,
                Message = d.Students.Count > 1 ? "Overload" : "Normal"
            }).ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Department> GetById(int id)
        {
            var department = _context.Departments.Include(d => d.Students).FirstOrDefault(d => d.Id == id);

            if (department == null)
                return NotFound($"No department found with ID {id}");

            return Ok(department);
        }

        [HttpPost]
        public ActionResult<Department> Add(Department department)
        {
            var exists = _context.Departments.Any(d => d.Name == department.Name);
            if (exists)
                return BadRequest("A department with this name already exists");

            _context.Departments.Add(department);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Department department)
        {
            if (id != department.Id)
                return BadRequest("ID in URL does not match ID in body");

            var existing = _context.Departments.Find(id);
            if (existing == null)
                return NotFound($"No department found with ID {id}");

            var nameExists = _context.Departments
                .Any(d => d.Name == department.Name && d.Id != id);
            if (nameExists)
                return BadRequest("A department with this name already exists");

            existing.Name = department.Name;
            existing.Location = department.Location;
            existing.PhoneNo = department.PhoneNo;
            existing.Manager = department.Manager;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
                return NotFound($"No department found with ID {id}");

            _context.Departments.Remove(department);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
