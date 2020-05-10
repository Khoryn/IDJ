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
            Player player = new Player();

            player.AddItemById(2);
            player.AddItemByÑame("Arcane Vest");
            player.AddItemByÑame("Arcane Vest");

            player.RemoveItemById(1);

            player.SearchItemById(1);
            player.SearchItemById(2);

            player.EquipWeapon(1);

            Console.ReadKey();
        }
    }
}
