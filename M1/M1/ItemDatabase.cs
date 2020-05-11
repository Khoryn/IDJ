using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1
{
    class ItemDatabase : Item
    {
        private List<Item> items = new List<Item>();

        /// <summary>
        /// Populate the database with various items(Weapons and armor).
        /// </summary>
        public void BuildDatabase()
        {
            items.Add(new Armor("Arcane Vest", "Worn by Archmage Khadgar during the second war.", 10, 75, 200, Armor.ArmorSlot.Chest, Armor.ArmorType.Cloth, new Dictionary<Stat, int>
            {
                {Stat.Intellect, 20},
                {Stat.Agility, 0},
                {Stat.Strengh, 0},
                {Stat.Stamina, 60}
            }));

            items.Add(new Weapon("Ashkandi, Greatsword of the Brotherhood", "This sword was wielded by Bronzebeard himself.", 25, 100, 100, Weapon.WeaponSlot.MainHand, Weapon.WeaponType.TwoHandedSword, new Dictionary<Stat, int>
            {
                {Stat.Intellect, 0},
                {Stat.Agility, 30},
                {Stat.Strengh, 60},
                {Stat.Stamina, 60}
            }));

            items.Add(new Weapon("Quel'Delar, Might of the Faithful", "The sister blade of Quel'Serrar.", 80, 100, 300, Weapon.WeaponSlot.OffHand, Weapon.WeaponType.Sword, new Dictionary<Stat, int>
            {
                {Stat.Intellect, 0},
                {Stat.Agility, 30},
                {Stat.Strengh, 80},
                {Stat.Stamina, 100}
            }));
        }

        /// <summary>
        /// Returns the items list
        /// </summary>
        public List<Item> Database()
        {
            return items;
        }

        /// <summary>
        /// Finds the item inside the database that corresponds to the given id.
        /// </summary>
        public Item GetItemById(int id)
        {
            return items.Find(item => item.Id == id);
        }

        /// <summary>
        /// Finds the item inside the database that corresponds to the given name.
        /// </summary>
        public Item GetItemByName(string name)
        {
            return items.Find(item => item.Name == name);
        }
    }
}
