using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    /// <summary>Simple class for subject information.</summary>
    public class Subject
    {
        public string SubjectName { get; set; }
        public Subject(string name) => SubjectName = name;
    }
    
}
