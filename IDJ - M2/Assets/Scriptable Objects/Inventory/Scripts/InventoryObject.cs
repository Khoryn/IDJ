using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public enum InterfaceType
    {
        Inventory,
        Equipment,
        Chest
    }

    public string savePath;
    public ItemDatabaseObject database;
    public InterfaceType type;
    public Inventory container;
    public Canvas inventoryCanvas;
    public InventorySlot[] GetSlots { get { return container.slots; } }

    public bool AddItem(Item item, int amount)
    {
        if (EmptySlotCount <= 0)
        {
            return false;
        }
        InventorySlot slot = FindItemOnInventory(item);
        if (!database.ItemObjects[item.id].stackable || slot == null)
        {
            SetEmptySlot(item, amount);
            return true;
        }
        slot.AddAmount(amount);
        return true;
    }

    public InventorySlot FindItemOnInventory(Item item)
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            if (GetSlots[i].item.id == item.id)
            {
                return GetSlots[i];
            }
        }
        return null;
    }

    public int EmptySlotCount
    {
        get
        {
            int counter = 0;
            for (int i = 0; i < GetSlots.Length; i++)
            {
                if (GetSlots[i].item.id <= -1)
                {
                    counter++;
                }
            }
            return counter;
        }
    }

    public InventorySlot SetEmptySlot(Item item, int amount)
    {
        for (int i = 0; i < GetSlots.Length; i++)
        {
            if (GetSlots[i].item.id <= -1)
            {
                GetSlots[i].UpdateSlot(item, amount);
                return GetSlots[i];
            }
        }
        return null;
    }

    public void SwapItems(InventorySlot item1, InventorySlot item2)
    {
        if (item2.CanPlaceInSlot(item1.ItemObject) && item1.CanPlaceInSlot(item2.ItemObject))
        {
            InventorySlot temp = new InventorySlot(item2.item, item2.amount);
            item2.UpdateSlot(item1.item, item1.amount);
            item1.UpdateSlot(temp.item, temp.amount);
        }
    }

    [ContextMenu("Save")]
    public void Save()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, container);
        stream.Close();

        Debug.Log("Saved file");
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Inventory newContainer = (Inventory)formatter.Deserialize(stream);

            for (int i = 0; i < GetSlots.Length; i++)
            {
                GetSlots[i].UpdateSlot(newContainer.slots[i].item, newContainer.slots[i].amount);
            }
            stream.Close();

            Debug.Log("Loaded file");
        }
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        container.Clear();
    }

    public void ToggleInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryCanvas.gameObject.activeInHierarchy)
            {
                inventoryCanvas.gameObject.SetActive(false);
            }
            else
            {
                inventoryCanvas.gameObject.SetActive(true);
            }
        }
    }

    //public void ToggleInventory()
    //{
    //    if (Input.GetKeyDown(KeyCode.I))
    //    {
    //        if (inventoryCanvas.activeInHierarchy)
    //        {
    //            inventoryCanvas.SetActive(false);
    //        }
    //        else
    //        {
    //            inventoryCanvas.SetActive(true);
    //        }
    //    }
    //}
}

[System.Serializable]
public class Inventory
{
    public InventorySlot[] slots = new InventorySlot[24];

    public void Clear()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveItem();
        }
    }
}

public delegate void SlotUpdated(InventorySlot _slot);

[System.Serializable]
public class InventorySlot
{
    public ItemType[] allowedItems = new ItemType[0];
    [System.NonSerialized]
    public UserInterface parent;
    [System.NonSerialized]
    public GameObject slotDisplay;
    [System.NonSerialized]
    public SlotUpdated onAfterUpdate;
    [System.NonSerialized]
    public SlotUpdated onBeforeUpdate;
    public Item item = new Item();
    [Space(5)]
    public int amount;

    public InventorySlot()
    {
        UpdateSlot(new Item(), 0);
    }

    public InventorySlot(Item _item, int _amount)
    {
        UpdateSlot(_item, _amount);
    }

    public void RemoveItem()
    {
        UpdateSlot(new Item(), 0);
    }

    public void UpdateSlot(Item _item, int _amount)
    {
        if (onBeforeUpdate != null)
        {
            onBeforeUpdate.Invoke(this);
        }
        item = _item;
        amount = _amount;

        if (onAfterUpdate != null)
        {
            onAfterUpdate.Invoke(this);
        }
    }

    public void AddAmount(int value)
    {
        UpdateSlot(item, amount += value);
    }

    public ItemObject ItemObject
    {
        get
        {
            if (item.id >= 0)
            {
                return parent.inventory.database.ItemObjects[item.id];
            }
            return null;
        }
    }

    public bool CanPlaceInSlot(ItemObject _itemObject)
    {
        if (allowedItems.Length <= 0 || _itemObject == null || _itemObject.data.id < 0)
        {
            return true;
        }

        for (int i = 0; i < allowedItems.Length; i++)
        {
            if (_itemObject.type == allowedItems[i])
            {
                return true;
            }
        }
        return false;
    }
}
