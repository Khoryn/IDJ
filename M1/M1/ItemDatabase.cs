using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1
{
    class ItemDatabase
    {
        public List<Item> items = new List<Item>();

        public void BuildDatabase()
        {
            items.Add(new Item(0, "Arcane Vest", "Worn by Archmage Khadgar during the second war.", 10, 75, Item.ItemType.Cloth, new Dictionary<Item.Stat, int>
            {
                {Item.Stat.Intellect, 20},
                {Item.Stat.Agility, 0},
                {Item.Stat.Strengh, 0},
                {Item.Stat.Stamina, 60}
            }));

            items.Add(new Item(1, "Bloodsworn gloves", "Their color resembles the sands of Silithus.", 25, 100, Item.ItemType.Leather, new Dictionary<Item.Stat, int>
            {
                {Item.Stat.Intellect, 0},
                {Item.Stat.Agility, 30},
                {Item.Stat.Strengh, 60},
                {Item.Stat.Stamina, 60}
            }));

            foreach (Item item in items)
            {
                Console.WriteLine($"Name: {item.Name}\n Description: {item.Description}\n Level: {item.Level} \n Durability: {item.Durability}\n Type: {item.Type}\n Stats \n Intellect: {item.Stats[Item.Stat.Intellect]} \n Agility: {item.Stats[Item.Stat.Agility]} \n Strengh: {item.Stats[Item.Stat.Strengh]} \n Stamina: {item.Stats[Item.Stat.Stamina]} \n");
            }

            Console.WriteLine("The number of items in the database is " + items.Count);
        }

        public Item GetItemById(int id)
        {
            return items.Find(item => item.Id == id);
        }
    }
}
