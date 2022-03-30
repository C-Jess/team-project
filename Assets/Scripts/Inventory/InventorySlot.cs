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
        int length = inv.ItemList.Count;
        
        if(slot + 1 <= length)
        {
            item = inv.ItemList[slot];
            slotImage.sprite = item.sprite;
            slotImage.enabled = true;
        }
        else
        {
            slotImage.enabled = false;
        }
    }
}
