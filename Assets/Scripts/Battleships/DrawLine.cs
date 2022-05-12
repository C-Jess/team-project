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
        int left = 0, bottom = 0, top = 10 , right = 10;
        List<Vector2> points = new List<Vector2>();
        // y = mx + c, x = left/right
        float leftIntercept = m * left + c;
        float rightIntercept = m * right + c;
        // x = (y - c) / m, y = top/bottom
        float topIntercept = (top - c) / m;
        float bottomIntercept = (bottom - c) / m;

        if ((leftIntercept > bottom) && (leftIntercept <= top)) // left
        {
            points.Add(new Vector2(0, leftIntercept));
        }
        if ((rightIntercept >= bottom) && (rightIntercept < top)) // right
        {
            points.Add(new Vector2(10, rightIntercept));
        }
        if ((m != 0) && (topIntercept > left) && (topIntercept <= right)) // top
        {
            points.Add(new Vector2(topIntercept, 10));
        }
        if ((m != 0) && (bottomIntercept >= left) && (bottomIntercept < right)) // bottom
        {
            points.Add(new Vector2(bottomIntercept, 0));
        }

        if (points.Count == 0)
        {
            // add 0,0 points
            points.Add(new Vector2(0,0));
            points.Add(new Vector2(0, 0));
        }
        else if (points.Count == 1)
        {
            // add same point twice so there is no line
            points.Add(points[0]);
        }

        // Update line
        line.ChangeStartPoint(points[0]);
        line.ChangeEndPoint(points[1]);

        onLineCalculated.Invoke(m, c);
    }

    public void GetMInput(string InputM)
    {
        float.TryParse(InputM, out m);
    }

    public void GetCInput(string InputC)
    {
        float.TryParse(InputC, out c);
    }
}
