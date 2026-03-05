using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    internal class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Student(string Name, int Id)
        {
            this.Name = Name;
            this.Id = Id;
        }
    }
}
