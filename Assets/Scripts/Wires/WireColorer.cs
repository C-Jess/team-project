using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class WireColorer : MonoBehaviour
{
    [SerializeField] private Image dot;
    [SerializeField] private Image dotEnd;
    [SerializeField] private Image dotMove;
    [SerializeField] private UILineRenderer line;

    [SerializeField] private Color mainColor = Color.white;
    [SerializeField] private Color secondaryColor = Color.white;

    // This is only called in editor, beware!
    private void OnValidate()
    {
        if (dot != null) dot.color = secondaryColor;
        if (dotEnd != null) dotEnd.color = secondaryColor;
        if (dotMove != null) dotMove.color = mainColor;
        if (line != null) line.color = mainColor;
    }
}
