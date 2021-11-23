using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSetup", menuName = "ScriptableObjects/Level/LevelSetup", order = 1)]
public class LevelSetup : ScriptableObject
{
    public int sizeX;
    public int sizeY;
    public float gapSize;
    public GameObject tileObject;
}
