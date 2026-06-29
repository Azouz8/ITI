using SQLite;

namespace Day3Task.Models
{
    public class Department
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}