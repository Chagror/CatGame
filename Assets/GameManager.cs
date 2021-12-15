using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }
    #endregion

    public Game _gameData;
    public Game.State state;

    [SerializeField] private GameEvent _executePhase;
    [SerializeField] private GameEvent _prepareToDelete;
    [SerializeField] private GameEvent _endGame;
    private PlayerManager _playerManager;
    private float _tempTimer;
    private float _tempTimerInput;
    private float _tempTimerEndGame;
    private float _waitBarSizeStart;

    private void Start()
    {
        _playerManager = PlayerManager.instance;
        _tempTimer = _gameData.timerToJoin;
        _tempTimerInput = _gameData.timerForInputs;
        _tempTimerEndGame = _gameData.timerEndGame;
        _waitBarSizeStart = _gameData.waitBarRectComponent.width;
    }

    private void Update()
    {
        switch (state)
        {
            case Game.State.Lobby:
                Lobby();
                break;
            case Game.State.WaitForInput:
                WaitForInput();
                break;
            case Game.State.Move:
                Move();
                break;
            case Game.State.EndGame:
                EndGame();
                break;
            default: break;
        }
    }
    public void SetWaitForInput()
    {
        state = Game.State.WaitForInput;
    }

    #region States methods
    private void Lobby()
    {
        _gameData.startMenu.SetActive(false);
        _gameData.gameHud.SetActive(true);
        _gameData.endMenu.SetActive(false);
        
        _tempTimer -= Time.deltaTime;
        _gameData.timerObject.GetComponent<TextMeshProUGUI>().text = "Timer to join : " + (int)_tempTimer;

        if (_tempTimer <= 0)
        {
            state = Game.State.WaitForInput;
        }
    }

    private void WaitForInput()
    {
        //Win
        if(_playerManager == null)
            _playerManager = PlayerManager.instance;
        
        if (_playerManager.GetPlayerList().Count <= 1)
            state = Game.State.EndGame;
        
        _gameData.gameHud.SetActive(true);
        _gameData.startMenu.SetActive(false);

        _gameData.timerObject.GetComponent<TextMeshProUGUI>().text = "Make your move : " + (int)_tempTimerInput;
        _tempTimerInput -= Time.deltaTime;
        
        if (_tempTimerInput <= 0)
        {
            _prepareToDelete.Raise();
            state = Game.State.Move;

            _executePhase.Raise();
        }
    }

    private void Move()
    {
        _gameData.gameHud.SetActive(false);
        state = Game.State.WaitForInput;
        _tempTimerInput = _gameData.timerForInputs;
    }

    private void EndGame()
    {
        _gameData.endMenu.SetActive(true);

        _gameData.endText.text = _playerManager.GetPlayerList()[0].GetName() + " just won!!";
        _tempTimerEndGame -= Time.deltaTime;
        
        float delta = _tempTimerEndGame / _gameData.timerEndGame;
        
        var tempBar = _gameData.waitBar.GetComponent<RectTransform>();

        tempBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _waitBarSizeStart * delta);

        if (_tempTimerEndGame <= 0)
        {
            //Yeah, awful, but i need to put it here, bc in a state for the start state, the variables are not passed to the SO,
            //so no way to enable or disable them.
            _endGame.Raise();
            state = Game.State.Start;
            _gameData.startMenu.SetActive(true);
            _gameData.endMenu.SetActive(false);
            //This is a method, waiting for a better state machine
        }
    }
    
    public void Loading()
    {
        _gameData.loading.SetActive(true);
        _gameData.startMenu.SetActive(false);
    }
    
    public void LoadFinished() 
    {
        _gameData.loading.SetActive(false);
    }
    #endregion
}
