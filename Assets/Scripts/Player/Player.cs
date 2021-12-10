using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private string _name; 
    private int _posX;
    private int _posY;
    private float _jumpSize;

    [SerializeField] private GameEvent _deathEvent;
    [SerializeField] private float _moveJumpPlayerTimerHarderBetterFasterStronger;
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

    public IEnumerator SmoothMove(Vector3 v)
    {
        float timer = 0;
        Vector3 tempStartPos = transform.position;

        while (timer < _moveJumpPlayerTimerHarderBetterFasterStronger)
        {
            transform.position = Vector3.Lerp(tempStartPos, v, timer / _moveJumpPlayerTimerHarderBetterFasterStronger);
            timer += Time.deltaTime;
            
            yield return null;
        }
    }
}
