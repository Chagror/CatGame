using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Singleton
    public static InputManager instance;
    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }
    #endregion

    private GameManager _gameManager;
    [SerializeField]
    private GameEvent _event;

    public DataInput SO_DataInput;

    [SerializeField]
    private CommandList commands;
    private List<Player> _playerList;
    private void Start()
    {
        _gameManager = GameManager.instance;
        _playerList = PlayerManager.instance.players;
    }

    public void doAction(int id,string command)
    {
        Player player = _playerList.Find(p => p.GetID() == id);
        if (player == null)
        {
            Debug.LogError("Player not found");
            return;
        }
        Action action = commands.Find(command);
        if (action != null)
            action.Execute(player);
    }

    public void Test()
    {
        _event.Raise();
    }
    public void Pause()
    {
        _gameManager.SO.propertiesMenu.SetActive(!_gameManager.SO.propertiesMenu.activeSelf);
        _gameManager.SO.gameHud.SetActive(!_gameManager.SO.propertiesMenu.activeSelf);
    }
}
