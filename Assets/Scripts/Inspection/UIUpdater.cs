using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIUpdater : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text itemDescription;

    // Start is called before the first frame update
    // Add listener for item inspect event.
    void Start()
    {
        ItemInspector.inspectionItem.AddListener(UpdateUI);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Get ItemObject name and description attributes, assign to inspection UI elements.
    public void UpdateUI(ItemObject item)
    {
        itemName.text = item.name;
        itemDescription.text = item.description;
    }
}
