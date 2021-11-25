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
            _inputManager.GoUp();
        
         _input.Gameplay.Down.performed += ctx =>
            _inputManager.GoDown();
         
         _input.Gameplay.Left.performed += ctx =>
            _inputManager.GoLeft();
         
         _input.Gameplay.Right.performed += ctx =>
            _inputManager.GoRight();
         _input.Gameplay.Test.performed += ctx =>
             _inputManager.Test();
          
         _input.Menu.PauseMenu.performed += ctx =>
             _inputManager.Pause();

         _input.Gameplay.Enable();
         _input.Menu.Enable();
    }
}
