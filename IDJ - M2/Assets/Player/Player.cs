using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    private Vector3 mousePosition;
    public float moveSpeed = 2f;

    private void Update()
    {
        FollowMousePosition();
        File();
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

    private void FollowMousePosition()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;
        transform.position = mousePosition;
    }

    private void File()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // For testing purposes
        {
            inventory.Save();
        }

        if (Input.GetKeyDown(KeyCode.Return)) // For testing purposes
        {
            inventory.Load();
        }

    }
}
