using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DrawLine : MonoBehaviour
{
    [SerializeField] private UILineRenderer line;

    private float m = 0;
    private float c = 0;

    private Vector2 startPoint;
    private Vector2 endPoint;

    public UnityEvent<float, float> onLineCalculated;

    public void CalculatePoints()
    {
        // Calculate intercepts
        // Right: x=10 when 0 >= y >= 10
        float x10 = m * 10 + c;
        // Top: y=10 when 0 >= x >= 10
        float y10 = (10 - c) / m;
        // Left: x=0 when 0 >= y >= 10
        float x0 = m * 0 + c;
        // Bottom: y=0 when 0 >= x >= 10
        float y0 = (0 - c) / m;

        // Check Left/Bottom
        if ((x0 >= 0) && (x0 <= 10))
        {
            startPoint = new Vector2(0, x0);
        }
        else if ((y0 >= 0) && (y0 <= 10))
        {
            startPoint = new Vector2(y0, 0);
        }
        
        // Check Top/Right/Bottom
        if ((y10 >= 0) && (y10 <= 10))
        {
            endPoint = new Vector2(y10, 10);
        }
        else if ((x10 >= 0) && (x10 <= 10))
        {
            endPoint = new Vector2(10, x10);
        }
        else if ((y0 >= 0) && (y0 <= 10))
        {
            endPoint = new Vector2(y0,  0);
        }

        // Update line
        line.ChangeStartPoint(startPoint);
        line.ChangeEndPoint(endPoint);

        onLineCalculated.Invoke(m, c);
    }

    public void GetMInput(string InputM)
    {
        m = float.Parse(InputM);
    }

    public void GetCInput(string InputC)
    {
        c = float.Parse(InputC);
    }
}
