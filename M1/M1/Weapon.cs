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

        public enum WeaponSlot { MainHand, Offhand };
        public WeaponSlot weaponSlot;

        /// <summary>Weapon constructor.
        /// <para>Increments automatically the id.</para>
        /// <para>Set the weapon's name.</para>
        /// <para>Set the weapon's description.</para>
        /// <para>Set the weapon's level.</para>
        /// <para>Set the weapon's durability.</para>
        /// <para>Set the weapon's damage.</para>
        /// <para>Set the weapon's slot.</para>
        /// <para>Set the weapon's type.</para>
        /// <para>Set the weapon's stats.</para>
        /// </summary>
        public Weapon(string name, string description, int level, int durability, int damage, WeaponSlot slot, WeaponType type, Dictionary<Stat, int> stats)
        {
            Id = System.Threading.Interlocked.Increment(ref idCounter);
            Name = name;
            Description = description;
            Level = level;
            Durability = durability;
            Damage = damage;
            weaponSlot = slot;
            weaponType = type;
            Stats = stats;
        }
    }
}
