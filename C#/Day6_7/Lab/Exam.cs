using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    internal abstract class Exam : ICloneable, IComparable<Exam>
    {
        public int Time { get; set; }
        public int NoOfQuestions => Questions.Length;
        public Question[] Questions { get; set; }
        public Dictionary<Question, AnswerList> QuestionAnswerDictionary { get; set; }
        public Subject Subject { get; set; }
        public ExamMode Mode { get; set; }
        public Exam(int time, Question[] questions, Subject subject)
        {
            Time = time > 0 ? time : 0;
            Questions = questions ?? new Question[0];
            Subject = subject;
            Mode = ExamMode.Queued;
            QuestionAnswerDictionary = new Dictionary<Question, AnswerList>();
        }
        public abstract void ShowExam();
        public int CorrectExam()
        {
            int count = 0;
            foreach (var kvp in QuestionAnswerDictionary)
            {
                if (kvp.Key.CheckAnswer(kvp.Value))
                {
                    count++;
                }
            }
            return count;
        }
        public virtual void Start()
        {
            Mode = ExamMode.Starting;
            Console.WriteLine("Exam started!");
        }
        public virtual void Finish()
        {
            Mode = ExamMode.Finished;
            Console.WriteLine("Exam finished!");
        }
        public override string ToString()
        {
            return $"Subject: {Subject}\nTime: {Time} min\nNumber of Questions: {NoOfQuestions}\nMode: {Mode}";
        }

        // Override Equals
        public override bool Equals(object obj)
        {
            if (obj is Exam other)
            {
                return Time == other.Time &&
                       NoOfQuestions == other.NoOfQuestions &&
                       Subject.SubjectName.Equals(other.Subject.SubjectName);
            }
            return false;
        }

        public object Clone()
        {
            Question[] clonedQuestions = (Question[])Questions.Clone();
            Exam clonedExam = (Exam)this.MemberwiseClone();
            clonedExam.Questions = clonedQuestions;
            clonedExam.QuestionAnswerDictionary = new Dictionary<Question, AnswerList>();
            return clonedExam;
        }
        public int CompareTo(Exam other)
        {
            {
                if (other == null) return 1;

                int timeCompare = Time.CompareTo(other.Time);
                if (timeCompare != 0)
                    return timeCompare;

                return NoOfQuestions.CompareTo(other.NoOfQuestions);
            }
        }
    }
}
