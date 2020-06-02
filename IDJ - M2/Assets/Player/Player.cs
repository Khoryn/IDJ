using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;

    private Vector3 mousePosition;
    private float moveSpeed = 2f;

    private void Awake()
    {
        inventory.Load();
    }

    private void Update()
    {
        FollowMousePosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickableItem item = collision.GetComponent<PickableItem>();

        if (item)
        {
            inventory.AddItem(new Item(item.item), 1);
            Destroy(collision.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Save();
        inventory.container.items.Clear();
    }

    private void FollowMousePosition()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;
        transform.position = mousePosition;
    }
}
