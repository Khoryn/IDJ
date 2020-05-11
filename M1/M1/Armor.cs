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
        public enum ArmorSlot { Head, Neck, Shoulders, Back, Chest, Waist, Legs, Feet, Wrist, Hand, Finger, Trinket }
        public ArmorSlot armorSlot { get; set; }

        /// <summary>Weapon constructor.
        /// <para>Increments automatically the id.</para>
        /// <para>Set the armor's name.</para>
        /// <para>Set the armor's description.</para>
        /// <para>Set the armor's level.</para>
        /// <para>Set the armor's durability.</para>
        /// <para>Set the armor's defense.</para>
        /// <para>Set the armor's slot.</para>
        /// <para>Set the armor's type.</para>
        /// <para>Set the armor's stats.</para>
        /// </summary>
        public Armor(string name, string description, int level, int durability, int defense, ArmorSlot slot, ArmorType type, Dictionary<Stat, int> stats)
        {
            Id = System.Threading.Interlocked.Increment(ref idCounter);
            Name = name;
            Description = description;
            Level = level;
            Durability = durability;
            Defense = defense;
            armorSlot = slot;
            armorType = type;
            Stats = stats;
        }
    }
}
