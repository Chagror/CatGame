using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SoundEffet _soundEffet;

    [SerializeField]
    [Tooltip("value between 0.0 and 1.0")]
    private float _volume;

    public void Play(SoundEffet soundEffet = null)
    {
        if (soundEffet != null)
            _soundEffet = soundEffet;
        _soundEffet.Play();
    }
}
