using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Level Flags", menuName = "Scriptable Objects/Story/Level Flags")]
public class LevelFlags : ScriptableObject
{
    public UnityEvent<string, bool> onFlagChange = new UnityEvent<string, bool>();
    public List<FlagPair> Flags;

    private void OnEnable()
    {
        foreach (FlagPair i in Flags)
        {
            i.state = false;
        }
    }

    public void SetFlag(string flag, bool state)
    {
        foreach (FlagPair i in Flags)
        {
            if (i.flag == flag)
            {
                i.state = state;
                onFlagChange.Invoke(flag, state);
                return;
            }
        }
        Debug.LogWarning($"<color=yellow>Warning:</color> flag \"<color=white>{flag}</color>\" doesn't exist in <color=cyan>{name}</color>");
    }

    public bool GetFlag(string flag)
    {
        foreach (FlagPair i in Flags)
        {
            if (i.flag == flag)
            {
                return i.state;
            }
        }

        Debug.Log($"Flag \"<color=white>{flag}</color>\" doesn't exist in <color=cyan>{name}</color>, check spelling");
        return false;
    }

        public void TriggerFlag(string flag) => SetFlag(flag, true);
}


// KJ: Can't use a Dictionary so this is how we get around it!
[System.Serializable]
public class FlagPair
{
    public string flag;
    public bool state;
}