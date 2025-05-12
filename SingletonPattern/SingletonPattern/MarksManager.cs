using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class MarksManager
    {
        private static volatile MarksManager myMarkManager = null;
        private static readonly object MyLock = new object();
        private bool Mode = false;
        private List<ExamMark> Marks = new List<ExamMark>();
        private MarksManager() { }
        public static MarksManager GetInstance()
        {
            if (myMarkManager == null)
            {
                lock (MyLock)
                {
                    if (myMarkManager == null)
                        myMarkManager = new MarksManager();
                }
            }
            return myMarkManager;
        }
        public void CalculationMode(bool Target)
        {
            this.Mode = Target;
        }
        public void CaptureMark(ExamMark Target)
        {
            if (!Mode)
                Marks.Add(Target);
        }
        public double CalculateStudent(string StudentNumber)
        {
            double Average = -1;
            if (Mode)
            {
                double Total = 0;
                int Count = 0;
                foreach(ExamMark Current in Marks)
                {
                    if (Current.StudentNumber == StudentNumber)
                    {
                        Total += Current.Percantage;
                        Count++;
                    }
                }
                Average = Total / Count;
            }
            return Average;
        }
    }
}
