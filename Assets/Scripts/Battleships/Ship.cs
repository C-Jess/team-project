using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    private Vector2 shipPos;
    private int width;
    private int height;
    private bool vertical = false;
    private bool horizontal = false;

    void Start()
    {
        var rectTransform = GetComponent<RectTransform>();

        shipPos = rectTransform.anchoredPosition;
        width = (int)rectTransform.sizeDelta.x;
        height = (int)rectTransform.sizeDelta.y;

        horizontal = (height == 1);
        vertical = (width == 1);
        Debug.Log(gameObject.name + "- horizontal: " + horizontal + ", vertical: " + vertical);
    }

    public void CheckHit(float m, float c)
    {
        var image = GetComponent<Image>();
        image.color = Color.grey;

        if (CheckIntercept(m, c))
        {
            Debug.Log(gameObject.name + "has been hit");
            image.color = Color.yellow;
        }
    }

    private bool CheckIntercept (float m, float c)
    {
        float left = shipPos.x;
        float right = shipPos.x + width;
        float top = shipPos.y + height;
        float bottom = shipPos.y;

        // y = mx + c
        float leftIntercept = m * left + c;
        float rightIntercept = m * right + c;
        // x = (y - c) / m
        float topIntercept = (top - c) / m;
        float bottomIntercept = (bottom - c) / m;

        if ((leftIntercept > bottom) && (leftIntercept < top))
        {
            return true;
        }
        else if ((rightIntercept > bottom) && (rightIntercept < top))
        {
            return true;
        }
        else if ((m != 0) && (topIntercept > left) && (topIntercept < right))
        {
            Debug.Log(m);
            return true;
        }
        else if ((m != 0) && (bottomIntercept > left) && (bottomIntercept < right))
        {
            Debug.Log(m);
            return true;
        }
        else
        {
            return false;
        }

    }
}
