using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Repositories;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IGenericRepository<Student> _studentRepo;
    private readonly IGenericRepository<Department> _deptRepo;

    public RolesController(
        UserManager<ApplicationUser> userManager,
        IGenericRepository<Student> studentRepo,
        IGenericRepository<Department> deptRepo)
    {
        _userManager = userManager;
        _studentRepo = studentRepo;
        _deptRepo = deptRepo;
    }

    [HttpGet("my-profile")]
    [Authorize(Roles = "Student")]
    public ActionResult GetMyProfile()
    {
        var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;

        var student = _studentRepo.GetAll().FirstOrDefault(s => s.Email == email);

        if (student == null) return NotFound();
        return Ok(student);
    }

    [HttpPost("add-student")]
    [Authorize(Roles = "Admin")]
    public ActionResult AddStudent(Student student)
    {
        _studentRepo.Add(student);
        _studentRepo.Save();
        return Ok("Student added successfully");
    }

    [HttpPost("add-department")]
    [Authorize(Roles = "Admin")]
    public ActionResult AddDepartment(Department department)
    {
        _deptRepo.Add(department);
        _deptRepo.Save();
        return Ok("Department added successfully");
    }
}