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

    private List<Player> _playerList;
    private void Start()
    {
        _gameManager = GameManager.instance;
        _playerList = PlayerManager.instance.players;
    }

    public void GoUp(int id)
    {
        foreach (Player player in _playerList)
        {
            if (player.GetID() == id)
            {
                Vector3 tempPos = player.transform.position;
                player.transform.position = new Vector3(tempPos.x, tempPos.y, tempPos.z + player.GetJumpSize());
            }
        }
    }
    public void GoLeft(int id)
    {
        foreach (Player player in _playerList)
        {
            if (player.GetID() == id)
            {
                Vector3 tempPos = player.transform.position;
                player.transform.position = new Vector3(tempPos.x - player.GetJumpSize(), tempPos.y, tempPos.z);
            }
        }
    }
    public void GoRight(int id)
    {
        foreach (Player player in _playerList)
        {
            if (player.GetID() == id)
            {
                Vector3 tempPos = player.transform.position;
                player.transform.position = new Vector3(tempPos.x + player.GetJumpSize(), tempPos.y, tempPos.z);
            }
        }
    }
    public void GoDown(int id)
    {
        foreach (Player player in _playerList)
        {
            if (player.GetID() == id)
            {
                Vector3 tempPos = player.transform.position;
                player.transform.position = new Vector3(tempPos.x, tempPos.y, tempPos.z - player.GetJumpSize());
            }
        }
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
