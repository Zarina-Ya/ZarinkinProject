using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _audioMixer;
    public void ToggleMusic(bool val)
    {
        if (val) AudioListener.volume = 1f;
        else AudioListener.volume = 0f;
    }

    public void SliderMusic(float val)
    {
        _audioMixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, val));
    }
}
