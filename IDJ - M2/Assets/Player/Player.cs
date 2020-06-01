using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();

        if (item) // add null verification
        {
            inventory.AddItem(item.item, 1);
            Destroy(collision.gameObject);
        }
    }

    // Temporary -> for tests only
    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
