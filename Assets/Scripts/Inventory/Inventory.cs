using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable Objects/Inventory System/Inventory")]

public class Inventory : ScriptableObject
{
    public ItemInspector itemInspector;
    public List<ItemObject> itemList = new List<ItemObject>();
    
    public void AddItem(ItemObject item)
    {
        itemList.Add(item);
    }

    public void RemoveAt(int location)
    {
        itemList.RemoveAt(location);
    }

    public void Inspect(ItemObject item)
    {
        if (item is null) return;
        if (itemInspector != null) itemInspector.Inspect(item);
    }

    private void OnEnable() {
        itemList.Clear();
    }
}
