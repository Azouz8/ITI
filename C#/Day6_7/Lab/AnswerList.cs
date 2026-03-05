namespace Lab
{
    internal class AnswerList
    {
        Answer[] answers;
        public AnswerList(Answer[] answers)
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
            Answer[] newAnswers = new Answer[answers.Length + 1];
            for (int i = 0; i < answers.Length; i++)
            {
                newAnswers[i] = answers[i];
            }
            newAnswers[answers.Length] = answer;
            answers = newAnswers;
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
            get { return answers.Length; }
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