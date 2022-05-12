using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class WireConnection : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject wire;
    
    RectTransform rectTransform;
    
    public UnityEvent<Vector3> onDropEvent;

    private void Start()
    {
        if (onDropEvent == null) onDropEvent = new UnityEvent<Vector3>();
        if (rectTransform == null) rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log($"Dropped \"{eventData.pointerDrag.name}\"");
        if (eventData.pointerDrag == wire)
        {
            onDropEvent.Invoke(rectTransform.position);
        }
    }
}
