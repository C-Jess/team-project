using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable Objects/Inventory System/Inventory")]

public class Inventory : ScriptableObject
{
    public List<ItemObject> ItemList = new List<ItemObject>();
    
    public void AddItem(ItemObject item)
    {
        ItemList.Add(item);
    }

    public void RemoveAt(int location)
    {
        ItemList.RemoveAt(location);
    }

    private void OnEnable() {
        ItemList.Clear();
    }
}
