using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1
{
    public class Item
    {
        public static int idCounter = 0;

        public int Id { get; set; }
        public int Level { get; set; }
        public int Durability { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public enum Stat { Intellect, Agility, Strengh, Stamina }
        public enum ItemSlot { MainHand, OffHand, Head, Neck, Shoulders, Back, Chest, Waist, Legs, Feet, Wrist, Hand, Finger, Trinket }
        public ItemSlot Slot { get; set; }

        public Dictionary<Stat, int> Stats = new Dictionary<Stat, int>();

        // Default status for items
        public Item()
        {
            Id = 0;
            Name = "Default";
            Description = "Default";
            Durability = 0;
            Level = 0;
            Slot = ItemSlot.Chest;
            Stats = new Dictionary<Item.Stat, int>
            {
                {Stat.Intellect, 0},
                {Stat.Agility, 0},
                {Stat.Strengh, 0},
                {Stat.Stamina, 0}
            };
        }
    }
}



