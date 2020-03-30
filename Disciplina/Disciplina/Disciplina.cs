using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disciplina
{
    class Disciplina
    {
        private bool semOrAnual;
        private string name;
        private string professorName;
        private string courseName;
        private int numberOfStudents;
        private int weeklyHours;

        public int WeeklyHours
        {
            get { return weeklyHours; }
            set
            {
                if (weeklyHours > 0 && weeklyHours <= 8)
                {
                    weeklyHours = value;
                }
            }
        }

        public int NumberOfStudents
        {
            get { return numberOfStudents; }
            set
            {
                if (numberOfStudents > 0)
                {
                    numberOfStudents = value;
                }
            }
        }
    }
}
