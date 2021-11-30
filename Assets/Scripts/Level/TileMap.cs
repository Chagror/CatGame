using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    [SerializeField] private Transform parentTile;
    [SerializeField] private LevelSetup _levelSetup;
    [SerializeField] private List<Tile> _map;
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

    
    private void DeleteTile(int posX, int posY)
    {
        Tile toDelete = GetTile(posX, posY);
        _map.Remove(toDelete);
        toDelete.delete();
        
    }
}
