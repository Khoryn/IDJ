using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1
{
    class Inventory
    {
        List<Item> inventory = new List<Item>();

        public Item[] itemList = new Item[20];

        public void AddItem()
        {
            //for (int i = 0; i < itemList.Length; i++)
            //{
            //    if (itemList[i] == null)
            //    {
            //        itemList[i] = item;
            //    }
            //}

            inventory.Add(new Item("Arcane Vest", "Worn by Archmage Khadgar during the second war.", Item.ItemType.Cloth, 75,new Dictionary<Item.Stat, int>
            {
                {Item.Stat.Intellect, 20},
                {Item.Stat.Agility, 0},
                {Item.Stat.Strengh, 0},
                {Item.Stat.Stamina, 60}
            }));

            inventory.Add(new Item("Bloodsworn gloves", "Their color resembles the sands of Silithus.", Item.ItemType.Leather, 100, new Dictionary<Item.Stat, int>
            {
                {Item.Stat.Intellect, 0},
                {Item.Stat.Agility, 30},
                {Item.Stat.Strengh, 60},
                {Item.Stat.Stamina, 60}
            }));

            foreach (Item item in inventory)
            {
                Console.WriteLine($"Name: {item.Name}\n Description: {item.Description}\n Type: {item.Type}\n Durability: {item.Durability}\n Stats: \n Intellect: {item.statistics[Item.Stat.Intellect]} \n Agility: {item.statistics[Item.Stat.Agility]} \n Strengh: {item.statistics[Item.Stat.Strengh]} \n Stamina: {item.statistics[Item.Stat.Stamina]} \n");
            }
        }
    }
}
