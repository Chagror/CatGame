using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Start", menuName = "ScriptableObjects/State/Start")]
public class Start : State
{
    public override void BeginState()
    {
        gameData.startMenu.SetActive(true);
        gameData.endMenu.SetActive(false);
        if (gameManager is null)
            gameManager = GameManager.instance;


    }

    public override void GoNextState()
    {
        if (gameManager is null)
            gameManager = GameManager.instance;
        gameData.stateGame = nextState;
        gameData.stateGame.BeginState();
    }

    public override void Looping()
    {
    }
}
