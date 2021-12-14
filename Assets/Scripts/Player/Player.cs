using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private string _name; 
    private int _posX;
    private int _posY;
    private float _jumpSize;
    private string _color;
    [SerializeField] private List<GameObject> _gameObjects;
    [SerializeField] private Transform _playerLocalSpawn;
    [SerializeField] private GameEvent _deathEvent;
    [SerializeField] private float _moveJumpPlayerTimerHarderBetterFasterStronger;
    private PlayerManager _playerManager;

    public void PlayerSetup(string name,int posX , int posY, float jumpSize, string color) 
    {
        _name = name;
        _posX = posX;
        _posY = posY;
        _jumpSize = jumpSize;
        _color = color;
        
        _playerManager = PlayerManager.instance;

        Vector3 tempTransform = _playerLocalSpawn.transform.position;
        tempTransform.y = _playerLocalSpawn.position.y;
        Instantiate(_gameObjects[Random.Range(0,_gameObjects.Count)], tempTransform, Quaternion.identity, this.gameObject.transform);
        
    }

    public string GetName()
    {
        return _name;
    }

    public string GetColor()
    {
        return _color;
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

            #region Death Message
            
            if(_name == "leniumgame")
                Debug.Log("HAHA LOIC EST MORT PTDR");
            else if(_name == "Player 1")
                Debug.Log("L'host est vraiment claqué au jeu");
            else
                Debug.Log(_name + " is dead");
            
            #endregion
            
            Destroy(gameObject);
        }
    }

    public IEnumerator SmoothMove(Vector3 v, Vector3 halfV)
    {
        float timer = 0;
        Vector3 tempStartPos = transform.position;

        float halfTimer = _moveJumpPlayerTimerHarderBetterFasterStronger / 2;
        
        while (timer < halfTimer)
        {
            transform.position = Vector3.Lerp(tempStartPos, halfV, timer / halfTimer);
            timer += Time.deltaTime;
            
            yield return null;
        }

        timer = 0;
        
        while (timer < halfTimer)
        {
            transform.position = Vector3.Lerp(halfV, v, timer / halfTimer);
            timer += Time.deltaTime;
            
            yield return null;
        }
    }
}
