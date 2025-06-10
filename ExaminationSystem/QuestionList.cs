using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    /// <summary>Manages a list of questions and logs each added question to a file.</summary>
    public class QuestionList
    {
        private Question[] questions = new Question[50];
        private int count = 0;
        private string logFile = $"questions_{DateTime.Now.Ticks}.txt";

        public void Add(Question q)
        {
            if (count >= questions.Length) return;
            questions[count++] = q;

            File.AppendAllText(logFile, q.ToString() + Environment.NewLine);
        }

        public Question this[int index] => questions[index];
        public int Count => count;
    }
}
