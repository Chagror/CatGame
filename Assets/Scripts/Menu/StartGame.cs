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
    [SerializeField] private GameObject _endMenu;
    [SerializeField] private GameObject _timerHud;
    [SerializeField] private GameObject _loading;
    [SerializeField] private GameObject _fadeImage;
    [SerializeField] private GameObject _waitBar;

    [SerializeField] private GameEvent _initialize;
    [SerializeField] private GameEvent _loadEvent;
    [SerializeField] private GameEvent _startEvent;

    [FormerlySerializedAs("_fadeSpeed")] [SerializeField] private float _fadeTimer;

    //Ref to the script named "GameManager"
    private GameManager _gameManager;
    
    private void Start()
    {
        _gameManager = GameManager.instance;
        _gameManager._gameData.startMenu = _startMenu;
        _gameManager._gameData.propertiesMenu = _propertiesMenu;
        _gameManager._gameData.endMenu = _endMenu;
        _gameManager._gameData.waitBar = _waitBar;
        _gameManager._gameData.waitBarRectComponent = _waitBar.GetComponent<RectTransform>().rect;
        _gameManager._gameData.gameHud = _gameMenu;
        _gameManager._gameData.timerObject = _timerHud;
        _gameManager._gameData.loading = _loading;
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
                _levelSetup.cameraSizeMultiply = 1;
                break;
            case 1 :
                _nbPlayers = 8;
                _levelSetup.cameraSizeMultiply = 1.25f;
                break;
            case 2 :
                _nbPlayers = 16;
                _levelSetup.cameraSizeMultiply = 1.8f;
                break;
            case 3 :
                _nbPlayers = 24;
                _levelSetup.cameraSizeMultiply = 2.25f;
                break;
            case 4 :
                _nbPlayers = 32;
                _levelSetup.cameraSizeMultiply = 2.5f; 
                break;
            case 5 :
                _nbPlayers = 48;
                _levelSetup.cameraSizeMultiply = 3;
                break;
            default: break;
        }
        
        _levelSetup.sizeX = Mathf.CeilToInt(Mathf.Sqrt(_nbPlayers * 3));
        _levelSetup.sizeY = Mathf.CeilToInt(Mathf.Sqrt(_nbPlayers * 3));
        _gameManager._gameData.nbrePlayerControlledWithKeyBoard = _nbPlayersKeyboard;
        _gameManager._gameData.nbPlayers = _nbPlayers;
        _gameManager._gameData.volume = PlayerPrefs.GetInt("Volume");
        StartCoroutine(BlackFade(global::Game.State.Lobby));
        _initialize.Raise();
        _startEvent.Raise();
    }
    public void LoadGameStart() 
    {
        _loadEvent.Raise();
    }
    public void Loaded() 
    {
        _startEvent.Raise();
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator BlackFade(Game.State state)
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
        _gameManager.state = state;
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
