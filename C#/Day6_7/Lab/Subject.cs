using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    internal class Subject
    {
        public string SubjectName { get; set; }
        public List<Student> EnrolledStudents { get; set; } = new List<Student>();
        public Subject(string subject)
        {
            this.SubjectName = subject;
        }

        public void Enroll(Student student)
        {
            EnrolledStudents.Add(student);
        }
    }
}
