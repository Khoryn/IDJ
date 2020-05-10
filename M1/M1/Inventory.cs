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

        public void AddItem(int id)
        {
            if (Database().Exists(item => (item.Id == id)))
            {
                Item item = GetItemById(id);
                inventory.Add(item);
                Console.WriteLine($"Added item to inventory : {item.Name}");
            }
            else
            {
                Console.WriteLine("Couldn't find item");
            }
        }

        public void RemoveItemById(int id)
        {
            Item item = GetItemById(id);

            if (item != null)
            {
                inventory.Remove(item);
                Console.WriteLine($"Removed item from inventory: {item.Name}");
            }
        }
    }
}
