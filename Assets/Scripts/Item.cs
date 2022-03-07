using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemObject item;
    public Inventory inventory;

    private void OnMouseDown() 
    {
        inventory.AddItem(item);
        Destroy(this.gameObject);
    }

    private void OnApplicationQuit() 
    {
        inventory.ItemList.Clear();
    }
}
