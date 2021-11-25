using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    public void GoUp()
    {
        Debug.Log("I went up.");
    }
    public void GoLeft()
    {
        Debug.Log("I went left.");
    }
    public void GoRight()
    {
        Debug.Log("I went right.");
    }
    public void GoDown()
    {
        Debug.Log("I went down.");
    }
}
