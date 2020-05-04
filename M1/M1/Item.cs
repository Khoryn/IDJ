using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Durability { get; set; }
        public int Level { get; set; }
        public enum ItemType { Cloth, Leather, Mail, Plate }
        public ItemType Type { get; set; }
        public enum Stat { Intellect, Agility, Strengh, Stamina }

        public Dictionary<Stat, int> Stats = new Dictionary<Stat, int>();

        public Item(int id, string name, string description, int level, int durability, ItemType type, Dictionary<Stat, int> stats)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Durability = durability;
            this.Level = level;
            this.Type = type;
            this.Stats = stats;
        }
    }
}
