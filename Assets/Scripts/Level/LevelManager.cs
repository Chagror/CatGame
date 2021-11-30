using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TileMap _map;
    [SerializeField] private Game _gameSetup;
    [SerializeField] private int _nbreOfRandomIds;
    [SerializeField] private PlayerManager _playerManager;

    // Start is called before the first frame update
    public void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        _map.createTileMap();
        List<string> ids = new List<string>();
        for (int i = 0; i < _nbreOfRandomIds; i++) 
        {
            ids.Add(CreateRandomString());
        }
        _playerManager.LaunchGameWithRadomSpawn(_gameSetup.nbPlayers, _map, ids);
    }
    private string CreateRandomString(int stringLength = 10)
    {
        int _stringLength = stringLength - 1;
        string randomString = "";
        string[] characters = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        for (int i = 0; i <= _stringLength; i++)
        {
            randomString = randomString + characters[Random.Range(0, characters.Length)];
        }
        return randomString;
    }
}
