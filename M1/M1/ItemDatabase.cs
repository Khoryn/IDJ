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

        public void BuildDatabase()
        {
            items.Add(new Armor("Arcane Vest", "Worn by Archmage Khadgar during the second war.", 10, 75, 200, ItemSlot.Chest, Armor.ArmorType.Cloth, new Dictionary<Stat, int>
            {
                {Stat.Intellect, 20},
                {Stat.Agility, 0},
                {Stat.Strengh, 0},
                {Stat.Stamina, 60}
            }));

            items.Add(new Weapon("Ashkandi, Greatsword of the Brotherhood", "This sword was wielded by Bronzebeard himself.", 25, 100, 100, ItemSlot.MainHand, Weapon.WeaponType.Sword, new Dictionary<Stat, int>
            {
                {Stat.Intellect, 0},
                {Stat.Agility, 30},
                {Stat.Strengh, 60},
                {Stat.Stamina, 60}
            }));
        }

        public List<Item> Database()
        {
            return items;
        }

        public Item GetItemById(int id)
        {
            return items.Find(item => item.Id == id);
        }

        public Item GetItemByName(string name)
        {
            return items.Find(item => item.Name == name);
        }
    }
}
