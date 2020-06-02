using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Food,
    Potion,
    Weapon,
    Armor
}

public abstract class ItemObject : ScriptableObject
{
    public int id;
    public Sprite sprite;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
}

[System.Serializable]
public class Item
{
    public string Name;
    public int id;

    public Item(ItemObject item)
    {
        Name = item.name;
        id = item.id;
    }
}
