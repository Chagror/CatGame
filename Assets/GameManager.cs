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
    [SerializeField] private State SaveState;
    [SerializeField] private State StartState;
    [SerializeField] private GameEvent _executePhase;
    [SerializeField] private GameEvent _prepareToDelete;
    [SerializeField] private GameEvent _endGame;
    [SerializeField] private GameEvent _deleteTile;
    [SerializeField] private GameEvent _startGame;
    private PlayerManager _playerManager;
    private GoogleSheetClient _googleSheetClient;
    //private float _tempTimer;
    //private float _tempTimerInput;
    //private float _tempTimerEndGame;
    //private float _waitBarSizeStart;

    private void Start()
    {
        _gameData.stateGame = StartState;
        //_playerManager = PlayerManager.instance;
        //_tempTimer = _gameData.timerToJoin;
        //_tempTimerInput = _gameData.timerForInputs;
        //_tempTimerEndGame = _gameData.timerEndGame;
        //_waitBarSizeStart = _gameData.waitBarRectComponent.width;

    }
    public void GoNextState() 
    {
        _gameData.stateGame.GoNextState();
        _gameData.stateGame.BeginState();
    }
    private void Update()
    {
        _gameData.stateGame.Looping();
    }
    public void WriteGoogle()
    {
        if (_googleSheetClient is null)
        {
            _googleSheetClient = GoogleSheetClient.instance;
        }
        _googleSheetClient.WritePlayers();
    }
    public void ReadGoogle()
    {
        if (_googleSheetClient is null)
        {
            _googleSheetClient = GoogleSheetClient.instance;
        }
        _googleSheetClient.ReadTimers(_gameData);
    }
    public void Loading()
    {
        _gameData.stateGame = SaveState;
        _gameData.stateGame.BeginState();
        /*
        _gameData.stateGame.BeginState();
        State tmp = _gameData.stateGame;
        _gameData.stateGame = SaveState;
        _gameData.stateGame.nextState = tmp;
        */
    }
    public void LoadingSave() 
    {
        State tmp = _gameData.stateGame;
        _gameData.stateGame = SaveState;
        _gameData.stateGame.BeginState();
        _gameData.stateGame = SaveState;
        _gameData.stateGame.nextState = tmp;
    }
    public void LoadFinished()
    {
        _gameData.stateGame.GoNextState();
    }
    public void RaiseEndEvent()
    {
        _endGame.Raise();
    }
    public void RaiseExecuteEvent()
    {
        _executePhase.Raise();
    }
    public void RaisePrepareDeleteEvent()
    {
        _prepareToDelete.Raise();
    }
    public void RaiseDeleteTileEvent()
    {
        _deleteTile.Raise();
    }
}
