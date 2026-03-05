using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    internal class ChooseAllQuestion : Question
    {
        AnswerList correctAnswers;
        public ChooseAllQuestion(string header, string body, AnswerList answerList, AnswerList correctanswer, int marks)
            : base(header, body, answerList, null, marks)
        {
            this.correctAnswers = correctanswer;
        }

        public override bool CheckAnswer(AnswerList answers)
        {
            if (answers.Count != correctAnswers.Count)
                return false;

            for (int i = 0; i < correctAnswers.Count; i++)
            {
                if (!answers[i].Equals(correctAnswers[i]))
                    return false;
            }

            return true;
        }

        public override void Display()
        {
            Console.WriteLine(Header);
            Console.WriteLine(Body);
            Console.WriteLine(Answers);
        }
    }
}
