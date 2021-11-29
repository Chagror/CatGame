using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameMusic", menuName = "ScriptableObjects/Sound/GameMusic")]

public class GameMusic : Sound
{
    // Start is called before the first frame update
    public AudioClip intro;
    public AudioClip loop;

    public override AudioSource Play(AudioSource audioSourceParam = null)
    {
        if (intro.length == 0 || loop.length == 0)
            return null;

        var source = audioSourceParam;
        
        if (audioSourceParam == null)
        {
            var obj = new GameObject("Sound", typeof(AudioSource));
            source = obj.GetComponent<AudioSource>();
        }
        var obj2 = new GameObject("Sound", typeof(AudioSource));
        AudioSource loopAudio = obj2.GetComponent<AudioSource>();
        loopAudio.loop = true;
        loopAudio.volume = source.volume;
        source.clip = intro;
        source.Play();
        loopAudio.clip = loop;
        loopAudio.PlayScheduled(AudioSettings.dspTime + intro.length);

        return source;
    }
}
