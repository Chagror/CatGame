using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private string _name; 
    private int _posX;
    private int _posY;
    private float _jumpSize;

    [SerializeField] private GameEvent _deathEvent;
    private PlayerManager _playerManager;

    public void PlayerSetup(string name,int posX , int posY, float jumpSize) 
    {
        _name = name;
        _posX = posX;
        _posY = posY;
        _jumpSize = jumpSize;
        
        _playerManager = PlayerManager.instance;
    }

    public string GetName()
    {
        return _name;
    }
    public float GetJumpSize()
    {
        return _jumpSize;
    }
    public int GetMapIndexX() 
    {
        return _posX;
    }
    public int GetMapIndexY()
    {
        return _posY;
    }
    public void SetPosX(int posX) 
    {
        _posX = posX;
    }
    public void SetPosY(int posY)
    {
        _posY = posY;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Deathzone")
        {
            _deathEvent.Raise();
            _playerManager.RemovePlayer(this);
            Debug.Log(_name + " is dead");
            Destroy(gameObject);
        }
    }
}
