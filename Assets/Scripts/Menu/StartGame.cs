using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    //Dropdown of the menu
    [SerializeField] private Dropdown dropdownNbPlayer;
    [SerializeField] private Dropdown dropdownNbPlayerTotal;
    [SerializeField] private LevelSetup levelSetup;
    private int nbPlayers;
    private int nbPlayersKeyboard;

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
        _gameManager._gameData.startMenu = startMenu;
        _gameManager._gameData.propertiesMenu = propertiesMenu;
        _gameManager._gameData.gameHud = gameMenu;
        _gameManager._gameData.timerObject = timerHud;
    }

    public void Game()
    {
        switch (dropdownNbPlayerTotal.value)
        {
            case 0:
                nbPlayersKeyboard = 0;
                break;
            case 1:
                nbPlayersKeyboard = 1;
                break;
            case 2:
                nbPlayersKeyboard = 2;
                break;
            default: break;
        }
        
        switch (dropdownNbPlayer.value)
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

        _gameManager._gameData.nbPlayers = nbPlayers;
        _gameManager._gameData.volume = PlayerPrefs.GetInt("Volume");
        
        _gameManager.state = global::Game.State.Lobby;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
