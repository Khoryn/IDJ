using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Math
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                float n1 = float.Parse(command[0]);
                float n2 = float.Parse(command[1]);

                switch (command[2])
                {
                    case "Sum": Console.WriteLine(MathUtil.Sum(n1, n2)); break;
                    case "Subtract": Console.WriteLine(MathUtil.Subtract(n1, n2)); break;
                    case "Multiply": Console.WriteLine(MathUtil.Multiply(n1, n2)); break;
                    case "Divide": Console.WriteLine(MathUtil.Divide(n1, n2)); break;
                    case "Percentage": Console.WriteLine(MathUtil.Percentage(n1, n2)); break;
                }
                command = Console.ReadLine().Split();
            }
        }
    }
}
