using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1
{
    class Weapon : Item
    {
        public int Damage { get; set; }
        public enum WeaponType { Sword, TwoHandedSword, Axe, TwoHandedAxe, Polearm, Dagger, Stave, Bow, Gun, Crossbow, Wand }
        public WeaponType weaponType { get; set; }

        public Weapon(string name, string description, int level, int durability, int damage, ItemSlot itemSlot, WeaponType type, Dictionary<Stat, int> stats)
        {
            Id = System.Threading.Interlocked.Increment(ref idCounter);
            Name = name;
            Description = description;
            Level = level;
            Durability = durability;
            Damage = damage;
            Slot = itemSlot;
            weaponType = type;
            Stats = stats;
        }
    }
}
