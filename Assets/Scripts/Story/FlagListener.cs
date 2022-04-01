using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlagListener : MonoBehaviour
{
    public UnityEvent doTrigger;
    [SerializeField]
    private LevelFlags levelFlags;
    [SerializeField]
    private string flagToCheck;
    [SerializeField]
    private bool stateWanted = true;

    private void Start()
    {
        if (doTrigger == null) doTrigger = new UnityEvent();
        if (levelFlags != null) levelFlags.onFlagChange.AddListener(FlagChange);
    }

    private void OnDestroy()
    {
        if (levelFlags != null) levelFlags.onFlagChange.RemoveListener(FlagChange);
    }

    public void FlagChange(string flag, bool state)
    {
        if (levelFlags == null || string.IsNullOrEmpty(flagToCheck)) return;

        if (levelFlags.GetFlag(flagToCheck) == stateWanted)
        {
            doTrigger.Invoke();
        }
    }
}
