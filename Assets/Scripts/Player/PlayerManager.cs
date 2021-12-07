using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;
    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }
    #endregion
    
    [SerializeField] private LevelSetup _levelSetup;
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject _playerPrefabs;
    [SerializeField] private float _playerHeightSpawn;
    [SerializeField] public List<Player> players = new List<Player>();
    private GameManager _gameManager;
    private List<int[]> _indexes = new List<int[]>();

    private void Start()
    {
        _gameManager = GameManager.instance;
    }

    public void RandomizeSpawn(int nbPlayer, TileMap map)
    {
        _indexes = new List<int[]>();
        _levelSetup = map.GetLevelSetup();
        var mapSizeX = _levelSetup.sizeX;
        var mapSizeY = _levelSetup.sizeY;

        for (int i = 0; i < nbPlayer; i++) 
        {
            int[] index = new int[2];
            do
            {
                index[0] = Random.Range(0, mapSizeX);
                index[1] = Random.Range(0, mapSizeY);

            } while (_indexes.Find(item => (item[0] == index[0] || item[1] == index[0])&& (item[1] == index[0] || item[1] == index[1]))!= null);
            _indexes.Add(index);
        }
    }

    public void InstantiatePlayer(string playerName)
    {
        if (players.Count >= _gameManager._gameData.nbPlayers)
            return;

        Vector3 pos = new Vector3();
        pos.x  = _indexes[players.Count][0] *_levelSetup.size + _indexes[players.Count][0] * _levelSetup.gapSize ;
        pos.z = -(_indexes[players.Count][1] * _levelSetup.size) - (_indexes[players.Count][1] * _levelSetup.gapSize) ;
        pos.y = _playerHeightSpawn;
        Player newPlayer = (Player)Instantiate(_playerPrefabs, pos, Quaternion.identity,_parent).GetComponent(typeof(Player));
        
        newPlayer.PlayerSetup(playerName, _indexes[players.Count][0], _indexes[players.Count][1], _levelSetup.size+ _levelSetup.gapSize);
        
        players.Add(newPlayer);
    }
}
