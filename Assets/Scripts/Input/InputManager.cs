using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private CommandToExecute _commandToExecute;
    public static InputManager instance;
    #region Singleton
    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }
    #endregion
    public void Update()
    {
        Execute();
        _commandToExecute.CommandPerPlayer = new Dictionary<Player, Action>();
    }
    public void Execute()
    {
        foreach (KeyValuePair<Player, Action> command in _commandToExecute.CommandPerPlayer)
        {
            command.Value.Execute(command.Key);
        }
    }
}
