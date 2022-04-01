using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InspectionUIUpdater : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text itemDescription;

    // Add listener for item inspect event.
    private void Start()
    {
        ItemInspector.inspectionItem.AddListener(UpdateUI);
    }

    // KJ: Clean up listeners
    private void OnDestroy()
    {
        ItemInspector.inspectionItem.RemoveListener(UpdateUI);
    }

    // Get ItemObject name and description attributes, assign to inspection UI elements.
    public void UpdateUI(ItemObject item)
    {
        itemName.text = item.name;
        itemDescription.text = item.FullDescription();
    }
}
