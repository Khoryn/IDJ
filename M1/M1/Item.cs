using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Durability { get; set; }
        public enum ItemType { Cloth, Leather, Mail, Plate }
        public ItemType Type { get; set; }
        public enum Stat { Intellect, Agility, Strengh, Stamina }

        public Dictionary<Stat, int> statistics = new Dictionary<Stat, int>();

        public Item(string name, string description, ItemType type, int durability, Dictionary<Stat, int> stats)
        {
            this.Name = name;
            this.Description = description;
            this.Durability = durability;
            this.Type = type;
            this.statistics = stats;
        }
    }
}
