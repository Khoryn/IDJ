using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public int MaximumStack { get; set; }

    public SpriteRenderer sprite;

    protected Item()
    {
        Name = "Default";
        MaximumStack = 1;
    }
}
