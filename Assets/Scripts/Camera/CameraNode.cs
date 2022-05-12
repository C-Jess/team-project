using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNode : MonoBehaviour
{
    [SerializeField] private CameraNode nodeLeft;
    [SerializeField] private CameraNode nodeRight;
    [SerializeField] bool locked;

    public CameraNode GetLeft()
    {
        return nodeLeft;
    }

    public CameraNode GetRight()
    {
        return nodeRight;
    }

    public bool IsLocked()
    {
        return locked;
    }

    public void SetLock (bool state)
    {
        locked = state;
    }

    // KJ: Added Gizmo draw to help manage nodes
    void OnDrawGizmos ()
    {
        if (nodeLeft != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, Vector3.Lerp(transform.position, nodeLeft.transform.position, 0.5f));
        }

        if (nodeRight != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, Vector3.Lerp(transform.position, nodeRight.transform.position, 0.5f));
        }
    }
}
