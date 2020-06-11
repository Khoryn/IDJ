using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Food,
    Potion,
    Weapon,
    Shield,
    Helmet,
    Shoulders,
    Cloak,
    Chest,
    Gloves,
    Boots,
    Ring
}

public enum Attributes
{
    Agility,
    Intellect,
    Stamina,
    Strengh
}

public abstract class ItemObject : ScriptableObject
{
    public int id;
    public Sprite sprite;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
    public ItemBuff[] buffs;

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
}

[System.Serializable]
public class Item
{
    public string Name;
    public int id;
    public ItemBuff[] buffs;

    public Item()
    {
        Name = "";
        id = -1;
    }

    public Item(ItemObject item)
    {
        Name = item.name;
        id = item.id;
        buffs = new ItemBuff[item.buffs.Length];

        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.buffs[i].value);
            buffs[i].attribute = item.buffs[i].attribute;
        }
    }
}

[System.Serializable]
public class ItemBuff
{
    public Attributes attribute;
    public int value;

    public ItemBuff(int _value)
    {
        value = _value;
    }
}
