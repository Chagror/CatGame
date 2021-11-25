using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private GameObject _tileObject;
    private int _poseX;
    private int _poseY;
    private float _tileSize = 10;

    public Tile(int poseX, int poseY, float tileSize, GameObject tileObject)
    {
        this._poseX = poseX;
        this._poseY = poseY;
        this._tileSize = tileSize;
        this._tileObject = tileObject;
    }

    public void Draw(float gapSize, Transform parent)
    {
        Vector3 pos = new Vector3();
        pos.z = -_poseY * _tileSize - _poseY * gapSize;
        pos.x = _poseX * _tileSize + _poseX * gapSize;
        _tileObject = Instantiate(_tileObject, pos, Quaternion.identity, parent);
    }

    public int getX()
    {
        return _poseX;
    }
    public int getY()
    {
        return _poseY;
    }

    public void delete()
    {
        Destroy(_tileObject);
    }
}
