using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    internal class FinalExam : Exam
    {
        public FinalExam(int time, Question[] questions, Subject subject) : base(time, questions, subject)
        {
        }
        public override void ShowExam()
        {
            Console.WriteLine($"Final Exam - Subject: {Subject}");
            foreach (var question in Questions)
            {
                question.Display();
                Console.WriteLine();
            }
        }
        public override void Finish()
        {
            base.Finish();
            Console.WriteLine("\n--- Student Answers ---");
            foreach (var kvp in QuestionAnswerDictionary)
            {
                Console.WriteLine("Question:");
                kvp.Key.Display();
                Console.WriteLine($"Student Answer: {kvp.Value}");
                Console.WriteLine();
            }

            int correctCount = CorrectExam();
            Console.WriteLine($"Final Grade: {correctCount}/{Questions.Length}");
        }
    }
}
