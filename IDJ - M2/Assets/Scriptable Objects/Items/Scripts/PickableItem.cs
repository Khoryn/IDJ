using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PickableItem : MonoBehaviour, ISerializationCallbackReceiver
{
    public ItemObject item;

    public void OnAfterDeserialize()
    {
        
    }

    public void OnBeforeSerialize()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = item.sprite;
        EditorUtility.SetDirty(GetComponentInChildren<SpriteRenderer>());
    }
}
