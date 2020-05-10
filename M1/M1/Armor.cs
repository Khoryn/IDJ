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
        public ArmorType armorType { get; set; }

        public Armor(string name, string description, int level, int durability, int defense, ItemSlot itemSlot, ArmorType type , Dictionary<Stat, int> stats)
        {
            Id = System.Threading.Interlocked.Increment(ref idCounter);
            Name = name;
            Description = description;
            Level = level;
            Durability = durability;
            Defense = defense;
            Slot = itemSlot;
            armorType = type;
            Stats = stats;
        }
    }
}
