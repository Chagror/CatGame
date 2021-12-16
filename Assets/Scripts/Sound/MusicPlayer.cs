using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : SoundPlayer
{
    [SerializeField] private AudioClip _intro;
    [SerializeField] private AudioClip _loop;
    [SerializeField] private bool onStart;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Game _gameManager;
    public void Stop() 
    {
        audioSource.Stop();
    }
    public override void Play()
    {
        if (_loop.length == 0 || _loop.length == 0)
            return ;

        var source = audioSource;
        
        if (audioSource == null)
        {
            var obj = new GameObject("Sound", typeof(AudioSource));
            source = obj.GetComponent<AudioSource>();
        }
        var obj2 = new GameObject("SoundLoop", typeof(AudioSource));
        AudioSource loopAudio = obj2.GetComponent<AudioSource>();
        source.volume = _gameManager.volume/100.0f;
        loopAudio.loop = true;
        loopAudio.volume = source.volume = _gameManager.volume / 100.0f;
        source.clip = _intro;
        source.Play();
        loopAudio.clip = _loop;
        loopAudio.PlayScheduled(AudioSettings.dspTime + _intro.length);
    }
    public void Start()
    {
        if (onStart == true)
            Play();
    }
}

