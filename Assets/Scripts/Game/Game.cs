using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "ScriptableObjects/Game/GameManager", order = 1)]
public class Game : ScriptableObject
{
    public int nbPlayers;
    public int nbrePlayerControlledWithKeyBoard;
    public int volume;
    
    [Header("Menus")]
    public GameObject startMenu;
    public GameObject propertiesMenu;
    public GameObject gameHud;
    public GameObject loading;
    public GameObject endMenu;
    public GameObject waitBar;
    public GameObject endText;
    public Rect waitBarRectComponent;

    [Header("Lobby")]
    public float timerToJoin;
    public GameObject timerObject;

    [Header("WaitForInput")] 
    public float timerForInputs;

    [Header("EndGame")] 
    public float timerEndGame;

    public enum State
    {
        Start,
        Lobby,
        WaitForInput,
        Move,
        EndGame
    };
}
