using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    [SerializeField] private LevelSetup _size;
    [SerializeField] private List<Tile> _map;
    public void Start()
    {
        for (int i = 0; i < _size.sizeY; i++)
        {
            for (int j = 0; j < _size.sizeX; j++)
            {
                _map.Add(new Tile(j,i,10,_size.tileObject));
            }
        }

        Draw(_size.gapSize);
        DeleteTile(0,0);

    }

    private void Draw(float gapSize)
    {
        foreach (var tile in _map)
        {
            tile.Draw(gapSize);
        }
    }

    private Tile getTile(int posX, int posY)
    {
        return _map.Find(item =>item.getX() == posX && item.getY() == posY);
    }

    private void DeleteTile(int posX, int posY)
    {
        Tile toDelete = getTile(posX, posY);
        _map.Remove(toDelete);
        toDelete.delete();
        
    }
}
