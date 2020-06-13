using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public InventoryObject inventory;
    public InventoryObject equipment;

    //public Text inventoryFullText;
    //public float textFadeOutTime;
    //private Color originalColor;

    private void Awake()
    {
        inventory.Load();
        equipment.Load();
    }

    private void Update()
    {
        FollowMousePosition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PickableItem item = collision.GetComponent<PickableItem>();
        if (Input.GetMouseButtonDown(0))
        {
            if (item)
            {
                Item _item = new Item(item.item);

                if (inventory.AddItem(_item, 1))
                {
                    Destroy(collision.gameObject);
                }
            }
        
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Save();
        equipment.Save();
        inventory.container.Clear();
        equipment.container.Clear();
    }

    private void FollowMousePosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;
        transform.position = mousePosition;
    }

    //public void FadeOut()
    //{
    //    StartCoroutine(FadeOutRoutine());
    //}

    //private IEnumerator FadeOutRoutine()
    //{
    //    for (float t = 0.01f; t < textFadeOutTime; t += Time.deltaTime)
    //    {
    //        inventoryFullText.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / textFadeOutTime));
    //        yield return null;
    //    }
    //    inventoryFullText.gameObject.SetActive(false);
    //    inventoryFullText.color = originalColor;
    //}
}
