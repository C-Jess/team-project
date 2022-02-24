using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class WireConnectionPoint : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject wire;
    
    RectTransform rectTransform;
    
    public UnityEvent<Vector2> onDropEvent;

    private void Start()
    {
        if (onDropEvent == null) onDropEvent = new UnityEvent<Vector2>();
        if (rectTransform == null) rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log($"Drop {eventData.pointerDrag.name}");
        if (eventData.pointerDrag == wire)
        {
            onDropEvent.Invoke(rectTransform.position);
        }
    }
}
