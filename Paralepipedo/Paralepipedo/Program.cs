using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paralepipedo
{
    class Program
    {
        static void Main(string[] args)
        {
            Paralepipedo para = new Paralepipedo(10,24,16);

            Console.WriteLine("The volume is " + para.Volume());
            Console.WriteLine("The total area is " + para.TotalArea());
            Console.WriteLine(para.ConvertToString());
            Console.WriteLine(para.IsACube());
            Console.WriteLine(para.Is3D());

            Console.ReadKey();
        }
    }
}
