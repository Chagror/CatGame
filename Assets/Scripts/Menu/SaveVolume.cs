using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveVolume : MonoBehaviour
{
    private int volume;
    [SerializeField] private Slider slider;

    private GameManager _gameManager;

    private void Start()
    {
        //Get the instance and set the volume by reading at the SO
        _gameManager = GameManager.instance;
        slider.value = _gameManager.SO.volume;
    }

    //Used by the button
    public void saveVolume()
    {
        volume = (int)slider.value;

        _gameManager.SO.volume = volume;
        PlayerPrefs.SetInt("Volume", volume);
        PlayerPrefs.Save();
    }
}
