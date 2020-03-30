using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retangulo
{
    class Program
    {
        static void Main(string[] args)
        {

            Rectangle rectangle = new Rectangle(10,12);

            Console.WriteLine(rectangle.Area());
            Console.WriteLine(rectangle.Perimeter());
            Console.WriteLine(rectangle.Square());
            Console.WriteLine(rectangle.ConvertToString());
            

            Console.ReadKey();
        }
    }
}
