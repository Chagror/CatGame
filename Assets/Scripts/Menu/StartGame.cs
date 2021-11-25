using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Dropdown listPlayers;
    private int nbPlayers;

    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject propertiesMenu;

    [Header("Data pass")] 
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.instance;
        _gameManager.SO.propertiesMenu = propertiesMenu;
    }

    public void Game()
    {
        switch (listPlayers.value)
        {
            case 0 :
                nbPlayers = 4;
                break;
            case 1 :
                nbPlayers = 8;
                break;
            case 2 :
                nbPlayers = 16;
                break;
            case 3 :
                nbPlayers = 24;
                break;
            case 4 :
                nbPlayers = 32;
                break;
            case 5 :
                nbPlayers = 48;
                break;
            default: break;
        }

        _gameManager.SO.nbPlayers = nbPlayers;
        startMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
