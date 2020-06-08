using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public GameObject inventoryPrefab;
    public InventoryObject inventory;
    public int xSpaceBetweenItems;
    public int columns;
    public int ySpaceBetweenItems;
    public int xStart;
    public int yStart;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    void Start()
    {
        CreateDisplay();
    }

    void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.container.items.Count; i++)
        {
            InventorySlot slot = inventory.container.items[i];

            GameObject obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.getItem[slot.item.id].sprite;
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<Text>().text = slot.amount.ToString("n0");
            itemsDisplayed.Add(slot, obj);
        }
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.container.items.Count; i++)
        {
            InventorySlot slot = inventory.container.items[i];

            if (itemsDisplayed.ContainsKey(slot))
            {
                itemsDisplayed[slot].GetComponentInChildren<Text>().text = slot.amount.ToString("n0");
            }
            else
            {
                GameObject obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
                obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.getItem[slot.item.id].sprite;
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<Text>().text = slot.amount.ToString("n0");
                itemsDisplayed.Add(slot, obj);
            }
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(xStart + (xSpaceBetweenItems * (i % columns)), yStart + ((-ySpaceBetweenItems * (i/ columns))),0f);
    }
}
