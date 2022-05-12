using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
public class WireDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private UILineRenderer line;

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
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, canvas.worldCamera, out position);
        rectTransform.position = canvas.transform.TransformPoint(position);
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

    public void AttachToEnd(Vector3 position)
    {
        // No point moving if done.
        complete = true;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        rectTransform.position = position;
        line.ChangeEndPoint(rectTransform.anchoredPosition);
    }
}
