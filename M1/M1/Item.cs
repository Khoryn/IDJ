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

        public enum Stat { Intellect, Agility, Strengh, Stamina }

        public Dictionary<Stat, int> Stats = new Dictionary<Stat, int>();

        public Item(int id, string name, string description, int level, int durability, Dictionary<Stat, int> stats)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Durability = durability;
            this.Level = level;
            this.Stats = stats;
        }

        public Item()
        {
            this.Id = 0;
            this.Name = "Default";
            this.Description = "Default";
            this.Durability = 0;
            this.Level = 0;
            this.Stats = new Dictionary<Item.Stat, int>
            {
                {Stat.Intellect, 0},
                {Stat.Agility, 0},
                {Stat.Strengh, 0},
                {Stat.Stamina, 0}
            };
        }
    }
}
