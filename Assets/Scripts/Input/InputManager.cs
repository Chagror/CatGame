using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private CommandToExecute _commandToExecute;

    public void Execute()
    {
        foreach (KeyValuePair<Player, Action> command in _commandToExecute.CommandPerPlayer)
        {
            command.Value.Execute(command.Key);
        }
    }
}
