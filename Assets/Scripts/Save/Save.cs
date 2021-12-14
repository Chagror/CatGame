using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Save
{
    [SerializeField] public List<Vector2> playersIndex;
    [SerializeField] public List<Vector2> tileIndex;
    [SerializeField] public List<string> playersID;
    [SerializeField] public List<string> colors;

}
