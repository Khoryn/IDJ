using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1
{
    class Inventory : ItemDatabase
    {
        private const int maximumSlots = 10;

        public List<Item> inventory = new List<Item>();

        public Inventory()
        {
            BuildDatabase();
        }

        public void AddItemById(int id)
        {
            if (inventory.Count < maximumSlots)
            {
                if (Database().Exists(item => (item.Id == id)))
                {
                    Item item = GetItemById(id);
                    inventory.Add(item);
                    Console.WriteLine($"Added {item.Name} to the inventory");
                }
                else
                {
                    Console.WriteLine("Couldn't find item");
                }
            }
            else
            {
                Console.WriteLine("The inventory is full!");
            }
        }

        public void AddItemByÑame(string name)
        {
            if (inventory.Count < maximumSlots)
            {
                if (Database().Exists(item => (item.Name == name)))
                {
                    Item item = GetItemByName(name);
                    inventory.Add(item);
                    Console.WriteLine($"Added {item.Name} to the inventory");
                }
                else
                {
                    Console.WriteLine("Couldn't find item");
                }
            }
            else
            {
                Console.WriteLine("The inventory is full!");
            }
        }

        public void RemoveItemById(int id)
        {
            Item item = GetItemById(id);
            if (inventory.Count > 0)
            {
                if (inventory.Exists(x => (x.Id == id)))
                {
                    inventory.Remove(item);
                    Console.WriteLine($"Removed {item.Name} from the inventory");
                }
                else
                {
                    Console.WriteLine("Couldn't find the item");
                }
            }
            else
            {
                Console.WriteLine("The inventory is empty!");
            }         
        }

        public void RemoveItemByName(string name)
        {
            Item item = GetItemByName(name);
            if (inventory.Count > 0)
            {
                if (inventory.Exists(x => (x.Name == name)))
                {
                    inventory.Remove(item);
                    Console.WriteLine($"Removed {item.Name} from the inventory");
                }
                else
                {
                    Console.WriteLine("Couldn't find the item");
                }
            }
            else
            {
                Console.WriteLine("The inventory is empty!");
            }
        }
    }
}
