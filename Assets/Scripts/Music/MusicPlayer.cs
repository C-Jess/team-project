using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public Button button;
    public MusicController controller;

    public float startTime = 0f;

    private void Start()
    {
        if (controller != null) controller.onVolumeChange.AddListener(VolumeChanged);
        controller.GetCurrentVolume();

        if (audioSource != null) audioSource.time = startTime;
    }

    private void OnDestroy()
    {
        if (controller != null) controller.onVolumeChange.RemoveListener(VolumeChanged);
    }

    private void VolumeChanged(float volume, Sprite newSprite)
    {
        // The gates of null
        if (controller == null) return;
        if (button == null) return;
        if (audioSource == null) return;

        // Change the sprite if we got one
        if (newSprite != null)
        {
            button.image.sprite = newSprite;
        }

        // Adjust audio source volume
        audioSource.volume = volume;
    }
}
