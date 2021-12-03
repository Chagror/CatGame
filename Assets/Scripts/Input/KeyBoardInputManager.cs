using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private Game _game;
    public DataInput SO_DataInput;

    [SerializeField] private CommandToExecute _commandToExecute;
    private List<Player> _playerList;
    [SerializeField] private int _nbrePlayerControlledWithKeyBoard = 2;
    
    private void Start()
    {
        _gameManager = GameManager.instance;
        _nbrePlayerControlledWithKeyBoard = _game.nbrePlayerControlledWithKeyBoard;
        _playerList = PlayerManager.instance.players;
        
    }

    public void GoUp(int id)
    {
        Debug.Log("up");
        if(id< _playerList.Count) 
            _commandToExecute.CommandPerPlayer.Add(_playerList[id], _actionGoUp);
    }
    public void GoLeft(int id)
    {
        if (id < _playerList.Count)
            _commandToExecute.CommandPerPlayer.Add(_playerList[id], _actionGoLeft);
    }
    public void GoRight(int id)
    {
        if (id < _playerList.Count)
            _commandToExecute.CommandPerPlayer.Add(_playerList[id], _actionGoRight);
    }
    public void GoDown(int id)
    {
        if (id < _playerList.Count)
            _commandToExecute.CommandPerPlayer.Add(_playerList[id], _actionGoDown);
    }




    public void Test()
    {
        _event.Raise();
    }
    public void Pause()
    {
        _gameManager.SO.propertiesMenu.SetActive(!_gameManager.SO.propertiesMenu.activeSelf);
    }
}