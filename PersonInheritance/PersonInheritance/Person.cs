using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInheritance
{
    class Person
    {
        private string name;
        private int age;

        public virtual string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name’s length should not be less than 3 symbols!");
                }
                name = value;
            }
        }

        public virtual int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0 || value > 15)
                {
                    throw new ArgumentException("Age must be positive and less than 15!");
                }
                age = value;
            }
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Format("Name: {0}, Age: {1}",this.Name, this.Age));

            return stringBuilder.ToString();
        }
    }
}
