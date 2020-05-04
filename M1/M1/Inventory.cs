using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1
{
    class Inventory : ItemDatabase
    {
        public List<Item> inventory = new List<Item>();

        public void AddItem(int id) 
        {
            Item item = GetItemById(id);
            inventory.Add(item);
            Console.WriteLine($"Added item : {item.Name}");
        }

        public Item CheckForItemById(int id)
        {
            return inventory.Find(item => item.Id == id);
        }

        public void RemoveItemById(int id)
        {

        }
    }
}
