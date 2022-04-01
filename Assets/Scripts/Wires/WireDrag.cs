using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
public class WireDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private UILineRenderer line;
    [SerializeField] private float adjustment = 0;

    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    Vector2 origin;
    bool complete = false;

    void Start()
    {
        if (rectTransform == null) rectTransform = GetComponent<RectTransform>();
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
        origin = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //TODO: FIX THIS "adjustment" i a quick fix to get the demo ready -KJ
        rectTransform.anchoredPosition += eventData.delta / (canvas.scaleFactor + adjustment);
        line.ChangeEndPoint(rectTransform.anchoredPosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!complete)
        {
            canvasGroup.blocksRaycasts = true;
            rectTransform.anchoredPosition = origin;
            line.ChangeEndPoint(rectTransform.anchoredPosition);
        }
    }

    public void AttachToEnd(Vector2 position)
    {
        // No point moving if done.
        complete = true;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        rectTransform.position = position;
        line.ChangeEndPoint(rectTransform.anchoredPosition);
    }
}
