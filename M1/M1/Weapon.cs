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

        public Weapon()
        {
            Name = "Ashkandi, Greatsword of the Brotherhood";
            weapon = WeaponType.Sword;
        }
    }
}
