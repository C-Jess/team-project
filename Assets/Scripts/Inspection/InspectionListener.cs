using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionListener : MonoBehaviour
{
    [SerializeField, Tooltip("Filps active states like a NOT gate")]
    private bool flip = false;

    private void Start()
    {
        ChangeActive(ItemInspector.isActive);
        ItemInspector.inspectionEvent.AddListener(ChangeActive);
    }

    // KJ: Clean up listeners
    private void OnDestroy()
    {
        ItemInspector.inspectionEvent.RemoveListener(ChangeActive);
    }

    private void ChangeActive(bool active)
    {
        gameObject.SetActive(flip ? !active : active);
    }
}
