using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Inventories")]
    public InventoryObject inventory;
    public InventoryObject equipment;

    [Header("Canvas")]
    public Image inventoryCanvas;
    public Image equipmentCanvas;

    [Header("Attributes")]
    public Attribute[] attributes;

    private void Start()
    {
        inventory.Load();
        equipment.Load();

        inventoryCanvas.gameObject.SetActive(false);
        equipmentCanvas.gameObject.SetActive(false);

        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i].SetParent(this);
        }
        for (int i = 0; i < equipment.GetSlots.Length; i++)
        {
            equipment.GetSlots[i].onBeforeUpdate += OnBeforeSlotUpdate;
            equipment.GetSlots[i].onAfterUpdate += OnAfterSlotUpdate;
        }
    }

    public void OnBeforeSlotUpdate(InventorySlot slot)
    {
        if (slot.ItemObject == null)
        {
            return;
        }
        Debug.Log("Before update");
    }

    public void OnAfterSlotUpdate(InventorySlot slot)
    {
        Debug.Log("After update");
    }

    private void Update()
    {
        FollowMousePosition();

        #region UI Methods
        ToggleEquipmentCanvas(equipmentCanvas);
        ToggleInventoryCanvas(inventoryCanvas);
        ToggleInventoryAndEquipmentCanvas(inventoryCanvas, equipmentCanvas);
        #endregion
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

    public void AttributeModified(Attribute attribute)
    {
        Debug.Log($"{attribute.type} has been updated! The current value is {attribute.value.ModifiedValue}");
    }

    private void OnApplicationQuit()
    {
        inventory.Save();
        equipment.Save();

        inventory.Clear();
        equipment.Clear();
    }

    private void FollowMousePosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;
        transform.position = mousePosition;
    }

    public void ToggleEquipmentCanvas(Image equipmentCanvas)
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (equipmentCanvas.gameObject.activeInHierarchy)
            {
                equipmentCanvas.gameObject.SetActive(false);
            }
            else
            {
                equipmentCanvas.gameObject.SetActive(true);
            }
        }
    }

    public void ToggleInventoryCanvas(Image inventoryCanvas)
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (inventoryCanvas.gameObject.activeInHierarchy)
            {
                inventoryCanvas.gameObject.SetActive(false);
            }
            else
            {
                inventoryCanvas.gameObject.SetActive(true);
            }
        }
    }

    public void ToggleInventoryAndEquipmentCanvas(Image inventoryCanvas, Image equipmentCanvas)
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if ((inventoryCanvas.gameObject.activeInHierarchy && equipmentCanvas.gameObject.activeInHierarchy) || (inventoryCanvas.gameObject.activeInHierarchy && !equipmentCanvas.gameObject.activeInHierarchy) && (!inventoryCanvas.gameObject.activeInHierarchy && equipmentCanvas.gameObject.activeInHierarchy))
            {
                inventoryCanvas.gameObject.SetActive(false);
                equipmentCanvas.gameObject.SetActive(false);
            }
            else
            {
                inventoryCanvas.gameObject.SetActive(true);
                equipmentCanvas.gameObject.SetActive(true);
            }
        }
    }
}

[System.Serializable]
public class Attribute
{
    [System.NonSerialized]
    public Player parent;
    public Attributes type;
    public AttributeModifier value;

    public void SetParent(Player player)
    {
        parent = player;
        value = new AttributeModifier(AttributeModified);
    }

    public void AttributeModified()
    {
        parent.AttributeModified(this);
    }
}
