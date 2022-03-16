// ?: Can any item in the scene be inspected? Or only those in the player's inventory?

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[CreateAssetMenu(fileName = "ItemInspector", menuName = "Scriptable Objects/ItemInspector/item")]

public class ItemInspector : ScriptableObject
{
    public void Inspect(ItemObject item)
    {
        Debug.Log($"Inspected {item.name}");
    }
}