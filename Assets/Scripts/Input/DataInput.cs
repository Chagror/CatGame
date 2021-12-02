using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputData", menuName = "ScriptableObjects/Input/InputData", order = 3)]
public class DataInput : ScriptableObject
{
    public Dictionary<string, string> commandsTwitch;
}
