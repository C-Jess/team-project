using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionListener : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ChangeActive(ItemInspector.isActive);
        ItemInspector.inspectionEvent.AddListener(ChangeActive);
    }


    void ChangeActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
