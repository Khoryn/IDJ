using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1
{
    class Player : Inventory
    {
        private Item currentWeapon;

        public Player()
        {
            Inventory inventory = new Inventory();
        }

        public void EquipWeapon(int id)
        {
            Item item = GetItemById(id);

            if (item is Weapon)
            {
                Weapon weapon = (Weapon)item;

                if (item != null)
                {
                    currentWeapon = weapon;
                    Console.WriteLine($"Equipped: {currentWeapon.Name}");
                }
            }
            else
            {
                Console.WriteLine("Can't equip this item!");
            }
        }

        public void EquipArmor(int id)
        {
            Item item = GetItemById(id);
            Armor armor = (Armor)item;

            if (true)
            {

            }
        }
    }
}
