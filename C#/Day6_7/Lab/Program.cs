namespace Lab;

class Program
{
    static void Main(string[] args)
    {

        // 1️⃣ Create a subject
        Subject programming = new Subject("Programming 101");

        // 2️⃣ Create students and enroll them
        Student student1 = new Student("Ali", 1);
        Student student2 = new Student("Sara", 2);
        programming.Enroll(student1);
        programming.Enroll(student2);

        // 3️⃣ Create exams
        Question[] practiceQuestions = new Question[]
        {
            new TrueOrFalseQuestion("C# is OOP?", "C# is object-oriented",
                new AnswerList(new Answer[] { new Answer(1,"True"), new Answer(2,"False") }),
                new AnswerList(new Answer[] { new Answer(1,"True") }), 5),

            new ChooseOneQuestion("Select the keyword for inheritance",
                "Which keyword is used for inheritance in C#?",
                new AnswerList(new Answer[] { new Answer(1,"extends"), new Answer(2,":") }),
                new AnswerList(new Answer[] { new Answer(2, ":") }), 5)
        };

        PracticeExam practiceExam = new PracticeExam(30, practiceQuestions, programming);

        Question[] finalQuestions = new Question[]
        {
            new ChooseAllQuestion("Select all value types in C#",
                "Choose all that are value types",
                new AnswerList(new Answer[] {
                    new Answer(1,"int"), new Answer(2,"string"), new Answer(3,"bool")
                }),
                new AnswerList(new Answer[] {
                    new Answer(1,"int"), new Answer(3,"bool")
                }),
                10),
            new ChooseOneQuestion("Select the keyword for inheritance",
                "Which keyword is used for inheritance in C#?",
                new AnswerList(new Answer[] { new Answer(1,"extends"), new Answer(2,":") }),
                new AnswerList(new Answer[] { new Answer(2, ":") }), 5)
        };

        FinalExam finalExam = new FinalExam(60, finalQuestions, programming);


        Console.WriteLine("Select Exam Type:");
        Console.WriteLine("1 - Practice Exam");
        Console.WriteLine("2 - Final Exam");
        string choice = Console.ReadLine();

        Exam selectedExam = null;

        if (choice == "1")
            selectedExam = practiceExam;
        else if (choice == "2")
            selectedExam = finalExam;
        else
        {
            Console.WriteLine("Invalid choice.");
            return;
        }


        selectedExam.Start();
        Console.WriteLine($"Exam Mode: {selectedExam.Mode}");

        Console.WriteLine("Notification: The exam has started!");

        foreach (var q in selectedExam.Questions)
        {
            Console.WriteLine($"Question: {q}");

            if (q is ChooseAllQuestion)
            {
                Console.Write("Enter all answer numbers separated by commas: ");
                string input = Console.ReadLine();
                var selected = input.Split(',').Select(n => q.Answers[int.Parse(n.Trim()) - 1]).ToArray();
                selectedExam.QuestionAnswerDictionary[q] = new AnswerList(selected);
            }
            else
            {
                Console.Write("Enter your answer number: ");
                int index = int.Parse(Console.ReadLine());
                selectedExam.QuestionAnswerDictionary[q] = new AnswerList(new Answer[] { q.Answers[index - 1] });
            }
        }

        selectedExam.Finish();
        Console.WriteLine($"Exam Mode: {selectedExam.Mode}");
    }
}
