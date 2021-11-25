using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GameEvent", menuName = "ScriptableObjects/Event/GameEvent")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> _listeners;
    public void Raise()
    {
        for (int i = _listeners.Count - 1; i >= 0 ;i--)
        {
            _listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        _listeners.Add(listener);
    }
    public void UnregisterListener(GameEventListener listener)
    {
        _listeners.Remove(listener);
    }
}
