using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context) { _context = context; }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            var students = _context.Students.ToList();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound($"No student found with ID {id}");
            }
            return Ok(student);
        }

        [HttpGet("name/{name}")]
        public ActionResult<IEnumerable<Student>> GetByName(string name)
        {
            throw new Exception("Something went wrong!");
            var students = _context.Students.Where(s => s.Name.Contains(name)).ToList();
            if (!students.Any())
            {
                return NotFound($"No students found with name containing '{name}'");
            }
            return Ok(students);
        }

        [HttpPost]
        public ActionResult<Student> Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Student student)
        {
            var existing = _context.Students.Find(id);
            if (existing == null)
                return NotFound($"No student found with ID {id}");

            existing.Name = student.Name;
            existing.Age = student.Age;
            existing.Address = student.Address;
            existing.Email = student.Email;
            existing.Level = student.Level;
            existing.DateOfBirth = student.DateOfBirth;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                return NotFound($"No student found with ID {id}");

            _context.Students.Remove(student);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost("upload-image/{id}")]
        public IActionResult UploadImage(int id, IFormFile image)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound($"No Student Found with ID {id}");

            if (image == null || image.Length == 0)
                return BadRequest("No Image Provided");

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png"};
            var extension = Path.GetExtension(image.FileName).ToLower();

            if (!allowedExtensions.Contains(extension))
                return BadRequest("Only image files are allowed (.jpg, .jpeg, .png)");

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "students");
            Directory.CreateDirectory(folderPath);

            var fileName = image.FileName;
            var fullPath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            student.ImagePath = $"/images/students/{fileName}";
            _context.SaveChanges();

            return Ok(new { imagePath = student.ImagePath });
        }
    }
}
