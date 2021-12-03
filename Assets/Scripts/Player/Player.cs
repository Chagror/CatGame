using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private int _id; 
    private int _posX;
    private int _posY;
    private float _jumpSize;

    public void PlayerSetup(int id,int posX , int posY, float jumpSize) 
    {
        _id = id;
        _posX = posX;
        _posY = posY;
        _jumpSize = jumpSize;
    }

    public int GetID()
    {
        return _id;
    }

    public float GetJumpSize()
    {
        return _jumpSize;
    }


}
