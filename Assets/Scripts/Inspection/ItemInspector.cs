using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ItemInspector", menuName = "Scriptable Objects/ItemInspector/InspectableItems")]

public class ItemInspector : ScriptableObject
{
    // Create inspection events.
    public static UnityEvent<bool> inspectionEvent =  new UnityEvent<bool>();
    public static UnityEvent<ItemObject> inspectionItem = new UnityEvent<ItemObject>();

    public static bool isActive;

    // Inspection method - called on click event. 
    public void Inspect(ItemObject item)
    {
        Debug.Log($"Inspected {item.name}.");
        
        // Check boolean value for whether the item is able to be added to the player's inventory.
        if (item.isInventoryItem)
        {
            Debug.Log($"Displaying inspection UI for {item.name}...");
            
            // Toggle active state, invoke inspection events.
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