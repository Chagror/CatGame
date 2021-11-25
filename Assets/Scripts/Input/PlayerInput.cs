using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Input _input;

    private InputManager _inputManager;

    private void Awake()
    {
        InputDelegate();
    }

    private void Start()
    {
        _inputManager = InputManager.instance;
    }

    private void InputDelegate()
    {
        _input = new Input();

        _input.Gameplay.Up.performed += ctx =>
        {
            Debug.Log("reger");
            _inputManager.GoUp();
        };
        
         _input.Gameplay.Down.performed += ctx =>
            _inputManager.GoDown();
         
         _input.Gameplay.Left.performed += ctx =>
            _inputManager.GoLeft();
         
         _input.Gameplay.Right.performed += ctx =>
            _inputManager.GoRight();

         _input.Gameplay.Enable();
    }
}
