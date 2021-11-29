using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Sound _sound;
    [SerializeField] private bool onStart;
    [SerializeField] private AudioSource audioSource;
    [SerializeField]
    [Tooltip("value between 0.0 and 1.0")]
    private float _volume;

    public void Play(Sound sound = null)
    {
        if (sound != null)
            _sound = sound;
        _sound.Play(audioSource);
    }
    public void Start()
    {
        if (onStart == true)
            Play();
    }
}
