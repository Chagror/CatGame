using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "ScriptableObjects/Game/GameManager", order = 1)]
public class Game : ScriptableObject
{
    public int nbPlayers;
    public GameObject propertiesMenu;
    public int nbrePlayerControlledWithKeyBoard;
    public int volume;
    
    [Header("Lobby")]
    public float timerToJoin;

    [Header("WaitForInput")] 
    public float timerForInputs;

    //[Header("Move")]
    
    //[Header("EndGame")]

    public enum State
    {
        Lobby,
        WaitForInput,
        Move,
        EndGame
    };
}
