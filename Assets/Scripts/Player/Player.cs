using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private string _id;
    private int _posX;
    private int _posY;
    private float _jumpSize;

    public void PlayerSetup(string id,int posX , int posY, float jumpSize) 
    {
        _id = id;
        _posX = posX;
        _posY = posY;
        _jumpSize = jumpSize;

    }




}
