using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Person
    {
        public string name;
        public int age;

        public Person()
        {
            name = "No name";
            age = 1;
        }

        public Person(int a)
        {
            name = "No name";
            age = a;
        }

        public Person(string n, int a)
        {
            name = n;
            age = a;
        }
    }
}
