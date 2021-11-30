using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : SoundPlayer
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip clip;
    [SerializeField] private bool onStart;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Game _gameManager;

public override void Play()
    {
        if (clip.length == 0)
            return;

        var source = audioSource;
        if (source == null)
        {
            var obj = new GameObject("Sound", typeof(AudioSource));
            source = obj.GetComponent<AudioSource>();
        }

        source.clip = clip;
        source.volume = _gameManager.volume / 100.0f;
        source.PlayOneShot(clip);
    }
    public void Start()
    {
        if (onStart == true)
            Play();
    }
}
