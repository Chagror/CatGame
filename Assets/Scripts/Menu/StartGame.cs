using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    //Dropdown of the menu
    [SerializeField] private Dropdown _dropdownNbPlayer;
    [SerializeField] private Dropdown _dropdownNbPlayerTotal;
    [SerializeField] private LevelSetup _levelSetup;
    private int _nbPlayers;
    private int _nbPlayersKeyboard;

    //Both ref to the menus
    [SerializeField] private GameObject _startMenu;
    [SerializeField] private GameObject _propertiesMenu;
    [SerializeField] private GameObject _gameMenu;
    [SerializeField] private GameObject _timerHud;
    [SerializeField] private GameEvent _initialize;
    [SerializeField] private GameObject _fadeImage;
    [FormerlySerializedAs("_fadeSpeed")] [SerializeField] private float _fadeTimer;

    //Ref to the script named "GameManager"
    private GameManager _gameManager;
    
    private void Start()
    {
        _gameManager = GameManager.instance;
        _gameManager._gameData.startMenu = _startMenu;
        _gameManager._gameData.propertiesMenu = _propertiesMenu;
        _gameManager._gameData.gameHud = _gameMenu;
        _gameManager._gameData.timerObject = _timerHud;
    }

    public void Game()
    {
        switch (_dropdownNbPlayerTotal.value)
        {
            case 0:
                _nbPlayersKeyboard = 0;
                break;
            case 1:
                _nbPlayersKeyboard = 1;
                break;
            case 2:
                _nbPlayersKeyboard = 2;
                break;
            default: break;
        }
        
        switch (_dropdownNbPlayer.value)
        {
            case 0 :
                _nbPlayers = 4;
                _levelSetup.cameraSizeMultiply = _nbPlayers/4;
                _levelSetup.sizeX = _nbPlayers * 2;
                _levelSetup.sizeY = _nbPlayers * 2;
                break;
            case 1 :
                _nbPlayers = 8;
                _levelSetup.cameraSizeMultiply = _nbPlayers/4;
                _levelSetup.sizeX = _nbPlayers * 2;
                _levelSetup.sizeY = _nbPlayers * 2;
                break;
            case 2 :
                _nbPlayers = 16;
                _levelSetup.cameraSizeMultiply = _nbPlayers/8;
                _levelSetup.sizeX = _nbPlayers;
                _levelSetup.sizeY = _nbPlayers;
                break;
            case 3 :
                _nbPlayers = 24;
                _levelSetup.cameraSizeMultiply = _nbPlayers/8;
                _levelSetup.sizeX = _nbPlayers;
                _levelSetup.sizeY = _nbPlayers;
                break;
            case 4 :
                _nbPlayers = 32;
                _levelSetup.cameraSizeMultiply = _nbPlayers/8;
                _levelSetup.sizeX = _nbPlayers;
                _levelSetup.sizeY = _nbPlayers;
                break;
            case 5 :
                _nbPlayers = 48;
                _levelSetup.cameraSizeMultiply = _nbPlayers/8;
                _levelSetup.sizeX = _nbPlayers;
                _levelSetup.sizeY = _nbPlayers;
                break;
            default: break;
        }

        _gameManager._gameData.nbrePlayerControlledWithKeyBoard = _nbPlayersKeyboard;
        _gameManager._gameData.nbPlayers = _nbPlayers;
        _gameManager._gameData.volume = PlayerPrefs.GetInt("Volume");
        StartCoroutine(BlackFade());
        _initialize.Raise();
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator BlackFade()
    {
        float timer = 0;
        //Awful
        _fadeImage.transform.parent.gameObject.SetActive(true);
        var image = _fadeImage.GetComponent<Image>();

        while (timer < _fadeTimer)
        {
            image.color = Color.Lerp(new Color(0, 0, 0, 0), new Color(0, 0, 0, 1), timer / _fadeTimer);
            
            timer += Time.deltaTime;
            yield return null;
        }

        
        yield return new WaitForSeconds(1);
        _gameManager.state = global::Game.State.Lobby;
        timer = 0;

        while (timer < _fadeTimer)
        {
            image.color = Color.Lerp(new Color(0, 0, 0, 1), new Color(0, 0, 0, 0), timer / _fadeTimer);
            timer += Time.deltaTime;
            yield return null;
        }

        _fadeImage.transform.parent.gameObject.SetActive(false);
        
        yield return null;
    }
}
