using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ItemInspector", menuName = "Scriptable Objects/ItemInspector/InspectableItems")]

public class ItemInspector : ScriptableObject
{
    public static UnityEvent<bool> inspectionEvent =  new UnityEvent<bool>();
    public static UnityEvent<ItemObject> inspectionItem = new UnityEvent<ItemObject>();

    public static bool isActive;

    public void Inspect(ItemObject item)
    {
        Debug.Log($"Inspected {item.name}.");
        
        if (item.isInventoryItem)
        {
            Debug.Log($"Opening inspection UI for {item.name}...");

            isActive = !isActive;
            inspectionEvent.Invoke(isActive);
            inspectionItem.Invoke(item);
        }
        else
        {
            Debug.Log($"{item.name} is not an inspectable item.");
        }
    }
}