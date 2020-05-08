using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1
{
    class Armor : Item
    {
        public int Defense { get; set; }
        public enum ArmorType { Plate, Mail, Leather, Cloth }
        public ArmorType armor { get; set; }

        public Armor(string name, string description, int level, int durability, int defense, ItemSlot itemSlot, Dictionary<Stat, int> stats)
        {
            this.Name = name;
            this.Description = description;
            this.Level = level;
            this.Durability = durability;
            this.Defense = defense;
            this.Slot = itemSlot;
            this.Stats = stats;
        }
    }
}
