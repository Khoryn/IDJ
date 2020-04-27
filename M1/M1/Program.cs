using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            inventory.AddItem();

            Console.ReadKey();
        }
    }
}
