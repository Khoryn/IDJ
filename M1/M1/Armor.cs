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
        public enum ArmorType { Cloth, Leather, Mail, Plate }
        public ArmorType armor { get; set; }

        public Armor()
        {
            Name = "Pauldrons of Might";
            armor = ArmorType.Plate;
        }
    }
}
