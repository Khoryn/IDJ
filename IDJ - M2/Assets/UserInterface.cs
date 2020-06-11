using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public abstract class UserInterface : MonoBehaviour
{
    public Player player;

    public InventoryObject inventory;

    protected Dictionary<GameObject, InventorySlot> slotsOnInterface = new Dictionary<GameObject, InventorySlot>();

    void Start()
    {
        for (int i = 0; i < inventory.container.items.Length; i++)
        {
            inventory.container.items[i].parent = this;
        }
        CreateSlots();
        AddEvent(gameObject, EventTriggerType.PointerEnter, delegate { OnEnterInterface(gameObject); });
        AddEvent(gameObject, EventTriggerType.PointerExit, delegate { OnExitInterface(gameObject); });
    }

    void Update()
    {
        UpdateSlots();
    }

    public abstract void CreateSlots();

    public void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject, InventorySlot> _slot in slotsOnInterface)
        {
            if (_slot.Value.item.id >= 0)
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.getItem[_slot.Value.item.id].sprite;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                _slot.Key.GetComponentInChildren<Text>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0");
            }
            else
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
                _slot.Key.GetComponentInChildren<Text>().text = "";
            }
        }
    }

    protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        EventTrigger.Entry eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    #region Events
    protected void OnEnter(GameObject obj)
    {
        MouseData.slotHoveredOver = obj;
    }

    protected void OnExit(GameObject obj)
    {
        MouseData.slotHoveredOver = null;
    }

    protected void OnEnterInterface(GameObject obj)
    {
        player.mouseItem.ui = null;
    }

    protected void OnExitInterface(GameObject obj)
    {
        player.mouseItem.ui = obj.GetComponent<UserInterface>();
    }

    protected void OnDragStart(GameObject obj)
    {
        GameObject mouseObject = new GameObject();
        RectTransform rt = mouseObject.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(67, 67);
        mouseObject.transform.SetParent(transform.parent);

        if (slotsOnInterface[obj].item.id >= 0)
        {
            Image image = mouseObject.AddComponent<Image>();
            image.sprite = inventory.database.getItem[slotsOnInterface[obj].item.id].sprite;
            image.raycastTarget = false;
        }
        player.mouseItem.obj = mouseObject;
        player.mouseItem.item = slotsOnInterface[obj];
    }

    protected void OnDragEnd(GameObject obj)
    {
        // Destroy the temporary item
        Destroy(MouseData.tempItemBeingDragged);

        if (MouseData.interfaceMouseIsOver != null)
        {
            slotsOnInterface[obj].RemoveItem();
            return;
        }
        if (MouseData.slotHoveredOver)
        {
            InventorySlot mouseHoverSlotData = MouseData.interfaceMouseIsOver.slotsOnInterface[MouseData.slotHoveredOver];
            //inventory.
        }
    }

    protected void OnDrag(GameObject obj)
    {
        if (player.mouseItem.obj != null)
        {
            player.mouseItem.obj.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }
    #endregion
}

public static class MouseData
{
    public static UserInterface interfaceMouseIsOver;
    public static GameObject tempItemBeingDragged;
    public static GameObject slotHoveredOver;
}
