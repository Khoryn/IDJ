using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1
{
    class Weapon : Item
    {
        public enum WeaponType { Cloth, Leather, Mail, Plate }
        public WeaponType weapon { get; set; }

        public Weapon()
        {
            Name = "Ashkandi, Greatsword of the Brotherhood";
        }
    }
}
