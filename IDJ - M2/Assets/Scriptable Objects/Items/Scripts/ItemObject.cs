﻿using System.Collections;
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
    public GameObject itemPrefab;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
}
