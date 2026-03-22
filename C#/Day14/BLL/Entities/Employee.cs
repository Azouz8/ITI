using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    public class Employee
    {
        public Employee() { }
        public required  string Emp_id { get; set; }
        public required string Fname { get; set; }
        public string? Minit { get; set; }
        public required string Lname { get; set; }
        public required short Job_id { get; set; }
        public Byte? Job_lvl { get; set; }
        public required string Pub_id { get; set; }
        public required DateTime Hire_date { get; set; }
    }
}
