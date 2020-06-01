using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
    }

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
