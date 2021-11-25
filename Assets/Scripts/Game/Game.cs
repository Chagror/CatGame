using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "ScriptableObjects/Game/GameManager", order = 1)]
public class Game : ScriptableObject
{
    public int nbPlayers;
    public GameObject propertiesMenu;
}
