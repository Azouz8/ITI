using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Repositories;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IGenericRepository<Student> _studentRepo;

    public StudentController(IGenericRepository<Student> studentRepo)
    {
        _studentRepo = studentRepo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetAll()
    {
        return Ok(_studentRepo.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Student> GetById(int id)
    {
        var student = _studentRepo.GetById(id);
        if (student == null) return NotFound();
        return Ok(student);
    }

    [HttpPost]
    public ActionResult<Student> Add(Student student)
    {
        _studentRepo.Add(student);
        _studentRepo.Save();
        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Student student)
    {
        if (id != student.Id) return BadRequest();

        var existing = _studentRepo.GetById(id);
        if (existing == null) return NotFound();

        _studentRepo.Update(student);
        _studentRepo.Save();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var existing = _studentRepo.GetById(id);
        if (existing == null) return NotFound();

        _studentRepo.Delete(id);
        _studentRepo.Save();
        return NoContent();
    }

    [HttpPost("upload-image/{id}")]
    public IActionResult UploadImage(int id, IFormFile image)
    {
        var student = _studentRepo.GetById(id);
        if (student == null) return NotFound();

        // ... image processing logic ...

        student.ImagePath = $"/images/students/{image.FileName}";
        _studentRepo.Update(student);
        _studentRepo.Save();

        return Ok(new { imagePath = student.ImagePath });
    }
}