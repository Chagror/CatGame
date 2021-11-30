using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private LevelSetup _levelSetup;
    
    [SerializeField] private GameObject _playerPrefabs;
    [SerializeField] private float _playerHeightSpawn;
    [SerializeField] private List<Player> _players = new List<Player>();
    private List<string> _ids = new List<string>();
    private List<int[]> _indexes = new List<int[]>();
    public void randomSpawn(int nbrePlayer, TileMap map, List<string> ids)
    {
        List<GameObject> players = new List<GameObject>();
        _indexes = new List<int[]>();
        if (nbrePlayer > ids.Count)
            Debug.LogError("not enought ids");
        _ids = ids;
        _levelSetup = map.GetLevelSetup();
        int mapSizeX = _levelSetup.sizeX;
        int mapSizeY = _levelSetup.sizeY;

        for (int i = 0; i < nbrePlayer; i++) 
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
    public void InstanciatePlayer() 
    {
        if (_indexes.Count == 0)
        {
            Debug.LogError("No player to intanciate need to spawn before");
        }
        for (int i = 0; i < _indexes.Count; i++ ) 
        {
            Vector3 pos = new Vector3();
            pos.x  = _indexes[i][0] *_levelSetup.size + _indexes[i][0] * _levelSetup.gapSize ;
            pos.z = -(_indexes[i][1] * _levelSetup.size) - (_indexes[i][1] * _levelSetup.gapSize) ;
            pos.y = _playerHeightSpawn;
            Player newPlayer = (Player)Instantiate(_playerPrefabs, pos, Quaternion.identity).GetComponent(typeof(Player));
            newPlayer.PlayerSetup(_ids[i], _indexes[i][0], _indexes[i][1], _levelSetup.size+ _levelSetup.gapSize);
            _players.Add(newPlayer);
        }
                 
    }
    public void LaunchGameWithRadomSpawn(int nbrePlayer, TileMap map, List<string> ids) 
    {
        randomSpawn(nbrePlayer,map, ids);
        InstanciatePlayer();
    }
}
