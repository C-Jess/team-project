using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ComboLockPuzzle : MonoBehaviour
{
    public UnityEvent onComplete;
    [SerializeField]
    private string passcode = "111";
    [SerializeField]
    private float rotateBy = 36;
    [SerializeField]
    private List<Transform> wheels;
    private List<int> currentCode = new List<int>();

    private void Start()
    {
        if (onComplete == null) onComplete = new UnityEvent();

        for (int i = 0; i < wheels.Count; i++)
        {
            currentCode.Add(0);
        }
    }

    public void RotateWheel(int wheel, bool clockwise = true)
    {
        if (wheels.Count > wheel && wheel >= 0)
        {
            int direction = clockwise ? 1 : -1;
            wheels[wheel].Rotate(Vector3.right, rotateBy * direction, Space.Self);
            int x = currentCode[wheel] + direction;
            // Stop -1
            if (x < 0)
            {
                x = 9;
            }
            // Return to 0
            x %= 10;
            // Remove -0, just in case
            currentCode[wheel] = Mathf.Abs(x);
            CheckCode();
        }
    }

    public void CheckCode()
    {
        string code = "";
        foreach (int i in currentCode)
        {
            code += $"{i}";
        }

        Debug.Log($"Current code is {code}");

        if (code == passcode)
        {
            onComplete.Invoke();
        }
    }

    public void RotateWheelUp(int wheel) => RotateWheel(wheel);
    public void RotateWheelDown(int wheel) => RotateWheel(wheel, false);
}
