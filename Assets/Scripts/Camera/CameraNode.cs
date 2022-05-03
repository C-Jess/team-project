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
}
