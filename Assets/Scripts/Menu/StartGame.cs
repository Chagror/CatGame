using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Dropdown listPlayers;
    private int nbPlayers;

    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject propertiesMenu;

    public void Game()
    {
        switch (listPlayers.value)
        {
            case 0 :
                nbPlayers = 4;
                break;
            case 1 :
                nbPlayers = 8;
                break;
            case 2 :
                nbPlayers = 16;
                break;
            case 3 :
                nbPlayers = 24;
                break;
            case 4 :
                nbPlayers = 32;
                break;
            case 5 :
                nbPlayers = 48;
                break;
            default: break;
        }

        //Pass that number to the gameManager
        startMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Escape))
            propertiesMenu.SetActive(!propertiesMenu.activeSelf);
        */
    }
}
