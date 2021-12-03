using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CommandReadedFromTwitch", menuName = "ScriptableObjects/Action/CommandReadedFromTwitch")]
public class CommandReadedFromTwitch : ScriptableObject
{
    public Dictionary<string, string> CommandPerPlayer = new Dictionary<string, string>();
}
