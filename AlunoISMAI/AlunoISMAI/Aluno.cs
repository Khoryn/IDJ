using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlunoISMAI
{
    class Aluno
    {
        private string name;
        private string course;
        private int number;
        private int year;

        public Aluno(string n, int num, int y, string c)
        {
            name = n;
            number = num;
            year = y;
            course = c;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Course
        {
            get { return course; }
            set { course = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public string ConvertToString()
        {
            string value = name + " " + number + ", " + year + "º ano" + " " + course;

            return value;
        }

        public bool InscritoAntes(Aluno aluno)
        {
            if (this.number > aluno.number)
            {
                Console.WriteLine("O segundo aluno foi inscrito antes");
                return true;

            }
            else
            {
                Console.WriteLine("O segundo aluno foi inscrito depois");
                return false;
            }
        }
    }
}
