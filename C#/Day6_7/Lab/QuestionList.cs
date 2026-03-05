using System;
using System.Collections.Generic;
using System.Text;

namespace Lab
{
    internal class QuestionList : List<Question>
    {
        private readonly string fileName;
        public QuestionList(string fileName)
        {
            this.fileName = fileName;
        }
        public new void Add(Question question)
        {
            base.Add(question);
            using (StreamWriter sw = new StreamWriter(fileName, append: true))
            {
                sw.WriteLine(question.ToString());
                sw.WriteLine();
            }
        }
    }
}
