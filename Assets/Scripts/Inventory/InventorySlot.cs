using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    private int slot;
    [SerializeField]
    private Inventory inv;
    private ItemObject item;

    private Image slotImage;

    private void Start() 
    {
        slotImage = this.gameObject.GetComponent<Image>();
    }
    
    public void Update()
    {
        // slot code here like remove item or get new item
        int length = inv.itemList.Count;
        
        if(slot + 1 <= length)
        {
            item = inv.itemList[slot];
            slotImage.sprite = item.sprite;
            slotImage.enabled = true;
        }
        else
        {
            slotImage.enabled = false;
        }
    }

    public void InspectSelf()
    {
        if (item is null) return;
        if (inv != null) inv.Inspect(item);
    }
}
