using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    internal class ChooseOneQuestion : Question
    {
        public ChooseOneQuestion(string header, string body, AnswerList answerList, AnswerList correctAnswer, int marks)
            : base(header, body, answerList, correctAnswer, marks)
        {
        }

        public override bool CheckAnswer(AnswerList answer)
        {
            if (answer.Count != 1)
                return false;
            return CorrectAnswer[0].Id == answer[0].Id;
        }

        public override void Display()
        {
            Console.WriteLine(Header);
            Console.WriteLine(Body);
            Console.WriteLine(Answers);
        }
    }
}
