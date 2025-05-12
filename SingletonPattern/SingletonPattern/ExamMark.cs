using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class ExamMark
    {
        public string StudentNumber { get; private set; }
        public string SubjectCode { get; private set; }
        public double Percantage { get; private set; }

        public ExamMark (string studentNumber, string subjectCode, double percantage)
        {
            StudentNumber = studentNumber;
            SubjectCode = subjectCode;
            Percantage = percantage;
        }
    }
}
