using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundEffet", menuName = "ScriptableObjects/Sound/SoundEffet")]
public class SoundEffet : ScriptableObject
{
    public AudioClip clip;
    

    public AudioSource Play(AudioSource audioSourceParam = null)
    {
        if (clip.length == 0)
            return null;

        var source = audioSourceParam;
        if (audioSourceParam == null)
        {
            var obj = new GameObject("Sound", typeof(AudioSource));
            source = obj.GetComponent<AudioSource>();
        }

        source.clip = clip;
        source.Play();
        

        return source;
    }
}
