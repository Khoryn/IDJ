using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public Inventory inventory;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMNS;
    public int Y_SPACE_BETWEEN_ITEM;
    public int X_START;
    public int Y_START;
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
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            GameObject obj = Instantiate(inventory.Container[i].item.itemPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<Text>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<Text>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                GameObject obj = Instantiate(inventory.Container[i].item.itemPrefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<Text>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START  +(X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMNS)), Y_START + ((-Y_SPACE_BETWEEN_ITEM * (i/NUMBER_OF_COLUMNS))),0f);
    }
}
