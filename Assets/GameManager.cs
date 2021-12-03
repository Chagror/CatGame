using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Game SO;
    public Game.State state;

    [SerializeField] private GameEvent startGame;

    private float tempTimer;
    private float tempTimerInput;

    private void Awake()
    {
        if(instance)
            Destroy(instance);
        else
            instance = this;
    }

    private void Start()
    {
        tempTimer = SO.timerToJoin;
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
        SO.startMenu.SetActive(false);
        SO.gameHud.SetActive(true);
        
        tempTimer -= Time.deltaTime;
        SO.timerObject.GetComponent<TextMeshProUGUI>().text = "Timer to join : " + (int)tempTimer;

        if (SO.timerToJoin < 0)
        {
            startGame.Raise();
            state = Game.State.WaitForInput;
        }
    }

    private void WaitForInput()
    {
        tempTimerInput = SO.timerForInputs;

        tempTimerInput -= Time.deltaTime;
    }

    private void Move()
    {

    }

    private void EndGame()
    {
        SO.startMenu.SetActive(true);
        SO.gameHud.SetActive(false);
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
