﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1
{
    class ItemDatabase : Item
    {
        public List<Item> items = new List<Item>();

        public void BuildDatabase()
        {
            //items.Add(new Item());

            items.Add(new Item(0, "Arcane Vest", "Worn by Archmage Khadgar during the second war.", 10, 75, new Dictionary<Stat, int>
            {
                {Stat.Intellect, 20},
                {Stat.Agility, 0},
                {Stat.Strengh, 0},
                {Stat.Stamina, 60}
            }));

            items.Add(new Item(1, "Bloodsworn gloves", "Their color resembles the sands of Silithus.", 25, 100, new Dictionary<Stat, int>
            {
                {Stat.Intellect, 0},
                {Stat.Agility, 30},
                {Stat.Strengh, 60},
                {Stat.Stamina, 60}
            }));

            items.Add(new Weapon());

            foreach (Item item in items)
            {
                Console.WriteLine($"ID: {item.Id}\n Name: {item.Name}\n Description: {item.Description}\n Level: {item.Level} \n Durability: {item.Durability}\n Stats \n Intellect: {item.Stats[Item.Stat.Intellect]} \n Agility: {item.Stats[Item.Stat.Agility]} \n Strengh: {item.Stats[Item.Stat.Strengh]} \n Stamina: {item.Stats[Item.Stat.Stamina]} \n");
            }

            Console.WriteLine("The number of items in the database is " + items.Count);
        }

        public Item GetItemById(int id)
        {
            return items.Find(item => item.Id == id);
        }
    }
}