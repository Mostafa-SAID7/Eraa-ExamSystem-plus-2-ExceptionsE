using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    
        /// <summary>Abstract base class for all types of questions.</summary>
        public abstract class Question : ICloneable, IComparable<Question>
        {
            public string Header { get; set; }
            public string Body { get; set; }
            public int Marks { get; set; }

            public Question(string header, string body, int marks)
            {
                Header = header;
                Body = body;
                Marks = marks;
            }

            public abstract void Display();
            public abstract bool CheckAnswer(string input);

            public abstract object Clone();
            public virtual int CompareTo(Question other) => Marks.CompareTo(other.Marks);
            public override string ToString() => $"{Header}: {Body} ({Marks} Marks)";
            public override bool Equals(object obj) => obj is Question q && Header == q.Header;
            public override int GetHashCode() => Header.GetHashCode();
        }

        public class TrueFalse : Question
        {
            public bool CorrectAnswer { get; set; }

            public TrueFalse(string header, string body, int marks, bool correctAnswer)
                : base(header, body, marks)
            {
                CorrectAnswer = correctAnswer;
            }

            public override void Display() => Console.WriteLine($"{Header}\n{Body}\n(True / False)");

            public override bool CheckAnswer(string input) =>
                bool.TryParse(input, out var result) && result == CorrectAnswer;

            public override object Clone() => new TrueFalse(Header, Body, Marks, CorrectAnswer);
        }

        public class ChooseOne : Question
        {
            public string[] Options;
            public int CorrectIndex;

            public ChooseOne(string header, string body, int marks, string[] options, int correctIndex)
                : base(header, body, marks)
            {
                Options = options;
                CorrectIndex = correctIndex;
            }

            public override void Display()
            {
                Console.WriteLine($"{Header}\n{Body}");
                for (int i = 0; i < Options.Length; i++)
                    Console.WriteLine($"{i + 1}. {Options[i]}");
            }

            public override bool CheckAnswer(string input) =>
                int.TryParse(input, out int index) && index - 1 == CorrectIndex;

            public override object Clone() =>
                new ChooseOne(Header, Body, Marks, (string[])Options.Clone(), CorrectIndex);
        }

        public class ChooseAll : Question
        {
            public string[] Options;
            public int[] CorrectIndices;

            public ChooseAll(string header, string body, int marks, string[] options, int[] correctIndices)
                : base(header, body, marks)
            {
                Options = options;
                CorrectIndices = correctIndices;
            }

            public override void Display()
            {
                Console.WriteLine($"{Header}\n{Body}");
                for (int i = 0; i < Options.Length; i++)
                    Console.WriteLine($"{i + 1}. {Options[i]}");
            }

            public override bool CheckAnswer(string input)
            {
                var answers = input.Split(',').Select(x => int.Parse(x.Trim()) - 1).ToArray();
                return answers.OrderBy(i => i).SequenceEqual(CorrectIndices.OrderBy(i => i));
            }

            public override object Clone() =>
                new ChooseAll(Header, Body, Marks, (string[])Options.Clone(), (int[])CorrectIndices.Clone());
        }   
    }

