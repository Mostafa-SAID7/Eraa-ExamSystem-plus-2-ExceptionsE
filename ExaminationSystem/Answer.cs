using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    /// <summary>Represents a student's answer.</summary>
    public class Answer
    {
        public string StudentAnswer { get; set; }
        public Answer(string answer) => StudentAnswer = answer;
    }

    /// <summary>Represents a list of answers to questions.</summary>
    public class AnswerList
    {
        public Answer[] Answers = new Answer[50];
        public int Count = 0;

        public void AddAnswer(string answer)
        {
            Answers[Count++] = new Answer(answer);
        }

        public Answer this[int index] => Answers[index];
    }

}
