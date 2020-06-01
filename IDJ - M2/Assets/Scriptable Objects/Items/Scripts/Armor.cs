using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor Object", menuName = "Inventory System/Items/Armor")]
public class Armor : ItemObject
{
    public int DefenseBonus { get; set; }
    private void Awake()
    {
        type = ItemType.Armor;
    }
}
