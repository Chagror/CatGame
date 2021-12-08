using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class KeyBoardInputManager : MonoBehaviour
{
    #region Singleton
    public static KeyBoardInputManager instance;
    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }
    #endregion
    
    #region Actions
    [SerializeField]
    private Action _actionGoUp;
    [SerializeField]
    private Action _actionGoRight;
    [SerializeField]
    private Action _actionGoDown;
    [SerializeField]
    private Action _actionGoLeft;
    #endregion

    private GameManager _gameManager;
    [SerializeField]
    private GameEvent _event;
    [SerializeField]
    private Game _gameData;

    [SerializeField] private CommandToExecute _commandToExecute;
    private List<Player> _playerList;
    
    private void Start()
    {
        _gameManager = GameManager.instance;
        _playerList = PlayerManager.instance.GetPlayerList();
        
    }

    public void GoUp(string playerName)
    {
        Player player = _playerList.Find(p => p.GetName().Equals(playerName));
        if (player == null)
        {
            Debug.LogError("Player not found");
            return;
        }
        if (!_commandToExecute.CommandPerPlayer.ContainsKey(player))
            _commandToExecute.CommandPerPlayer.Add(player, _actionGoUp);
        else
        {
            _commandToExecute.CommandPerPlayer[player] = _actionGoUp;
        }
    }
    public void GoLeft(string playerName)
    {
        Player player = _playerList.Find(p => p.GetName().Equals(playerName));
        if (player == null)
        {
            Debug.LogError("Player not found");
            return;
        }
        if (!_commandToExecute.CommandPerPlayer.ContainsKey(player))
            _commandToExecute.CommandPerPlayer.Add(player, _actionGoLeft);
        else
        {
            _commandToExecute.CommandPerPlayer[player] = _actionGoLeft;
        }
    }
    public void GoRight(string playerName)
    {
        Player player = _playerList.Find(p => p.GetName().Equals(playerName));
        if (player == null)
        {
            Debug.LogError("Player not found");
            return;
        }

        if (!_commandToExecute.CommandPerPlayer.ContainsKey(player))
            _commandToExecute.CommandPerPlayer.Add(player, _actionGoRight);
        else
        {
            _commandToExecute.CommandPerPlayer[player] = _actionGoRight;
        }
    }
    public void GoDown(string playerName)
    {
        Player player = _playerList.Find(p => p.GetName().Equals(playerName));
        if (player == null)
        {
            Debug.LogError("Player not found");
            return;
        }
        if (!_commandToExecute.CommandPerPlayer.ContainsKey(player))
            _commandToExecute.CommandPerPlayer.Add(player, _actionGoDown);
        else
        {
            _commandToExecute.CommandPerPlayer[player] = _actionGoDown;
        }
    }
    
    public void Test()
    {
        _event.Raise();
    }
    public void Pause()
    {
        _gameManager._gameData.propertiesMenu.SetActive(!_gameManager._gameData.propertiesMenu.activeSelf);
    }
}
