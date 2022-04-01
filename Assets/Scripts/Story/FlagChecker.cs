using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlagChecker : MonoBehaviour
{
    public UnityEvent doTrigger;
    [SerializeField]
    private LevelFlags levelFlags;
    [SerializeField]
    private string flagToCheck;
    [SerializeField]
    private bool stateWanted = true;

    [SerializeField]
    private bool testOnStart = false;

    private void Start()
    {
        if (doTrigger == null) doTrigger = new UnityEvent();
        if (testOnStart) Test();
    }

    public void Test()
    {
        if (levelFlags == null || string.IsNullOrEmpty(flagToCheck)) return;

        if (levelFlags.GetFlag(flagToCheck) == stateWanted)
        {
            doTrigger.Invoke();
        }
    }
}
