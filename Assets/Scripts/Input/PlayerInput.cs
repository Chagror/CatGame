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
            _inputManager.doAction(1,"u");
        
         _input.Gameplay.Down.performed += ctx =>
            _inputManager.doAction(1,"d");
         
         _input.Gameplay.Left.performed += ctx =>
            _inputManager.doAction(1,"l");
         
         _input.Gameplay.Right.performed += ctx =>
            _inputManager.doAction(1,"r");
         _input.Gameplay.Test.performed += ctx =>
             _inputManager.Test();
          
         _input.Menu.PauseMenu.performed += ctx =>
             _inputManager.Pause();

         _input.Gameplay.Enable();
         _input.Menu.Enable();
    }
}
