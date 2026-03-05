using System.Data.Common;

namespace Lab
{
    internal class Answer : IComparable<Answer>
    {
        int id;
        string text;
        public Answer(int id, string text)
        {
            this.id = id;
            this.text = text;
        }
        public int Id
        {
            get => id;
        }
        public string Text
        {
            get => text;
        }
        override public string ToString()
        {
            return $"{id}. {text}";
        }
        override public bool Equals(object obj)
        {
            if (obj is Answer)
            {
                Answer a = (Answer)obj;
                return this.id == a.id && this.text == a.text;
            }
            return false;
        }
        override public int GetHashCode()
        {
            return HashCode.Combine(id, text);
        }
        public int CompareTo(Answer? other)
        {
            if (other == null)
            {
                return 1;
            }
            return this.id.CompareTo(other.id);
        }
    }
}