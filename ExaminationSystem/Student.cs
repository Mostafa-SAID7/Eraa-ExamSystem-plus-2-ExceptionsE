using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    /// <summary>Represents a student who gets notified when exam starts.</summary>
    public class Student
    {
        public string Name { get; set; }

        public Student(string name) => Name = name;

        public void OnExamStarted()
        {
            Console.WriteLine($"Student {Name} has been notified: Exam Started!");
        }

        public static List<Student> AllStudents = new();
        public static event Action ExamStarted;

        public static void Register(Student s) => AllStudents.Add(s);

        public static void NotifyAll() => ExamStarted?.Invoke();

        static Student()
        {
            ExamStarted += () =>
            {
                foreach (var s in AllStudents)
                    s.OnExamStarted();
            };
        }
    }
}
