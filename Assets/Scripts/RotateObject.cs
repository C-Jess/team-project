using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [Tooltip("Angle roated pre fixed frame")]
    [SerializeField] private float angle = 0.5f;
    [SerializeField] private Vector3 axis = Vector3.up;

    void FixedUpdate()
    {
        transform.Rotate(axis, angle, Space.World);
    }
}
