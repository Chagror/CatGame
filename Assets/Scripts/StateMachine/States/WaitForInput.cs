using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
[CreateAssetMenu(fileName = "WaitForInput", menuName = "ScriptableObjects/State/WaitForInput")]
public class WaitForInput : State
{
    private PlayerManager _playerManager;
    public State EndState;
    public override void BeginState()
    {
        time = gameData.timerForInputs;
        gameData.gameHud.SetActive(true);
        gameData.startMenu.SetActive(false);
        if (gameManager is null)
            gameManager = GameManager.instance;
        gameManager.RaisePrepareDeleteEvent();
    }

    public async override void GoNextState()
    {
        gameData.stateGame = nextState;
        
    }
    public void GoToEndState() 
    {
        gameData.stateGame = EndState;
        gameData.stateGame.BeginState();
    }
    public override void Looping()
    {
        if (_playerManager == null)
            _playerManager = PlayerManager.instance;

        if (_playerManager.GetPlayerList().Count <= 1)
            GoToEndState();
        time -= Time.deltaTime;
        gameData.timerObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Make your move : " + (int)time;
        if (time <= 0)
        {
            if (gameManager is null)
                gameManager = GameManager.instance;
            gameManager.RaiseExecuteEvent();
            GoNextState();
            
        }
    }
}
