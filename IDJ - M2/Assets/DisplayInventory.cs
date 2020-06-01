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
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateDisplay();
    }


    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.itemPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<Text>().text = inventory.Container[i].amount.ToString("n0");
        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMNS), (-Y_SPACE_BETWEEN_ITEM * (i/NUMBER_OF_COLUMNS)),0f);
    }
}
