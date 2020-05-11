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

        #region Add Items
       
        public void AddItemById(int id)
        {
            if (inventory.Count < maximumSlots)
            {
                if (Database().Exists(item => item.Id == id))
                {
                    Item item = GetItemById(id);
                    inventory.Add(item);
                    Console.WriteLine($"Added {item.Name} to the inventory \n");
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
                    Console.WriteLine($"Added {item.Name} to the inventory \n");
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
        #endregion

        #region Remove items
        public void RemoveItemById(int id)
        {
            Item item = GetItemById(id);
            if (inventory.Count > 0)
            {
                if (inventory.Exists(x => (x.Id == id)))
                {
                    inventory.Remove(item);
                    Console.WriteLine($"Removed {item.Name} from the inventory \n");
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
                    Console.WriteLine($"Removed {item.Name} from the inventory \n");
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
        #endregion

        #region Search items
        public void SearchItemById(int id)
        {
            if (inventory.Exists(item => item.Id == id))
            {
                Item item = GetItemById(id);

                if (item is Weapon)
                {
                    Weapon weapon = (Weapon)item;

                    Console.WriteLine($" ID: {weapon.Id}\n Name: {weapon.Name}\n Description: {weapon.Description}\n " +
                        $"Level: {weapon.Level} \n Durability: {weapon.Durability} \n Damage : {weapon.Damage}\n " +
                        $"Slot: {weapon.Slot} \n Type: {weapon.weaponType} \n " +
                        $"Stats \n Intellect: {weapon.Stats[Stat.Intellect]} " +
                        $"\n Agility: {weapon.Stats[Stat.Agility]} \n Strengh: {weapon.Stats[Stat.Strengh]} \n Stamina: {weapon.Stats[Stat.Stamina]} \n");
                }
                else if (item is Armor)
                {
                    Armor armor = (Armor)item;

                    Console.WriteLine($" ID: {armor.Id}\n Name: {armor.Name}\n Description: {armor.Description}\n " +
                        $"Level: {armor.Level} \n Durability: {armor.Durability} \n Defense : {armor.Defense}\n " +
                        $"Slot: {armor.Slot} \n Type: {armor.armorType} \n " +
                        $"Stats \n Intellect: {armor.Stats[Stat.Intellect]} " +
                        $"\n Agility: {armor.Stats[Stat.Agility]} \n Strengh: {armor.Stats[Stat.Strengh]} \n Stamina: {armor.Stats[Stat.Stamina]} \n");
                }
            }
            else
            {
                Console.WriteLine("Couldn't find the item");
            }
        }

        public void SearchItemByName(string name)
        {
            if (inventory.Exists(item => item.Name == name))
            {
                Item item = GetItemByName(name);

                if (item is Weapon)
                {
                    Weapon weapon = (Weapon)item;

                    Console.WriteLine($" ID: {weapon.Id}\n Name: {weapon.Name}\n Description: {weapon.Description}\n " +
                        $"Level: {weapon.Level} \n Durability: {weapon.Durability} \n Damage : {weapon.Damage}\n " +
                        $"Slot: {weapon.Slot} \n Type: {weapon.weaponType} \n " +
                        $"Stats \n Intellect: {weapon.Stats[Stat.Intellect]} " +
                        $"\n Agility: {weapon.Stats[Stat.Agility]} \n Strengh: {weapon.Stats[Stat.Strengh]} \n Stamina: {weapon.Stats[Stat.Stamina]} \n");
                }
                else if (item is Armor)
                {
                    Armor armor = (Armor)item;

                    Console.WriteLine($" ID: {armor.Id}\n Name: {armor.Name}\n Description: {armor.Description}\n " +
                        $"Level: {armor.Level} \n Durability: {armor.Durability} \n Defense : {armor.Defense}\n " +
                        $"Slot: {armor.Slot} \n Type: {armor.armorType} \n " +
                        $"Stats \n Intellect: {armor.Stats[Stat.Intellect]} " +
                        $"\n Agility: {armor.Stats[Stat.Agility]} \n Strengh: {armor.Stats[Stat.Strengh]} \n Stamina: {armor.Stats[Stat.Stamina]} \n");
                }
            }
            else
            {
                Console.WriteLine("Couldn't find the item");
            }
        }

        public void ViewInventory()
        {
            List<Item> sortedInventory = inventory.OrderBy(item => item.Id).ToList();

            foreach (Item item in sortedInventory)
            {
                if (item is Weapon)
                {
                    Weapon weapon = (Weapon)item;

                    Console.WriteLine($" ID: {weapon.Id}\n Name: {weapon.Name}\n Description: {weapon.Description}\n " +
                        $"Level: {weapon.Level} \n Durability: {weapon.Durability} \n Damage : {weapon.Damage}\n " +
                        $"Slot: {weapon.Slot} \n Type: {weapon.weaponType} \n " +
                        $"Stats \n Intellect: {weapon.Stats[Stat.Intellect]} " +
                        $"\n Agility: {weapon.Stats[Stat.Agility]} \n Strengh: {weapon.Stats[Stat.Strengh]} \n Stamina: {weapon.Stats[Stat.Stamina]} \n");
                }
                else if (item is Armor)
                {
                    Armor armor = (Armor)item;

                    Console.WriteLine($" ID: {armor.Id}\n Name: {armor.Name}\n Description: {armor.Description}\n " +
                        $"Level: {armor.Level} \n Durability: {armor.Durability} \n Defense : {armor.Defense}\n " +
                        $"Slot: {armor.Slot} \n Type: {armor.armorType} \n " +
                        $"Stats \n Intellect: {armor.Stats[Stat.Intellect]} " +
                        $"\n Agility: {armor.Stats[Stat.Agility]} \n Strengh: {armor.Stats[Stat.Strengh]} \n Stamina: {armor.Stats[Stat.Stamina]} \n");
                }
            }
        }
        #endregion
    }
}
