using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    [SerializeField] private int countTo;
    
    private int count = 0;
    private bool doOnce = false;

    public UnityEvent onComplete;

    private void Start()
    {
        if (onComplete == null) onComplete = new UnityEvent();
    }

    public void CountUp()
    {
        count++;
        Debug.Log($"{count} of {countTo}");
        if (countTo > count) return;
        if (doOnce) return;
        doOnce = true;
        onComplete.Invoke();
    }
}
