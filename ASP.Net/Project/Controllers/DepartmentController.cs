using Microsoft.AspNetCore.Mvc;
using Project.DTOs;
using Project.Models;
using Project.Repositories;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IGenericRepository<Department> _repository;

    public DepartmentController(IGenericRepository<Department> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<DepartmentResponseDTO>> GetAll()
    {
        var departments = _repository.GetAll();

        var response = departments.Select(d => new DepartmentResponseDTO
        {
            Id = d.Id,
            DepartmentName = d.Name,
            ListOfStudentsNames = d.Students?.Select(s => s.Name).ToList() ?? new List<string>(),
            StudentsCount = d.Students?.Count ?? 0,
            Message = (d.Students?.Count ?? 0) > 1 ? "Overload" : "Normal"
        }).ToList();

        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<Department> GetById(int id)
    {
        var department = _repository.GetById(id);
        if (department == null)
            return NotFound($"No department found with ID {id}");

        return Ok(department);
    }

    [HttpPost]
    public ActionResult<Department> Add(Department department)
    {
        _repository.Add(department);
        _repository.Save();
        return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Department department)
    {
        if (id != department.Id)
            return BadRequest("ID mismatch");

        var existing = _repository.GetById(id);
        if (existing == null) return NotFound();

        _repository.Update(department);
        _repository.Save();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var department = _repository.GetById(id);
        if (department == null) return NotFound();

        _repository.Delete(id);
        _repository.Save();
        return NoContent();
    }
}