using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PickableItem : MonoBehaviour, ISerializationCallbackReceiver
{
    [Header("Item")]
    public ItemObject item;

    public void OnAfterDeserialize()
    {
        
    }

    public void OnBeforeSerialize()
    {
#if UNITY_EDITOR
        GetComponentInChildren<SpriteRenderer>().sprite = item.sprite;
        EditorUtility.SetDirty(GetComponentInChildren<SpriteRenderer>());
#endif
    }
}
