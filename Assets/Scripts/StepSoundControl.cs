using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class StepSoundControl : MonoBehaviour
{
    private AudioSource _audioSource; // источник звука
    [SerializeField] private AudioClip[] _footSteps;
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Step()
    {
        var stepsound = _footSteps[Random.Range(0, _footSteps.Length)];

        _audioSource.PlayOneShot(stepsound);
    }
}
