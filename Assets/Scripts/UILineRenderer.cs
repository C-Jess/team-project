using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
public class UILineRenderer : Graphic
{
    public float thinkness = 10f;
    public List<Vector2> points; // KJ: Extend class later?

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();

        if (points.Count < 2) return;

        float angle = 0;
        for (int i = 0; i < points.Count; i++)
        {
            if (i < points.Count - 1)
            {
                // Distance Vector
                Vector2 v = points[i + 1] - points[i];
                // Angle from one point to another + offset
                angle = Mathf.Atan2(v.y, v.x) + Mathf.PI/4;
            }
            AddVerticeForPoints(points[i], angle, vh);
        }

        for (int i = 0; i < points.Count - 1; i++)
        {
            int index = i * 2;
            vh.AddTriangle(index + 0, index + 1, index + 3);
            vh.AddTriangle(index + 3, index + 2, index + 0);
        }
    }

    void AddVerticeForPoints(Vector2 point, float angle, VertexHelper vh)
    {
        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        // KJ: Could make this a matrix but is probably faster to do in 2D

        float radius = (thinkness / 2);
        float posX = (Mathf.Cos(angle) - Mathf.Sin(angle)) * radius;
        float posY = (Mathf.Sin(angle) + Mathf.Cos(angle)) * radius;
        float offsetX = rectTransform.rect.center.x + point.x;
        float offsetY = rectTransform.rect.center.y + point.y;
        
        // Get rotated point along an axis, move out by radius, and then add offset.
        vertex.position = new Vector3(
            posX + offsetX,
            posY + offsetY
        );

        vh.AddVert(vertex);

        vertex.position = new Vector3(
            (posX * -1) + offsetX,
            (posY * -1) + offsetY
        );

        vh.AddVert(vertex);
    }

    public void ChangeEndPoint(Vector2 position)
    {
        points[1] = position;
        SetVerticesDirty();
    }
}
