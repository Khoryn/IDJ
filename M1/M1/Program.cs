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
            player.AddItemById(3);

            player.RemoveItemById(1);

            //player.SearchItemById(3);
            //player.SearchItemByName("Arcane Vest");

            //player.ViewInventory();

            player.EquipWeapon(1, Player.PlayerSlots.MainHand);
            player.EquipArmor(1, Player.PlayerSlots.Chest);
            player.EquipArmor(1, Player.PlayerSlots.Shoulders);
            player.EquipWeapon(3, Player.PlayerSlots.OffHand);
            player.EquipWeapon(2, Player.PlayerSlots.MainHand);

            Console.ReadKey();
        }
    }
}
