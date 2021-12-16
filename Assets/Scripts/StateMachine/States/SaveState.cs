using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SaveState", menuName = "ScriptableObjects/State/Save")]
public class SaveState : State
{
    public State _originalNextState;
    public override void BeginState()
    {
        gameData.loading.SetActive(true);
        gameData.startMenu.SetActive(false);
    }

    public override void GoNextState()
    {
        gameData.loading.SetActive(false);
        gameData.stateGame = nextState;

        if (nextState.stateEnum != _originalNextState.stateEnum)
            return;
        gameData.stateGame.BeginState();
        nextState = _originalNextState;
    }

    public override void Looping()
    {
    }
}
