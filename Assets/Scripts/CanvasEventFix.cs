using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEventFix : MonoBehaviour
{
    // KJ: Hacked some stuff together for this, maybe replace later?

    public Canvas canvas;

    void Start()
    {
        if (canvas != null)
        {
            canvas.worldCamera = GameObject.Find("Inspection Camera").GetComponent<Camera>();
        }
    }
}
