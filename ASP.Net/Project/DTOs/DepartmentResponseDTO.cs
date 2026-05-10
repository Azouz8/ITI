using Project.Models;

namespace Project.DTOs
{
    public class DepartmentResponseDTO
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public List<string> ListOfStudentsNames { get; set; }
        public int StudentsCount { get; set; }
        public string Message { get; set; }
    }
}
