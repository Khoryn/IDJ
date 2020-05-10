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

            inventory.AddItemById(2);
            inventory.AddItemByÑame("Arcane Vest");
            inventory.AddItemByÑame("Arcane Vest");

            inventory.RemoveItemById(1);

            inventory.SearchItemById(1);
            inventory.SearchItemById(2);

            Console.ReadKey();
        }
    }
}
