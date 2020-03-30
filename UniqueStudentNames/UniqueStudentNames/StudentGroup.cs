using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueStudentNames
{
    class StudentGroup
    {
        public static HashSet<string> students = new HashSet<string>();


        public static void ReceiveNames()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                Student newStudent = new Student(command);
                students.Add(newStudent.name);
                command = Console.ReadLine();
            }
            Console.WriteLine("Unique student names :" + students.Count);
        }
    }
}
