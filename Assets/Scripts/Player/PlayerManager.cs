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
    [SerializeField] private List<Player> _players = new List<Player>();
    private GameManager _gameManager;
    private List<int[]> _indexes = new List<int[]>();

    private void Start()
    {
        _gameManager = GameManager.instance;
    }


    public List<Player> GetPlayerList()
    {
        return _players;
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

            } while (_indexes.Find(item => (item[0] == index[0] && item[1] == index[1])) != null);
            _indexes.Add(index);
        }
    }
    public void SetupSpawnIndex(List<Vector2> indexes)
    {
        _indexes.Clear();
        foreach (var index in indexes) 
        {
            int[] newIndex = new int[2];
            newIndex[0] =(int)index[0];
            newIndex[1] = (int)index[1];
            _indexes.Add(newIndex);
        }
    }

    public void InstantiatePlayer(string playerName)
    {
        if ( _players.Count >= _gameManager._gameData.nbPlayers || _players.Find(p=>p.GetName().Equals(playerName)) )
            return;

        Vector3 pos = new Vector3();
        pos.x  = _indexes[_players.Count][0] *_levelSetup.size + _indexes[_players.Count][0] * _levelSetup.gapSize ;
        pos.z = -(_indexes[_players.Count][1] * _levelSetup.size) - (_indexes[_players.Count][1] * _levelSetup.gapSize) ;
        pos.y = _playerHeightSpawn;
        Player newPlayer = (Player)Instantiate(_playerPrefabs, pos, Quaternion.identity,_parent).GetComponent(typeof(Player));
        
        newPlayer.PlayerSetup(playerName, _indexes[_players.Count][0], _indexes[_players.Count][1], _levelSetup.size+ _levelSetup.gapSize);
        
        _players.Add(newPlayer);
    }

    public void RemovePlayer(Player player)
    {
        _players.Remove(player);
    }
}
