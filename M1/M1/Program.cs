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
            player.AddItemById(1);

            player.RemoveItemById(1);

            player.SearchItemById(1);

            player.ViewInventory();

            player.EquipWeapon(2);

            Console.ReadKey();
        }
    }
}
