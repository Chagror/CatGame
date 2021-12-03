using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CommandToExecute", menuName = "ScriptableObjects/Action/CommandToExecute")]
public class CommandToExecute : ScriptableObject
{
    public Dictionary<Player,Action> CommandPerPlayer = new Dictionary<Player, Action>();
}
