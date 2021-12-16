using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Move", menuName = "ScriptableObjects/State/Move")]
public class Move : State
{
    public override void BeginState() 
    { 
    }

    public override void GoNextState()
    {
        gameManager.RaiseDeleteTileEvent();
        gameData.stateGame = nextState;
        gameData.stateGame.BeginState();
    }

    public override void Looping()
    {
        GoNextState();
    }
}
