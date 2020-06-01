using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion Object", menuName = "Inventory System/Items/Potion")]
public class Potion : ItemObject
{
    public int RestoreHealthAmount { get; set; }
    public int RestoreManaAmount { get; set; }

    private void Awake()
    {
        type = ItemType.Potion;
    }
}
