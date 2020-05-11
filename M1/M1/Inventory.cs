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

        /// <summary>
        /// Adds an item to the inventory through it's id.
        /// </summary>
        public void AddItemById(int id)
        {
            if (inventory.Count < maximumSlots) // Checks if the inventory isn't full
            {
                if (Database().Exists(item => item.Id == id)) // Check if the item exists inside the database
                {
                    Item item = GetItemById(id); // Get the selected item by it's id
                    inventory.Add(item); // Add the item to the inventory
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

        /// <summary>
        /// Adds an item to the inventory through it's name.
        /// </summary>
        public void AddItemByÑame(string name)
        {
            if (inventory.Count < maximumSlots) // Checks if the inventory isn't full
            {
                if (Database().Exists(item => (item.Name == name))) // Check if the item exists inside the database
                {
                    Item item = GetItemByName(name); // Get the selected item by it's name
                    inventory.Add(item); // Add the item to the inventory
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

        /// <summary>
        /// Removes an item from the inventory through it's id.
        /// </summary>
        public void RemoveItemById(int id)
        {
            Item item = GetItemById(id); // Get the selected item by it's id
            if (inventory.Count > 0) // Checks if the inventory isn't empty
            {
                if (inventory.Exists(x => (x.Id == id))) // Check if the item exists inside the inventory
                {
                    inventory.Remove(item); // Remove the item from the inventory
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

        /// <summary>
        /// Removes an item from the inventory through it's name.
        /// </summary>
        public void RemoveItemByName(string name)
        {
            Item item = GetItemByName(name); // Get the selected item by it's name
            if (inventory.Count > 0) // Checks if the inventory isn't empty
            {
                if (inventory.Exists(x => (x.Name == name))) // Check if the item exists inside the inventory
                {
                    inventory.Remove(item); // Remove the item from the inventory
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

        /// <summary>
        /// Searches for an item inside the inventory that corresponds to the given id.
        /// </summary>
        public void SearchItemById(int id)
        {
            if (inventory.Exists(item => item.Id == id)) // Check if the item exists inside the inventory
            {
                Item item = GetItemById(id); // Get the selected item by it's id

                if (item is Weapon)
                {
                    Weapon weapon = (Weapon)item; // Downcast (turn the base class into a more specific class)

                    Console.WriteLine($" ID: {weapon.Id}\n Name: {weapon.Name}\n Description: {weapon.Description}\n " +
                        $"Level: {weapon.Level} \n Durability: {weapon.Durability} \n Damage : {weapon.Damage}\n " +
                        $"Slot: {weapon.weaponSlot} \n Type: {weapon.weaponType} \n " +
                        $"Stats \n Intellect: {weapon.Stats[Stat.Intellect]} " +
                        $"\n Agility: {weapon.Stats[Stat.Agility]} \n Strengh: {weapon.Stats[Stat.Strengh]} \n Stamina: {weapon.Stats[Stat.Stamina]} \n");
                }
                else if (item is Armor)
                {
                    Armor armor = (Armor)item; // Downcast (turn the base class into a more specific class)

                    Console.WriteLine($" ID: {armor.Id}\n Name: {armor.Name}\n Description: {armor.Description}\n " +
                        $"Level: {armor.Level} \n Durability: {armor.Durability} \n Defense : {armor.Defense}\n " +
                        $"Slot: {armor.armorSlot} \n Type: {armor.armorType} \n " +
                        $"Stats \n Intellect: {armor.Stats[Stat.Intellect]} " +
                        $"\n Agility: {armor.Stats[Stat.Agility]} \n Strengh: {armor.Stats[Stat.Strengh]} \n Stamina: {armor.Stats[Stat.Stamina]} \n");
                }
            }
            else
            {
                Console.WriteLine("Couldn't find the item");
            }
        }

        /// <summary>
        /// Searches for an item inside the inventory that corresponds to the given name.
        /// </summary>
        public void SearchItemByName(string name)
        {
            if (inventory.Exists(item => item.Name == name)) // Check if the item exists inside the inventory
            {
                Item item = GetItemByName(name); // Get the selected item by it's name

                if (item is Weapon)
                {
                    Weapon weapon = (Weapon)item; // Downcast (turn the base class into a more specific class)

                    Console.WriteLine($" ID: {weapon.Id}\n Name: {weapon.Name}\n Description: {weapon.Description}\n " +
                        $"Level: {weapon.Level} \n Durability: {weapon.Durability} \n Damage : {weapon.Damage}\n " +
                        $"Slot: {weapon.weaponSlot} \n Type: {weapon.weaponType} \n " +
                        $"Stats \n Intellect: {weapon.Stats[Stat.Intellect]} " +
                        $"\n Agility: {weapon.Stats[Stat.Agility]} \n Strengh: {weapon.Stats[Stat.Strengh]} \n Stamina: {weapon.Stats[Stat.Stamina]} \n");
                }
                else if (item is Armor)
                {
                    Armor armor = (Armor)item; // Downcast (turn the base class into a more specific class)

                    Console.WriteLine($" ID: {armor.Id}\n Name: {armor.Name}\n Description: {armor.Description}\n " +
                        $"Level: {armor.Level} \n Durability: {armor.Durability} \n Defense : {armor.Defense}\n " +
                        $"Slot: {armor.armorSlot} \n Type: {armor.armorType} \n " +
                        $"Stats \n Intellect: {armor.Stats[Stat.Intellect]} " +
                        $"\n Agility: {armor.Stats[Stat.Agility]} \n Strengh: {armor.Stats[Stat.Strengh]} \n Stamina: {armor.Stats[Stat.Stamina]} \n");
                }
            }
            else
            {
                Console.WriteLine("Couldn't find the item");
            }
        }

        /// <summary>
        /// Lopp through the entire inventory in order to view all it's items.
        /// </summary>
        public void ViewInventory()
        {
            List<Item> sortedInventory = inventory.OrderBy(item => item.Id).ToList(); // Sort list by id

            foreach (Item item in sortedInventory)
            {
                if (item is Weapon)
                {
                    Weapon weapon = (Weapon)item; // Downcast (turn the base class into a more specific class)

                    Console.WriteLine($" ID: {weapon.Id}\n Name: {weapon.Name}\n Description: {weapon.Description}\n " +
                        $"Level: {weapon.Level} \n Durability: {weapon.Durability} \n Damage : {weapon.Damage}\n " +
                        $"Slot: {weapon.weaponSlot} \n Type: {weapon.weaponType} \n " +
                        $"Stats \n Intellect: {weapon.Stats[Stat.Intellect]} " +
                        $"\n Agility: {weapon.Stats[Stat.Agility]} \n Strengh: {weapon.Stats[Stat.Strengh]} \n Stamina: {weapon.Stats[Stat.Stamina]} \n");
                }
                else if (item is Armor)
                {
                    Armor armor = (Armor)item; // Downcast (turn the base class into a more specific class)

                    Console.WriteLine($" ID: {armor.Id}\n Name: {armor.Name}\n Description: {armor.Description}\n " +
                        $"Level: {armor.Level} \n Durability: {armor.Durability} \n Defense : {armor.Defense}\n " +
                        $"Slot: {armor.armorSlot} \n Type: {armor.armorType} \n " +
                        $"Stats \n Intellect: {armor.Stats[Stat.Intellect]} " +
                        $"\n Agility: {armor.Stats[Stat.Agility]} \n Strengh: {armor.Stats[Stat.Strengh]} \n Stamina: {armor.Stats[Stat.Stamina]} \n");
                }
            }
        }
        #endregion
    }
}
