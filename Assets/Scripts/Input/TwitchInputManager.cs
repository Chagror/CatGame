using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitchInputManager : MonoBehaviour
{
    [SerializeField] private CommandToExecute _commandToExecute;
    [SerializeField] private CommandList _commands;
    [SerializeField] private CommandReadedFromTwitch _commandReaded;
    private List<Player> _playerList;
    public void Start()
    {
        _playerList = PlayerManager.instance.players;
    }
    public void Notify() 
    {
        CreateCommands();
    }
    public void CreateCommands() 
    {
        foreach (KeyValuePair<string, string> command in _commandReaded.CommandPerPlayer)
        {
            //_commandToExecute.CommandPerPlayer.Add();
            Player player = _playerList.Find(p => p.GetName().Equals(command.Key));
            if (player == null)
            {
                Debug.LogError("Player not found");
                return;
            }
            Action action = _commands.Find(command.Value);
            if (action != null)
            {
                if (!_commandToExecute.CommandPerPlayer.ContainsKey(player))
                    _commandToExecute.CommandPerPlayer.Add(player, action);
                else
                {
                    _commandToExecute.CommandPerPlayer[player] = action;
                }
            }
        }
    }
}
