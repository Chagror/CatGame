using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TextMeshProUGUI endText;
    public Rect waitBarRectComponent;
    public State stateGame;

    [Header("Lobby")]
    public float timerToJoin;
    public GameObject timerObject;

    [Header("WaitForInput")] 
    public float timerForInputs;

    [Header("EndGame")] 
    public float timerEndGame;

}
