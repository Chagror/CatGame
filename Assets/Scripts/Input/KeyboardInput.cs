using System;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    private Input _input;

    private KeyBoardInputManager _inputManager;

    private void Awake()
    {
        InputDelegate();
    }

    private void Start()
    {
        _inputManager = KeyBoardInputManager.instance;
    }

    private void InputDelegate()
    {
        _input = new Input();

        _input.Gameplay.Up.performed += ctx =>
            _inputManager.GoUp("Player 1");

        _input.Gameplay.Down.performed += ctx =>
           _inputManager.GoDown("Player 1");

        _input.Gameplay.Left.performed += ctx =>
           _inputManager.GoLeft("Player 1");

        _input.Gameplay.Right.performed += ctx =>
           _inputManager.GoRight("Player 1");
        
        _input.Gameplay.Up2.performed += ctx =>
            _inputManager.GoUp("Player 2");

        _input.Gameplay.Down2.performed += ctx =>
            _inputManager.GoDown("Player 2");

        _input.Gameplay.Left2.performed += ctx =>
            _inputManager.GoLeft("Player 2");

        _input.Gameplay.Right2.performed += ctx =>
            _inputManager.GoRight("Player 2");
        
        _input.Gameplay.Test.performed += ctx =>
            _inputManager.Save();

        _input.Menu.PauseMenu.performed += ctx =>
             _inputManager.Pause();

         _input.Gameplay.Enable();
         _input.Menu.Enable();
    }
}
