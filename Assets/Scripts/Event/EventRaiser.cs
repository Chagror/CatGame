using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class EventRaiser : MonoBehaviour
{
    // Start is called before the first frame update
    public  void Raise(GameEvent eventToRaise )
    {
        Debug.Log("test");
        eventToRaise.Raise();
    }
}
