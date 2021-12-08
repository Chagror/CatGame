using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    [SerializeField] private Transform parentTile;
    [SerializeField] private LevelSetup _levelSetup;
    [SerializeField] private List<Tile> _map;
    private Camera _levelCamera;
    private LevelManager _levelManager;
    private float _baseCameraSize;

    private void Start()
    {
        _levelCamera = Camera.main;
        _levelManager = LevelManager.instance;
        _baseCameraSize = 50;
    }

    public void  createTileMap() 
    {
        for (int i = 0; i < _levelSetup.sizeY; i++)
        {
            for (int j = 0; j < _levelSetup.sizeX; j++)
            {
                _map.Add(new Tile(j, i, _levelSetup.size, _levelSetup.tileObject));
            }
        }

        Draw(_levelSetup.gapSize);
        float tempX = (((_levelManager._levelSetup.sizeX * _levelManager._levelSetup.size) +
                       ((_levelManager._levelSetup.sizeX - 1) * _levelManager._levelSetup.gapSize)) /2) - (_levelManager._levelSetup.size /2);
        float tempZ = (((_levelManager._levelSetup.sizeY * _levelManager._levelSetup.size) +
                       ((_levelManager._levelSetup.sizeY - 1) * _levelManager._levelSetup.gapSize)) /2) - (_levelManager._levelSetup.size /2);
        
        _levelCamera.transform.position = new Vector3(tempX, 64.5f, -tempZ);
        _levelCamera.orthographicSize = _baseCameraSize * _levelSetup.cameraSizeMultiply;
    }
    
    private void Draw(float gapSize)
    {
        foreach (var tile in _map)
        {
            tile.Draw(gapSize, parentTile);
        }
    }
    
    public LevelSetup GetLevelSetup() { return _levelSetup; }
    
    private Tile GetTile(int posX, int posY)
    {
        return _map.Find(item =>item.getX() == posX && item.getY() == posY);
    }
    
    public void DeleteTile(int posX, int posY)
    {
        //Debug.Log(_map.Count);
        Tile toDelete = GetTile(posX, posY);
        
        if(toDelete is null)
            Debug.LogError(posX + " " + posY);
        _map.Remove(toDelete);
        toDelete.delete();
        
    }
}
