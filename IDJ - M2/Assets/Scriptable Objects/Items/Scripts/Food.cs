using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food Object", menuName = "Inventory System/Items/Food")]
public class Food : ItemObject
{
    public int HealthOverTime { get; set; }

    private void Awake()
    {
        type = ItemType.Food;
    }
}
