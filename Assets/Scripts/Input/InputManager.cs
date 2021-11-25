using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Singleton
    public static InputManager instance;
    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }
    #endregion

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.instance;
    }

    public void GoUp()
    {
        Debug.Log("I went up.");
    }
    public void GoLeft()
    {
        Debug.Log("I went left.");
    }
    public void GoRight()
    {
        Debug.Log("I went right.");
    }
    public void GoDown()
    {
        Debug.Log("I went down.");
    }
    public void Pause()
    {
        _gameManager.SO.propertiesMenu.SetActive(!_gameManager.SO.propertiesMenu.activeSelf);
    }
}
