using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject//, ISerializationCallbackReceiver
{
    public string savePath;
    public ItemDatabaseObject database;
    public Inventory container;
    public GameObject inventoryCanvas;

    public void AddItem(Item _item, int _amount)
    {
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
        //string saveData = JsonUtility.ToJson(this, true);
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        //bf.Serialize(file, saveData);
        //file.Close();

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, container);
        stream.Close();


        Debug.Log("Saved file");
    }

    [ContextMenu("Load")]
    public void Load()
    {
        //if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        //{
        //    BinaryFormatter bf = new BinaryFormatter();
        //    FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
        //    JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
        //    file.Close();
        //}

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

    //public void OnAfterDeserialize()
    //{
    //    for (int i = 0; i < container.items.Count; i++)
    //    {
    //        container.items[i].item = database.getItem[container.items[i].id];
    //    }
    //}

    //public void OnBeforeSerialize()
    //{

    //}
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
