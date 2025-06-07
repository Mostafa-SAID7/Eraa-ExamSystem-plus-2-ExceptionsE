using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace ExaminationSystem
{
    /// <summary>
    /// Enum to represent the exam mode.
    /// </summary>
    public enum ExamMode { Starting, Finished }

    /// <summary>
    /// Represents a student who can receive notifications.
    /// </summary>
    public class Student
    {
        public string Name { get; set; }
        public Student(string name) => Name = name;
        public void Notify(string message) => Console.WriteLine($"{Name} was notified: {message}");
    }

    /// <summary>
    /// Represents the subject associated with an exam.
    /// </summary>
    public class Subject
    {
        public string Name { get; set; }
        public Student[] Students;
        public event Action<string> ExamStarted;

        public Subject(string name, Student[] students)
        {
            Name = name;
            Students = students;
            foreach (var student in Students)
                ExamStarted += student.Notify;
        }

        public void NotifyExamStart() => ExamStarted?.Invoke($"Exam for {Name} has started.");
    }

    /// <summary>
    /// Base class for all questions.
    /// </summary>
    public abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public AnswerList Answers { get; set; }

        protected Question(string header, string body, int marks)
        {
            Header = header;
            Body = body;
            Marks = marks;
            Answers = new AnswerList();
        }

        public abstract void Display();

        public abstract object Clone();

        public override string ToString() => $"{Header}: {Body} ({Marks} Marks)";

        public override bool Equals(object obj) => obj is Question q && q.Body == Body;

        public override int GetHashCode() => Body.GetHashCode();

        public int CompareTo(Question other) => Marks.CompareTo(other.Marks);
    }

    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int marks) : base(header, body, marks) { }

        public override void Display()
        {
            Console.WriteLine($"{Header}\n{Body}\n1. True\n2. False");
        }

        public override object Clone() => new TrueFalseQuestion(Header, Body, Marks);
    }

    public class ChooseOneQuestion : Question
    {
        public string[] Options;

        public ChooseOneQuestion(string header, string body, int marks, string[] options) : base(header, body, marks)
        {
            Options = options;
        }

        public override void Display()
        {
            Console.WriteLine($"{Header}\n{Body}");
            for (int i = 0; i < Options.Length; i++)
                Console.WriteLine($"{i + 1}. {Options[i]}");
        }

        public override object Clone() => new ChooseOneQuestion(Header, Body, Marks, (string[])Options.Clone());
    }

    public class ChooseAllQuestion : Question
    {
        public string[] Options;

        public ChooseAllQuestion(string header, string body, int marks, string[] options) : base(header, body, marks)
        {
            Options = options;
        }

        public override void Display()
        {
            Console.WriteLine($"{Header}\n{Body}");
            for (int i = 0; i < Options.Length; i++)
                Console.WriteLine($"{i + 1}. {Options[i]}");
        }

        public override object Clone() => new ChooseAllQuestion(Header, Body, Marks, (string[])Options.Clone());
    }

    /// <summary>
    /// Represents a list of questions with file logging.
    /// </summary>
    public class QuestionList
    {
        private Question[] questions;
        private int count;
        private string filePath;

        public QuestionList(int size, string file)
        {
            questions = new Question[size];
            filePath = file;
            count = 0;
        }

        public void Add(Question q)
        {
            if (count < questions.Length)
            {
                questions[count++] = q;
                File.AppendAllText(filePath, q.ToString() + Environment.NewLine);
            }
        }

        public Question this[int index] => questions[index];

        public int Count => count;
    }

    /// <summary>
    /// Represents a single answer.
    /// </summary>
    public class Answer
    {
        public string Value { get; set; }
        public Answer(string value) => Value = value;
        public override string ToString() => Value;
    }

    /// <summary>
    /// Represents a list of answers.
    /// </summary>
    public class AnswerList
    {
        private Answer[] answers = new Answer[10];
        private int count = 0;

        public void Add(Answer answer)
        {
            if (count < answers.Length)
                answers[count++] = answer;
        }

        public Answer this[int index] => answers[index];
        public int Count => count;
    }

    /// <summary>
    /// Base exam class.
    /// </summary>
    public abstract class Exam
    {
        public int Time { get; set; }
        public int QuestionCount { get; set; }
        public Dictionary<Question, AnswerList> QuestionAnswers { get; set; }
        public Subject Subject { get; set; }
        public ExamMode Mode { get; set; }

        protected Exam(int time, int qCount, Subject subject)
        {
            Time = time;
            QuestionCount = qCount;
            Subject = subject;
            QuestionAnswers = new Dictionary<Question, AnswerList>();
        }

        public abstract void Show();
    }

    /// <summary>
    /// Final exam class that shows answers after finishing.
    /// </summary>
    public class FinalExam : Exam
    {
        public FinalExam(int time, int qCount, Subject subject) : base(time, qCount, subject) { }

        public override void Show()
        {
            if (Mode == ExamMode.Starting)
                Subject.NotifyExamStart();
            else
            {
                foreach (var kv in QuestionAnswers)
                {
                    kv.Key.Display();
                    Console.WriteLine("Correct Answers:");
                    for (int i = 0; i < kv.Value.Count; i++)
                        Console.WriteLine(kv.Value[i]);
                }
            }
        }
    }

    /// <summary>
    /// Main program to test the exam system.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[]
            {
                new Student("Alice"),
                new Student("Bob")
            };
            Subject math = new Subject("Math", students);

            QuestionList questions = new QuestionList(3, "math_questions.txt");
            var q1 = new TrueFalseQuestion("Q1", "2 is even?", 1);
            q1.Answers.Add(new Answer("True"));
            questions.Add(q1);

            var q2 = new ChooseOneQuestion("Q2", "Best programming language?", 2, new string[] { "C#", "Python", "Java" });
            q2.Answers.Add(new Answer("C#"));
            questions.Add(q2);

            var exam = new FinalExam(60, 2, math);
            exam.QuestionAnswers.Add(q1, q1.Answers);
            exam.QuestionAnswers.Add(q2, q2.Answers);

            exam.Mode = ExamMode.Starting;
            exam.Show();
            Console.WriteLine("\n--- Exam Finished ---\n");
            exam.Mode = ExamMode.Finished;
            exam.Show();
        }
    }
}
