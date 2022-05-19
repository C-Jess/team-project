using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Music Controller", menuName = "Scriptable Objects/Music Controller")]
public class MusicController : ScriptableObject
{
    public UnityEvent<float, Sprite> onVolumeChange = new UnityEvent<float, Sprite>();
    public List<VolumeData> volumeDatas;

    private int index = 0;

    private void OnEnable()
    {
        index = 0;
    }

    public void CycleVolumes()
    {
        if (volumeDatas == null) return;
        index++;
        index = CheckValidIndex(index);

        InvokeData(index);
    }

    // Allow non persistant items to get data
    public void GetCurrentVolume()
    {
        if (volumeDatas == null) return;

        InvokeData(index);
    }

    private void InvokeData(int i)
    {
        VolumeData v = volumeDatas[i];
        onVolumeChange.Invoke(v.volume, v.sprite);
    }

    private int CheckValidIndex(int i)
    {
        // Above max
        if (i > volumeDatas.Count - 1)
        {
            i = 0;
        }

        // Under min
        if (i < 0)
        {
            i = volumeDatas.Count - 1;
        }

        return i;
    }
}

[System.Serializable]
public class VolumeData
{
    [Range(0f, 1f)]
    public float volume = 1f;
    public Sprite sprite;
}
