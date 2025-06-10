using ExaminationSystem;
using System;

class Program
{
    static void Main()
    {
        // Register students
        Student.Register(new Student("Ali"));
        Student.Register(new Student("Sara"));

        Console.Write("How many questions do you want? ");
        int questionCount = int.Parse(Console.ReadLine());

        QuestionList questionList = new();

        // Sample question preparation
        for (int i = 0; i < questionCount; i++)
        {
            if (i % 3 == 0)
                questionList.Add(new TrueFalse("TF Header", $"TF Q{i + 1}", 5, true));
            else if (i % 3 == 1)
                questionList.Add(new ChooseOne("CO Header", $"CO Q{i + 1}", 10, new[] { "A", "B", "C" }, 1));
            else
                questionList.Add(new ChooseAll("CA Header", $"CA Q{i + 1}", 15, new[] { "X", "Y", "Z" }, new[] { 0, 2 }));
        }

        Console.WriteLine("\nStart Exam...");
        Exam exam = new FinalExam(DateTime.Now, questionCount);
        exam.ShowExam(questionList);
        Console.WriteLine($"\nYour grade: {exam.Grade} from {exam.MarkOfExam}");
    }
}
