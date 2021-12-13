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
    private float tempTimer;
    private float tempTimerInput;

    private void Start()
    {
        tempTimer = _gameData.timerToJoin;
        tempTimerInput = _gameData.timerForInputs;
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
        
        tempTimer -= Time.deltaTime;
        _gameData.timerObject.GetComponent<TextMeshProUGUI>().text = "Timer to join : " + (int)tempTimer;

        if (tempTimer <= 0)
        {
            
            state = Game.State.WaitForInput;
        }
    }

    private void WaitForInput()
    {
        _gameData.gameHud.SetActive(true);
        _gameData.startMenu.SetActive(false);

        _gameData.timerObject.GetComponent<TextMeshProUGUI>().text = "Make your move : " + (int)tempTimerInput;
        tempTimerInput -= Time.deltaTime;
        
        if (tempTimerInput <= 0)
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
        tempTimerInput = _gameData.timerForInputs;
    }

    private void EndGame()
    {
        _gameData.startMenu.SetActive(true);
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
