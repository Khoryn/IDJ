using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1
{
    class Inventory
    {
        List<Item> items = new List<Item>();

        public void AddItem()
        {
            items.Add(new Item("Arcane Vest", "Worn by Archmage Khadgar during the second war.", Item.ItemType.Cloth, 75,new Dictionary<string, int>
            {
                {$"{Item.Stat.Intellect}", 20},
                {$"{Item.Stat.Agility}", 0},
                {$"{Item.Stat.Strengh}", 0},
                {$"{Item.Stat.Stamina}", 60}
            }));

            items.Add(new Item("Bloodsworn gloves", "Their color resembles the sands of Silithus.", Item.ItemType.Leather, 100, new Dictionary<string, int>
            {
                {$"{Item.Stat.Intellect}", 0},
                {$"{Item.Stat.Agility}", 30},
                {$"{Item.Stat.Strengh}", 60},
                {$"{Item.Stat.Stamina}", 50}
            }));

            foreach (Item item in items)
            {
                Console.WriteLine($"Name: {item.Name}\n Description: {item.Description}\n Type: {item.Type}\n Durability: {item.Durability}\n Stats: {item.statistics.Keys} \n");
            }
        }
    }
}
