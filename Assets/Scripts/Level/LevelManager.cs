using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    #region Singleton
    public static LevelManager instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }
    #endregion

    [SerializeField] private TileMap _map;
    [SerializeField] private Game _gameData;
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] public LevelSetup _levelSetup;

    public void InitializeMap()
    {
        _map.createTileMap();
        //_playerManager.RandomizeSpawn(_gameData.nbrePlayerControlledWithKeyBoard, _map);

        _playerManager.RandomizeSpawn(_gameData.nbPlayers, _map);
        
        for (var i = 0; i >= _gameData.nbrePlayerControlledWithKeyBoard; i++)
        {
            var playerName = (i+1).ToString();
            _playerManager.InstantiatePlayer(playerName);
        }
    }
}
