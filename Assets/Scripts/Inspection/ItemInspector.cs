using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[CreateAssetMenu(fileName = "ItemInspector", menuName = "Scriptable Objects/ItemInspector/InspectableItems")]

public class ItemInspector : ScriptableObject
{
    public GameObject inspectionUI;
    private bool isActive;

    public void Inspect(ItemObject item)
    {
        Debug.Log($"Inspected {item.name}.");
        
        if (item.isInventoryItem)
        {
            Debug.Log($"Opening inspection UI for {item.name}...");

            isActive = !isActive;
            inspectionUI.SetActive(isActive);
        }
        else
        {
            Debug.Log($"{item.name} is not an inspectable item.");
        }
    }
}