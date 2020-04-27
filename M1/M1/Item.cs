using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1
{
    class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Durability { get; set; }
        public enum ItemType { Cloth, Leather, Mail, Plate }
        public ItemType Type { get; set; }
        public enum Stat { Intellect, Agility, Strengh, Stamina }

        public Dictionary<string, int> statistics = new Dictionary<string, int>();

        public Item(string name, string description, ItemType type, int durability, Dictionary<string, int> stats)
        {
            this.Name = name;
            this.Description = description;
            this.Durability = durability;
            this.Type = type;
            this.statistics = stats;
        }
    }
}
