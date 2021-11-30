using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChanger : MonoBehaviour
{

    [SerializeField] private List<AudioSource> _audioSources;
    [SerializeField] private Game _gameManager;

    public void VolumeUpdate()
    {
        foreach (var audioSource in _audioSources)
        {
            audioSource.volume = _gameManager.volume/100.0f;
        }
    }

}
