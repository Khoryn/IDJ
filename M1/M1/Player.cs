using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1
{
    class Player : Inventory
    {
        public enum PlayerSlots { MainHand, OffHand, Head, Neck, Shoulders, Back, Chest, Waist, Legs, Feet, Wrist, Hand, Finger, Trinket }
        public PlayerSlots slots { get; set; }

        private Item currentWeapon;
        private Item currentArmor;

        public Player()
        {
            Inventory inventory = new Inventory();
        }

        /// <summary>
        /// Equip the player with a weapon from the inventory through it's id.
        /// </summary>
        public void EquipWeapon(int id, PlayerSlots slot)
        {
            Item item = GetItemById(id);
            if (item is Weapon)
            {
                Weapon weapon = (Weapon)item;
                Weapon newWeapon = (Weapon)item;

                if (item != null && inventory.Exists(i => i.Id == id))
                {
                    if (currentWeapon == null)
                    {
                        if (weapon.weaponSlot.ToString() == slot.ToString())
                        {
                            currentWeapon = weapon;
                            Console.WriteLine($"Equipped: {currentWeapon.Name}!");
                        }
                        else
                        {
                            Console.WriteLine("Can't equip in this slot");
                        }
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
                    Console.WriteLine("Couldn't find the item in the inventory!");
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
        public void EquipArmor(int id, PlayerSlots slot)
        {
            Item item = GetItemById(id);

            if (item != null && inventory.Exists(i => i.Id == id))
            {
                if (item is Armor)
                {
                    Armor armor = (Armor)item;

                    if (armor.armorSlot.ToString() == slot.ToString())
                    {
                        currentArmor = armor;
                        inventory.Remove(currentArmor);
                        Console.WriteLine($"Equipped: {currentArmor.Name}!");
                    }
                    else
                    {
                        Console.WriteLine("Can't equip in this slot");
                    }
                }
            }
            else
            {
                Console.WriteLine("Couldn't find the item in the inventory!");
            }
        }
    }
}
