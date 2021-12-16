using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[CreateAssetMenu(fileName = "Lobby", menuName = "ScriptableObjects/State/Lobby")]
public class Lobby : State
{
    public override void BeginState() 
    {

        gameData.startMenu.SetActive(false);
        gameData.gameHud.SetActive(true);
        gameData.endMenu.SetActive(false);
        time = gameData.timerToJoin;
    }

    public override void GoNextState()
    {
        gameData.stateGame = nextState;

        gameManager.WriteGoogle();
        gameData.stateGame.BeginState();
    }

    public override void Looping()
    {
        time -= Time.deltaTime;
        gameData.timerObject.GetComponent<TextMeshProUGUI>().text = "Timer to join : " + (int)time;
        if (time <= 0)
        {
            GoNextState();
        }
    }
}
