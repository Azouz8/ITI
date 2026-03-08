namespace Lab
{
    internal class AnswerList
    {
        List<Answer> answers;
        public AnswerList(List<Answer> answers)
        {
            this.answers = answers;
        }
        public Answer this[int index]
        {
            get
            {
                return answers[index];
            }
            set
            {
                answers[index] = value;
            }
        }
        public void addAnswer(Answer answer)
        {
            answers.Add(answer);
        }
        public Answer getAnswerById(int id)
        {
            foreach (Answer a in answers)
            {
                if (a.Id == id)
                {
                    return a;
                }
            }
            return null;
        }
        public int Count
        {
            get { return answers.Count; }
        }
        override public string ToString()
        {
            string result = "";
            foreach (Answer a in answers)
            {
                result += a.ToString() + "\n";
            }
            return result;
        }
    }
}