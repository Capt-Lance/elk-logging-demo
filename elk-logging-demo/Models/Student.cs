using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elk_logging_demo.Models
{
    public class Student
    {
        public string StudentId { get; private set; }
        public string First { get; private set; }
        public string Last { get; private set; }

        public Student(string studentId, string first, string last)
        {
            StudentId = studentId;
            First = first;
            Last = last;
        }
    }
}
