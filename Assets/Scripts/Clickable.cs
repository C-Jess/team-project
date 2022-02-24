using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour, IPointerClickHandler
{
    // KJ: This is public so others can see it.
    // We also get to see and set it up in the
    // Inspector!
    public UnityEvent onClickEvent;

    private void Start()
    {
        // Basic set up blah-blah.
        if (onClickEvent == null) onClickEvent = new UnityEvent();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"Clicked on \"{name}\"");
        // KJ: This is how we tell other components
        // listening that we got clicked.
        onClickEvent.Invoke();
    }
}
