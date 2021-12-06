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
    public LevelSetup SO_levelManager;

    public void InitializeMap()
    {
        _map.createTileMap();
        //_playerManager.RandomizeSpawn(_gameData.nbPlayers, _map);
    }
}
