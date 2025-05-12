using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            MarksManager First = MarksManager.GetInstance();
            MarksManager Second = MarksManager.GetInstance();
            First.CaptureMark(new ExamMark("225041308", "IENT301", 52));
            Second.CaptureMark(new ExamMark("224295592", "IRUD301", 75));
            First.CalculationMode(true);
            Console.WriteLine(Second.CalculateStudent("224295592"));
            Console.ReadLine();
        }
    }
}
