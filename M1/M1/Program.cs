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
            ItemDatabase database = new ItemDatabase();
            Inventory inventory = new Inventory();

            database.BuildDatabase();

            Console.ReadKey();
        }
    }
}
