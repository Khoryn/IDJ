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

        /// <summary>
        /// Equip the player with a weapon from the inventory through it's id.
        /// </summary>
        public void EquipWeapon(int id)
        {
            Item item = GetItemById(id); // Get the selected item by it's id
            if (item is Weapon) 
            {
                Weapon weapon = (Weapon)item;
                Weapon newWeapon = (Weapon)item;
                if (item != null && inventory.Exists(x => x.Id == id))
                {
                    if (currentWeapon == null)
                    {
                        currentWeapon = weapon;
                        Console.WriteLine($"Equipped: {currentWeapon.Name}!");
                    }
                    else
                    {
                        weapon = (Weapon)currentWeapon;
                        currentWeapon = newWeapon;
                        Console.WriteLine($"Uniquipped {weapon.Name} and equipped {currentWeapon.Name}!");
                    }
                }
                else
                {
                    Console.WriteLine("Couldn't find the item");
                }
            }
            else
            {
                Console.WriteLine("Can't equip this item!");
            }
        }

        /// <summary>
        /// Equip the player with a piece of armor from the inventory through it's id.
        /// </summary>
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
