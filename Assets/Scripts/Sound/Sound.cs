using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Soond", menuName = "ScriptableObjects/Sound/SoundEffet")]
public abstract class Sound : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] protected Game _gameManager;
    public abstract AudioSource Play(AudioSource audioSourceParam = null);
}
