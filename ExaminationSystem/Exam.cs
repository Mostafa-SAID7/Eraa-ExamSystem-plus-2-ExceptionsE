using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaminationSystem;

namespace ExaminationSystem
{
    /// <summary>Base Exam class containing common logic and fields.</summary>
    public abstract class Exam
    {
        public DateTime Time { get; set; }
        public int NumberOfQuestions { get; set; }
        public int Grade { get; protected set; }
        public int MarkOfExam { get; protected set; }
        public ExamMode Mode { get; protected set; }

        protected Dictionary<Question, Answer> QuestionAnswerMap = new();

        public Subject ExamSubject { get; set; }

        public Exam(DateTime time, int num)
        {
            Time = time;
            NumberOfQuestions = num;
            Mode = ExamMode.Starting;
        }

        public abstract void ShowExam(QuestionList list);
    }

    public class FinalExam : Exam
    {
        public FinalExam(DateTime time, int num) : base(time, num) { }

        public override void ShowExam(QuestionList list)
        {
            Mode = ExamMode.Starting;
            Student.NotifyAll();

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                var q = list[i];
                q.Display();
                Console.Write("Your answer: ");
                string answer = Console.ReadLine();

                Answer a = new(answer);
                QuestionAnswerMap[q] = a;

                if (q.CheckAnswer(answer))
                    Grade += q.Marks;

                MarkOfExam += q.Marks;
            }

            Mode = ExamMode.Finished;

            Console.WriteLine("\n=== Exam Finished ===");
            foreach (var pair in QuestionAnswerMap)
            {
                Console.WriteLine($"Q: {pair.Key.Body}\nYour Answer: {pair.Value.StudentAnswer}\n");
            }
        }
    }
}
