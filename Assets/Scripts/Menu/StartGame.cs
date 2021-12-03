using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    //Dropdown of the menu
    [SerializeField] private Dropdown listPlayers;
    [SerializeField] private GameEvent startGame;
    [SerializeField] private LevelSetup levelSetup;
    private int nbPlayers; 

    //Both ref to the menus
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject propertiesMenu;
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject timerHud;

    //Ref to the script named "GameManager"
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.instance;
        _gameManager.SO.startMenu = startMenu;
        _gameManager.SO.propertiesMenu = propertiesMenu;
        _gameManager.SO.gameHud = gameMenu;
        _gameManager.SO.timerObject = timerHud;
    }

    public void Game()
    {
        switch (listPlayers.value)
        {
            case 0 :
                nbPlayers = 4;
                levelSetup.sizeX = nbPlayers * 2;
                levelSetup.sizeY = nbPlayers * 2;
                break;
            case 1 :
                nbPlayers = 8;
                levelSetup.sizeX = nbPlayers * 2;
                levelSetup.sizeY = nbPlayers * 2;
                break;
            case 2 :
                nbPlayers = 16;
                levelSetup.sizeX = nbPlayers;
                levelSetup.sizeY = nbPlayers;
                break;
            case 3 :
                nbPlayers = 24;
                levelSetup.sizeX = nbPlayers;
                levelSetup.sizeY = nbPlayers;
                break;
            case 4 :
                nbPlayers = 32;
                levelSetup.sizeX = nbPlayers;
                levelSetup.sizeY = nbPlayers;
                break;
            case 5 :
                nbPlayers = 48;
                levelSetup.sizeX = nbPlayers;
                levelSetup.sizeY = nbPlayers;
                break;
            default: break;
        }

        _gameManager.SO.nbPlayers = nbPlayers;
        _gameManager.SO.volume = PlayerPrefs.GetInt("Volume");
        _gameManager.state = global::Game.State.Lobby;
        startMenu.SetActive(false);
        startGame.Raise();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
