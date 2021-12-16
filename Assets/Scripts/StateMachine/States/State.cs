using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject
{
    public float time;
    public State nextState;
    public StateEnum stateEnum;
    public Game gameData;

    public static GameManager gameManager;
    public enum StateEnum
    {
        Start,
        Lobby,
        WaitForInput,
        Move,
        EndGame
    };

    public abstract void BeginState();
    public abstract void Looping();
    public abstract void GoNextState();
}
