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
            container.items.Add(new InventorySlot(_item.id, _item, _amount));
            return;
        }
        for (int i = 0; i < container.items.Count; i++)
        {
            if (container.items[i].item.id == _item.id)
            {
                container.items[i].AddAmount(_amount);
                return;
            }
        }
        container.items.Add(new InventorySlot(_item.id, _item, _amount));
        Debug.Log($"Added {_item.Name} to the inventory");
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
        container = (Inventory)formatter.Deserialize(stream);
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
    public List<InventorySlot> items = new List<InventorySlot>();
}

[System.Serializable]
public class InventorySlot
{
    public int id;
    public Item item;
    [Space(5)]
    public int amount;

    public InventorySlot(int _id, Item _item, int _amount)
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
