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

    private List<int[]> _tileindexToDelete = new List<int[]>();

    public void InitializeMap()
    {
        _map.CreateTileMap();
        //_playerManager.RandomizeSpawn(_gameData.nbrePlayerControlledWithKeyBoard, _map);

        _playerManager.RandomizeSpawn(_gameData.nbPlayers, _map);

        for (var i = 1; i <= _gameData.nbrePlayerControlledWithKeyBoard; i++)
        {
            var playerName = "Player " + (i);
            _playerManager.InstantiatePlayer(playerName, "#000000");
        }
    }

    public void LoadMap(List<string> playersID, List<Vector2> playersIndex, List<string> colors, List<Vector2> tileIndex)
    {
        _map.LoadMap(tileIndex);
        _playerManager.SetupSpawnIndex(playersIndex);
        for (int i = 0; i < playersID.Count; i++)
        {
            _playerManager.InstantiatePlayer(playersID[i], colors[i]);
        }

    }
    public void PrepareTileToDeleteNextRound()
    {
        List<Player> players = _playerManager.GetPlayerList();
        _tileindexToDelete.Clear();
        foreach (Player player in players)
        {
            int posX = player.GetMapIndexX();
            int posY = player.GetMapIndexY();
            if ((posX >= 0 && posX <= _levelSetup.sizeX) && (posY >= 0 && posY <= _levelSetup.sizeY))
            {
                int[] index = new int[2] { posY, posX };
                _tileindexToDelete.Add(index);
            }
        }
    }
    public TileMap GetTileMap()
    {
        return _map;
    }
    public void DeleteTile()
    {
        if (_tileindexToDelete.Count == 0)
            return;
        foreach (int[] tileIndex in _tileindexToDelete)
        {
            _map.DeleteTile(tileIndex[1], tileIndex[0]);
        }
        _tileindexToDelete.Clear();
    }
    public void DeleteAllTile()
    {
        _map.DeleteAll();
    }
}
