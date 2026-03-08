using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    internal class ExamEventArgs
    {
        public Subject Subject { get; }
        public Exam Exam { get; }
        public ExamEventArgs(Subject subject, Exam exam)
        {
            Exam = exam;
            Subject = subject;
        }
    }
}
