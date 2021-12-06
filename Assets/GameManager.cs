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

    [SerializeField] private GameEvent startGame;

    private float tempTimer;
    private float tempTimerInput;

    private void Start()
    {
        tempTimer = _gameData.timerToJoin;
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

    #region States methods
    private void Lobby()
    {
        _gameData.startMenu.SetActive(false);
        _gameData.gameHud.SetActive(true);
        
        tempTimer -= Time.deltaTime;
        _gameData.timerObject.GetComponent<TextMeshProUGUI>().text = "Timer to join : " + (int)tempTimer;

        if (_gameData.timerToJoin <= 0)
        {
            state = Game.State.WaitForInput;
        }
    }

    private void WaitForInput()
    {
        tempTimerInput = _gameData.timerForInputs;

        _gameData.timerObject.GetComponent<TextMeshProUGUI>().text = "Make your move : " + (int)tempTimerInput;
        
        tempTimerInput -= Time.deltaTime;
    }

    private void Move()
    {

    }

    private void EndGame()
    {
        _gameData.startMenu.SetActive(true);
        _gameData.gameHud.SetActive(false);
    }

    private void StartGame()
    {
        //Can't pass startGameMenuor gameHud here
        //They are not initialized for the first frame, so red alert for Unity.

        //I know it's all fucked up, so i juste disabled and enabled what I wanted in the UI scene
        //and I let the rest manage themself

        //So yeah, this method does nothing
    }
    #endregion
}
