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

        foreach (Vector2 i in points)
        {
            AddVerticeForPoints(i, vh);
        }

        for (int i = 0; i < points.Count - 1; i++)
        {
            int index = i * 2;
            vh.AddTriangle(index + 0, index + 1, index + 3);
            vh.AddTriangle(index + 3, index + 2, index + 0);
        }
    }

    void AddVerticeForPoints(Vector2 point, VertexHelper vh)
    {
        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        vertex.position = new Vector3(
            rectTransform.rect.center.x + point.x,
            rectTransform.rect.center.y + point.y + (thinkness/2)
            );
        vh.AddVert(vertex);

        vertex.position = new Vector3(
            rectTransform.rect.center.x + point.x,
            rectTransform.rect.center.y + point.y - (thinkness/2)
            );
        vh.AddVert(vertex);
    }

    public void ChangeEndPoint(Vector2 position)
    {
        points[1] = position;
        SetVerticesDirty();
    }

    public void ChangeStartPoint(Vector2 position)
    {
        points[0] = position;
        SetVerticesDirty();
    }
}
