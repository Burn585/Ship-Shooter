using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(AudioSource))]

public class PlayEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Shooting _shooting;

    private void OnEnable()
    {
        _shooting.Shot += Play;
    }

    private void OnDisable()
    {
        _shooting.Shot -= Play;
    }

    private void Play()
    {
        _particleSystem.Play();
        _audio.Play();
    }
}
