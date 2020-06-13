using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Sword,
    Axe,
    Wand,
    Polearm,
    Shield,
    Helmet,
    Shoulders,
    Cloak,
    Chest,
    Gloves,
    Waist,
    Boots,
    Ring,
    Food,
    Potion
}

public enum Attributes
{
    Agility,
    Intellect,
    Stamina,
    Strengh
}

[CreateAssetMenu(fileName = "New item", menuName = "Inventory System/Items/item")]
public class ItemObject : ScriptableObject
{
    public Sprite sprite;
    public bool stackable;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
    public Item data = new Item();

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
    public int id = -1;
    public ItemBuff[] buffs;

    public Item()
    {
        Name = "";
        id = -1;
    }

    public Item(ItemObject item)
    {
        Name = item.name;
        id = item.data.id;
        buffs = new ItemBuff[item.data.buffs.Length];

        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.data.buffs[i].value);
            buffs[i].attribute = item.data.buffs[i].attribute;
        }
    }
}

[System.Serializable]
public class ItemBuff : IModifier
{
    public Attributes attribute;
    public int value;

    public ItemBuff(int _value)
    {
        value = _value;
    }

    public void AddValue(ref int baseValue)
    {
        baseValue += value;
    }
}
