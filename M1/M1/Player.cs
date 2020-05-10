using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1
{
    class Player : Inventory
    {
        public enum PlayerArmorType { Plate, Mail, Leather, Cloth }
        public PlayerArmorType playerArmor { get; set; }

        // Create dictionary for equipping items/ Dictionary<Slot, Item> ?? 

        public void EquipWeapon()
        {
            // Equip if weapon type matches
        }

        public void EquipArmor() 
        {
            // Equip if armor type matches
        }
    }
}
