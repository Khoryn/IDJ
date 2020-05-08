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
        public enum WeaponType { Sword, Axe, Polearm, Dagger, Stave, Bow, Gun, Crossbow, Wand }
        public WeaponType weapon { get; set; }

        public Weapon(string name, string description, int level, int durability, int damage, ItemSlot itemSlot, Dictionary<Stat, int> stats)
        {
            this.Name = name;
            this.Description = description;
            this.Level = level;
            this.Durability = durability;
            this.Damage = damage;
            this.Slot = itemSlot;
            this.Stats = stats;
        }
    }
}
