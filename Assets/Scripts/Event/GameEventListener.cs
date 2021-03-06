using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    private GameEvent _event;

    [SerializeField]
    private UnityEvent _onEventRaised;

    public void OnEventRaised()
    {
        _onEventRaised.Invoke();
    }

    private void OnEnable()
    {
        if(_event != null) _event.RegisterListener(this);
    }

    private void OnDisable()
    {
        if(_event != null) _event.UnregisterListener(this);
    }
}