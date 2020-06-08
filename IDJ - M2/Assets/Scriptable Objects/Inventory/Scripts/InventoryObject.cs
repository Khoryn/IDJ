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
    public GameObject inventoryCanvas;

    public void AddItem(Item _item, int _amount)
    {
        if (_item.buffs.Length > 0)
        {
            SetEmptySlot(_item, _amount);
            return;
        }
        for (int i = 0; i < container.items.Length; i++)
        {
            if (container.items[i].id == _item.id)
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
            if (container.items[i].id <= -1)
            {
                container.items[i].UpdateSlot(_item.id, _item, _amount);
                return container.items[i];
            }
        }
        // Set up functionality for full inventory
        return null;
    }

    public void MoveItem(InventorySlot item1, InventorySlot item2)
    {
        InventorySlot temp = new InventorySlot(item2.id, item2.item, item2.amount);
        item2.UpdateSlot(item1.id, item1.item, item1.amount);
        item1.UpdateSlot(temp.id, temp.item, temp.amount);
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
            container.items[i].UpdateSlot(newContainer.items[i].id, newContainer.items[i].item, newContainer.items[i].amount);
        }

        stream.Close();

        Debug.Log("Loaded file");
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        container = new Inventory();
    }

    public void ToggleInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryCanvas.activeInHierarchy)
            {
                inventoryCanvas.SetActive(false);
            }
            else
            {
                inventoryCanvas.SetActive(true);
            }
        }
    }
}

[System.Serializable]
public class Inventory
{
    public InventorySlot[] items = new InventorySlot[24];
}

[System.Serializable]
public class InventorySlot
{
    public int id = -1;
    public Item item;
    [Space(5)]
    public int amount;

    public InventorySlot(int _id, Item _item, int _amount)
    {
        id = _id;
        item = _item;
        amount = _amount;
    }

    public InventorySlot()
    {
        id = -1;
        item = null;
        amount = 0;
    }

    public void UpdateSlot(int _id, Item _item, int _amount)
    {
        id = _id;
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}
