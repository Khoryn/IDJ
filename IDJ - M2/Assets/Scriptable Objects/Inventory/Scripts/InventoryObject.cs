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
    public string savePath;
    public ItemDatabaseObject database;
    public Inventory container;

    public void AddItem(Item _item, int _amount)
    {
        if (_item.buffs.Length > 0)
        {
            SetEmptySlot(_item, _amount);
            return;
        }
        for (int i = 0; i < container.items.Length; i++)
        {
            if (container.items[i].item.id == _item.id)
            {
                container.items[i].AddAmount(_amount);
                return;
            }
        }
        SetEmptySlot(_item, _amount);
        Debug.Log($"Added {_item.Name} to the inventory");
    }

    public InventorySlot SetEmptySlot(Item _item, int _amount)
    {
        for (int i = 0; i < container.items.Length; i++)
        {
            if (container.items[i].item.id <= -1)
            {
                container.items[i].UpdateSlot(_item.id, _item, _amount);
                return container.items[i];
            }
        }
        // Set up functionality for full inventory
        return null;
    }

    public void SwapItems(InventorySlot item1, InventorySlot item2)
    {
        //if (item2.CanPlaceInSlot)
        //{

        //}
        //InventorySlot temp = new InventorySlot(item2.id, item2.item, item2.amount);
        //item2.UpdateSlot(item1.id, item1.item, item1.amount);
        //item1.UpdateSlot(temp.id, temp.item, temp.amount);
    }

    public void RemoveItem(Item _item)
    {
        for (int i = 0; i < container.items.Length; i++)
        {
            if (container.items[i].item == _item)
            {
                container.items[i].UpdateSlot(-1, null, 0);
            }
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
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
        Inventory newContainer = (Inventory)formatter.Deserialize(stream);

        for (int i = 0; i < container.items.Length; i++)
        {
            container.items[i].UpdateSlot(newContainer.items[i].item.id, newContainer.items[i].item, newContainer.items[i].amount);
        }

        stream.Close();

        Debug.Log("Loaded file");
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        container.Clear();
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
    public InventorySlot[] items = new InventorySlot[24];

    public void Clear()
    {
        for (int i = 0; i < items.Length; i++)
        {
            items[i].UpdateSlot(-1, new Item(), 0);
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemType[] allowedItems = new ItemType[0];

    [System.NonSerialized]
    public UserInterface parent;
    public Item item;
    [Space(5)]
    public int amount;

    public InventorySlot(int _id, Item _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public InventorySlot()
    {
        item = null;
        amount = 0;
    }

    public void RemoveItem()
    {
        item = new Item();
        amount = 0;
    }

    public void UpdateSlot(int _id, Item _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

    public bool CanPlaceInSlot(ItemObject _itemObject)
    {
        if (allowedItems.Length <= 0 || _itemObject == null || _itemObject.data)
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
