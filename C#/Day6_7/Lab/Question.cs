namespace Lab
{
    abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public AnswerList Answers { get; set; }
        public AnswerList CorrectAnswer { get; set; }
        public Question(string header, string body, AnswerList answerList, AnswerList correctAnswer, int marks)
        {
            Header = header ?? "No Header";
            Body = body ?? "No Body";
            Answers = answerList;
            CorrectAnswer = correctAnswer;
            Marks = marks > 0 ? marks : 0;
        }
        public abstract void Display();
        public abstract bool CheckAnswer(AnswerList answers);
        public override bool Equals(object obj)
        {
            if (obj is Question q)
            {
                return Header == q.Header &&
                       Body == q.Body &&
                       Marks == q.Marks;
            }

            return false;
        }
        public override string ToString()
        {
            return $"{Header}\n{Body}\n{Answers}";
        }
    }
}