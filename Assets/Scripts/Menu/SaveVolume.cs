using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveVolume : MonoBehaviour
{
    [SerializeField] private float volume;

    public void saveVolume()
    {
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
